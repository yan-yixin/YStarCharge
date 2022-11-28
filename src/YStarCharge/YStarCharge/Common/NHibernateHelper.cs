using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YStarCharge.Common
{
    internal static class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if(sessionFactory == null)
                {
                    var configure = new Configuration();
                    configure.Configure();
                    sessionFactory = configure.BuildSessionFactory();
                }
                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            try
            {
                return SessionFactory.OpenSession();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
