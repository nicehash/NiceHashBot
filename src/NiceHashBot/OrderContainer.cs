using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
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

        [JsonIgnore]
        public Order OrderStats;

        [JsonIgnore]
        private OrderInstance LinkedInstance;

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
        }

        public OrderContainer(int SL, int Algo, double Price, double SpeedLimit, Pool PoolInfo, int OrderID, double StartPrice, double StartAmount)
        {
            ServiceLocation = SL;
            Algorithm = Algo;
            MaxPrice = Price;
            Limit = SpeedLimit;
            PoolData = PoolInfo;
            ID = OrderID;
            StartingAmount = StartAmount;
            StartingPrice = StartPrice;
        }


        public void Launch()
        {
            if (LinkedInstance != null) return;
            LinkedInstance = new OrderInstance(ServiceLocation, Algorithm, MaxPrice, Limit, PoolData, ID, StartingPrice, StartingAmount);
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


        public static void Add(int SL, int Algo, double Price, double SpeedLimit, Pool PoolInfo, int OrderID, double StartPrice, double StartAmount)
        {
            OrderContainer OC = new OrderContainer(SL, Algo, Price, SpeedLimit, PoolInfo, OrderID, StartPrice, StartAmount);
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
