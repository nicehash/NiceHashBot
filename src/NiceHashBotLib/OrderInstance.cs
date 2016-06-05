using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NiceHashBotLib
{
    public class OrderInstance
    {
        #region PRIVATE_PROPERTIES

        private int ServiceLocation;
        private int Algorithm;
        private int OrderID;
        private double MaxPrice;
        private double StartLimit;
        private Pool PoolData;
        private bool CanRun;
        private Thread OrderThread;
        private Order LastOrderStats;
        private double StartingPrice;
        private double StartingAmount;
        private DateTime DecreaseTime;

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Create new order instance. This instance actively monitors order and adjusts price on-fly to keep order competitive at all times.
        /// </summary>
        /// <param name="SL">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algo">Algorithm number.</param>
        /// <param name="MaximalPrice">Maximal allowed order price.</param>
        /// <param name="Limit">Order limit in GH/s (TH/s for Algorithm 1 - SHA256). 0 for unlimited.</param>
        /// <param name="PoolInfo">Pool information.</param>
        /// <param name="ID">Optional - If monitoring existing order, set this to order ID.</param>i
        /// <param name="Price">Optional starting price.</param>
        /// <param name="StartingAmount">Optional starting amount in BTC.</param>
        public OrderInstance(int SL, int Algo, double MaximalPrice, double Limit, Pool PoolInfo, int ID = 0, double Price = 0.001, double Amount = 0.01)
        {
            CanRun = true;
            ServiceLocation = SL;
            Algorithm = Algo;
            MaxPrice = MaximalPrice;
            StartLimit = Limit;
            PoolData = PoolInfo;
            OrderID = ID;
            StartingPrice = Price;
            StartingAmount = Amount;
            DecreaseTime = DateTime.Now - APIWrapper.PRICE_DECREASE_INTERVAL;

            OrderThread = new Thread(ThreadRun);
            OrderThread.Start();
        }

        /// <summary>
        /// Set new maximal price for this order instance.
        /// </summary>
        /// <param name="NewMaxPrice">Maximal allowed price.</param>
        public void SetMaximalPrice(double NewMaxPrice)
        {
            lock (this)
            {
                MaxPrice = NewMaxPrice;
            }
        }

        /// <summary>
        /// Set new limit for this order instance.
        /// </summary>
        /// <param name="Limit">New order limit in GH/s (TH/s for Algorithm 1 - SHA256). 0 for unlimited.</param>
        public void SetLimit(double Limit)
        {
            lock (this)
            {
                StartLimit = Limit;
            }
        }

        /// <summary>
        /// Stop this order instance monitoring.
        /// </summary>
        /// <param name="RemoveOrder">Set to true to remove order.</param>
        public void Stop(bool RemoveOrder)
        {
            lock (this)
            {
                if (RemoveOrder && OrderID != 0)
                    APIWrapper.OrderRemove(ServiceLocation, Algorithm, OrderID);

                CanRun = false;
            }

            OrderThread.Join();
        }

        /// <summary>
        /// Get order details.
        /// </summary>
        /// <returns>Order object containing order properties.</returns>
        public Order GetDetails()
        {
            lock (this)
            {
                return LastOrderStats;
            }
        }

        #endregion

        #region PRIVATE_METHODS

        private void ThreadRun()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            while (CanRun)
            {
                if (!APIWrapper.ValidAuthorization)
                {
                    System.Threading.Thread.Sleep(500);
                    continue;
                }
                   
                lock (this)
                {
                    bool NewOrder = false;

                    // Verify, if we have order.
                    if (OrderID == 0)
                    {
                        // Need to create order.
                        OrderID = APIWrapper.OrderCreate(ServiceLocation, Algorithm, StartingAmount, StartingPrice, StartLimit, PoolData);
                        if (OrderID > 0)
                        {
                            NewOrder = true;
                            LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Created new order #" + OrderID.ToString());
                        }
                    }

                    if (OrderID > 0)
                    {
                        // Get all orders.
                        List<Order> AllOrders = APIWrapper.GetAllOrders(ServiceLocation, Algorithm, NewOrder);
                        if (AllOrders != null)
                        {
                            // Find our order.
                            Order MyOrder = null;
                            foreach (Order O in AllOrders)
                            {
                                if (O.ID == OrderID)
                                {
                                    MyOrder = O;
                                    break;
                                }
                            }

                            // Get total hashing speed
                            double TS = APIWrapper.GetTotalSpeed(ServiceLocation, Algorithm);

                            if (MyOrder != null)
                            {
                                ProcessMyOrder(MyOrder, AllOrders.ToArray(), TS);
                                LastOrderStats = new Order(MyOrder);
                            }
                            else
                            {
                                // Our order does not exist anymore, create new...
                                OrderID = 0;
                                LastOrderStats = null;
                            }
                        }
                    }
                }

                // Wait 30 seconds.
                for (int i = 0; i < 30; i++)
                {
                    if (!CanRun) break;
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void ProcessMyOrder(Order MyOrder, Order[] AllOrders, double TotalSpeed)
        {
            // Change limit if requested by user.
            if (MyOrder.SpeedLimit != StartLimit)
            {
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Changing limit order #" + MyOrder.ID + " to " + StartLimit.ToString("F2"));
                MyOrder.SetLimit(StartLimit);
            }

            // Check if refill is needed.
            if (MyOrder.BTCAvailable <= 0.003)
            {
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Refilling order #" + MyOrder.ID);
                if (MyOrder.Refill(0.01))
                    MyOrder.BTCAvailable += 0.01;
            }

            // Do not adjust price, if order is dead.
            if (!MyOrder.Alive) return;

            // Adjust price.
            double MinimalPrice = GetMinimalNeededPrice(AllOrders, TotalSpeed);
            if (!IncreasePrice(MyOrder, AllOrders, MinimalPrice))
                DecreasePrice(MyOrder, AllOrders, MinimalPrice);
        }


        private double GetMinimalNeededPrice(Order[] AllOrders, double TotalSpeed)
        {
            double TotalWantedSpeed = 0;
            int i;
            //double Multi = 1;
            //if (Algorithm == 1) Multi = 1000;
            for (i = 0; i < AllOrders.Length; i++)
            {
                if (AllOrders[i].SpeedLimit == 0)
                    TotalWantedSpeed += 1000000000;
                else
                    TotalWantedSpeed += AllOrders[i].SpeedLimit / APIWrapper.ALGORITHM_MULTIPLIER[Algorithm];

                if (TotalWantedSpeed > TotalSpeed) break;
            }

            if (i == AllOrders.Length)
                i = AllOrders.Length - 1;

            return (AllOrders[i].Price + 0.0001);
        }


        private bool IncreasePrice(Order MyOrder, Order[] AllOrders, double MinimalPrice)
        {
            // Do not make price higher if we are already on top of the list (first alive).
            // Consider fixed orders.
            foreach (Order O in AllOrders)
            {
                if (!O.Alive) continue;
                if (O.OrderType == 1) continue;
                if (O == MyOrder) return false;
                else break;
            }

            // Do not increase price, if we already have price higher or equal compared to minimal price.
            if (MyOrder.Price >= (MinimalPrice - 0.00001)) return false;

            if (MaxPrice >= MinimalPrice)
            {
                // We can set higher price.
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Setting price order #" + MyOrder.ID + " to " + MinimalPrice.ToString("F4"));
                double NewP = MyOrder.SetPrice(MinimalPrice);
                if (NewP > 0) MyOrder.Price = NewP;

                return true;
            }
            else if (MyOrder.Price < MaxPrice)
            {
                // We can at least set price to be MaxPrice
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Setting price order #" + MyOrder.ID + " to " + MaxPrice.ToString("F4"));
                double NewP = MyOrder.SetPrice(MaxPrice);
                if (NewP > 0) MyOrder.Price = NewP;

                return true;
            }

            return false;
        }


        private void DecreasePrice(Order MyOrder, Order[] AllOrders, double MinimalPrice)
        {
            // Check time if decrase is possible.
            if (DecreaseTime + APIWrapper.PRICE_DECREASE_INTERVAL > DateTime.Now) return;

            // Decrease only in case if we are still above or equal to minimal price. Or if we are above maximal price.
            if (MyOrder.Price + APIWrapper.PRICE_DECREASE_STEP[MyOrder.Algorithm] >= MinimalPrice ||
                MyOrder.Price > MaxPrice)
            {
                double NewP = MyOrder.SetPriceDecrease();
                if (NewP > 0)
                {
                    MyOrder.Price = NewP;
                    LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Decreasing price order #" + MyOrder.ID + " to " + NewP.ToString("F4"));
                    DecreaseTime = DateTime.Now;
                }
            }
        }

        #endregion
    }
}
