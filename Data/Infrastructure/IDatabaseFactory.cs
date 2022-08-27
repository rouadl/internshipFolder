using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data;
using Microsoft.EntityFrameworkCore;


namespace GP.Data.Infrastructure
{
   public interface IDatabaseFactory : IDisposable
    {
        // instancié l'objet Context
        DbContext DataContext { get; }

    }

}
