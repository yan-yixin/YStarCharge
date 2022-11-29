namespace YStarCharge
{
    public class AppContext
    {
        private static readonly object LockObj = new object();

        private static AppContext instance;
        public static AppContext Instacne
        {
            get
            {
                if(instance == null)
                {
                    lock (LockObj)
                    {
                        if(instance == null)
                        {
                            instance = new AppContext();
                        }
                    }
                }
                return instance;
            }

        }

        public string Username { get; set; }
    }
}
