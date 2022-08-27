using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private  IDatabaseFactory _dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory) { _dbFactory = dbFactory; }
        public void Commit() { _dbFactory.DataContext.SaveChanges(); }

        public void Dispose() { _dbFactory.DataContext.Dispose(); }


    }
}
