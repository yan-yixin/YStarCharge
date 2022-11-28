using NHibernate;
using System;
using YStarCharge.Common;
using YStarCharge.Model;

namespace YStarCharge.CommonRepository
{
    internal sealed class CommonRepository:ICommonRepository
    {
        public long AddEntify<T>(T t) where T :IEntity
        {
            long id = 0;
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    id = long.Parse(session.Save(t).ToString());
                    session.Flush();
                }
            }
            catch(Exception ex)
            {

            }
            return id;
        }

        public void Update<T>(T t) where T : IEntity
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Update(t);
                session.Flush();
            }
        }
    }
}
