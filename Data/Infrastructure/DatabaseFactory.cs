using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data;
using Microsoft.EntityFrameworkCore;


namespace GP.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly ExamenContext gestionProduitsContext;
        

        public DatabaseFactory(ExamenContext _gestionProduitsContext)
        {
            gestionProduitsContext = _gestionProduitsContext;
        }

        
        public DbContext DataContext
        {
            get { return gestionProduitsContext; }
        }
        
  
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
        
    }


}
