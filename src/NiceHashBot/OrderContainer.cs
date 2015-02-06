using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using NiceHashBotLib;
using Newtonsoft.Json;

namespace NiceHashBot
{
    public class OrderContainer
    {
        public int ID;
        public int Algorithm;
        public int ServiceLocation;
        public double MaxPrice;
        public double Limit;
        public Pool PoolData;
        public double StartingPrice;
        public double StartingAmount;
        public string HandlerDLL;

        [JsonIgnore]
        public Order OrderStats;

        [JsonIgnore]
        private OrderInstance LinkedInstance;

        [JsonIgnore]
        private MethodInfo HandlerMethod;

        private static List<OrderContainer> OrderList;

        public OrderContainer()
        {
        }

        public OrderContainer(int SL, int Algo, double Price, double SpeedLimit, Pool PoolInfo)
        {
            ServiceLocation = SL;
            Algorithm = Algo;
            MaxPrice = Price;
            Limit = SpeedLimit;
            PoolData = PoolInfo;
            ID = 0;
            StartingAmount = 0.01;
            StartingPrice = 0.001;
            HandlerDLL = "";
        }

        public OrderContainer(int SL, int Algo, double Price, double SpeedLimit, Pool PoolInfo, int OrderID, double StartPrice, double StartAmount, string HandlerFile)
        {
            ServiceLocation = SL;
            Algorithm = Algo;
            MaxPrice = Price;
            Limit = SpeedLimit;
            PoolData = PoolInfo;
            ID = OrderID;
            StartingAmount = StartAmount;
            StartingPrice = StartPrice;
            HandlerDLL = HandlerFile;
        }


        public void Launch()
        {
            if (LinkedInstance != null) return;
            LinkedInstance = new OrderInstance(ServiceLocation, Algorithm, MaxPrice, Limit, PoolData, ID, StartingPrice, StartingAmount);

            if (HandlerDLL.Length > 0)
            {
                try
                {
                    Assembly ASS = Assembly.LoadFrom(HandlerDLL);
                    Type T = ASS.GetType("HandlerClass");
                    HandlerMethod = T.GetMethod("HandleOrder");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void Stop(bool RemoveRemoteOrder)
        {
            if (LinkedInstance == null) return;
            LinkedInstance.Stop(RemoveRemoteOrder);
        }

        public void SetOrderLimit(double NewLimit)
        {
            if (LinkedInstance == null) return;
            LinkedInstance.SetLimit(NewLimit);
            Limit = NewLimit;
        }


        public void SetOrderMaxPrice(double NewMaxPrice)
        {
            if (LinkedInstance == null) return;
            LinkedInstance.SetMaximalPrice(NewMaxPrice);
            MaxPrice = NewMaxPrice;
        }


        public void RefreshStats()
        {
            if (LinkedInstance == null) OrderStats = null;
            OrderStats = LinkedInstance.GetDetails();
            if (OrderStats != null && OrderStats.ID != ID)
            {
                ID = OrderStats.ID;
                Commit();
            }

            if (HandlerMethod != null)
            {
                object[] Parameters = new object[3];
                Parameters[0] = OrderStats;
                Parameters[1] = MaxPrice;
                Parameters[2] = Limit;
                HandlerMethod.Invoke(null, Parameters);
                if ((double)Parameters[1] != MaxPrice)
                {
                    MaxPrice = (double)Parameters[1];
                    if (MaxPrice < 0) MaxPrice = 0.001;
                    LinkedInstance.SetMaximalPrice(MaxPrice);
                }
                if ((double)Parameters[2] != Limit)
                {
                    Limit = (double)Parameters[2];
                    if (Limit < 0) Limit = 0;
                    LinkedInstance.SetLimit(Limit);
                }
            }
        }


        public static void Initialize()
        {
            string TextData = null;
            try
            {
                TextData = File.ReadAllText("orders.json");
            }
            catch { }

            if (TextData != null)
            {
                OrderList = JsonConvert.DeserializeObject<List<OrderContainer>>(TextData);
                foreach (OrderContainer OC in OrderList)
                    OC.Launch();
            }
            else
            {
                OrderList = new List<OrderContainer>();
            }
        }


        public static void Deinitialize()
        {
            foreach (OrderContainer OC in OrderList)
                OC.Stop(false);
        }


        private static void Commit()
        {
            string TextData = JsonConvert.SerializeObject(OrderList, Formatting.Indented);
            File.WriteAllText("orders.json", TextData);
        }


        public static OrderContainer[] GetAll()
        {
            OrderContainer[] OArray = OrderList.ToArray();
            foreach (OrderContainer OC in OArray)
                OC.RefreshStats();

            return OArray;
        }

        public static void Add(int SL, int Algo, double Price, double SpeedLimit, Pool PoolInfo)
        {
            OrderContainer OC = new OrderContainer(SL, Algo, Price, SpeedLimit, PoolInfo);
            OC.Launch();
            OrderList.Add(OC);
            Commit();
        }


        public static void Add(int SL, int Algo, double Price, double SpeedLimit, Pool PoolInfo, int OrderID, double StartPrice, double StartAmount, string HandlerFile)
        {
            OrderContainer OC = new OrderContainer(SL, Algo, Price, SpeedLimit, PoolInfo, OrderID, StartPrice, StartAmount, HandlerFile);
            OC.Launch();
            OrderList.Add(OC);
            Commit();
        }


        public static void Remove(int Index)
        {
            OrderList[Index].Stop(true);
            OrderList.RemoveAt(Index);
            Commit();
        }


        public static void SetLimit(int Index, double NewLimit)
        {
            OrderList[Index].SetOrderLimit(NewLimit);
            Commit();
        }


        public static void SetMaxPrice(int Index, double NewMaxPrice)
        {
            OrderList[Index].SetOrderMaxPrice(NewMaxPrice);
            Commit();
        }


        public static double GetLimit(int Index)
        {
            return OrderList[Index].Limit;
        }


        public static double GetMaxPrice(int Index)
        {
            return OrderList[Index].MaxPrice;
        }
    }
}
