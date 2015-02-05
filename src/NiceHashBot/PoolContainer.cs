using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NiceHashBotLib;
using Newtonsoft.Json;

namespace NiceHashBot
{
    public class PoolContainer
    {
        private static List<Pool> PoolList;

        public static void Initialize()
        {
            string TextData = null;
            try
            {
                TextData = File.ReadAllText("pools.json");
            }
            catch { }

            if (TextData != null)
            {
                PoolList = JsonConvert.DeserializeObject<List<Pool>>(TextData);
            }
            else
            {
                PoolList = new List<Pool>();
            }
        }


        private static void Commit()
        {
            string TextData = JsonConvert.SerializeObject(PoolList, Formatting.Indented);
            File.WriteAllText("pools.json", TextData);
        }


        public static Pool[] GetAll()
        {
            return PoolList.ToArray();
        }


        public static void Remove(int Index)
        {
            PoolList.RemoveAt(Index);
            Commit();
        }


        public static void Add(string Label, string Host, int Port, string User, string Pass)
        {
            Pool P = new Pool();
            P.Label = Label;
            P.Host = Host;
            P.Password = Pass;
            P.User = User;
            P.Port = Port;
            PoolList.Add(P);
            Commit();
        }
    }
}
