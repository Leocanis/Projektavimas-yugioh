using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.WebAPI.Classes
{
    public class CardDatabaseSingleton
    {
        private static CardDatabaseSingleton _instance = new CardDatabaseSingleton();
        private static readonly object _padlock = new object();
        private CardDatabaseSingleton() { }     //private makes it so no new copies of the singleton instance can be created

        public static CardDatabaseSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)     //locks and instantiates singleton thread
                    {
                        if (_instance == null)
                        {
                            _instance = new CardDatabaseSingleton();
                        }
                    }

                }

                return _instance;
            }
        }

        public void ReturnCardInfo(int id)
        {

        }

    }
}
