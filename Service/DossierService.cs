using GP.Data.Infrastructure;
using GP.Domain.Entities;
using GP.ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Service
{
   public class DossierService : EntityService<DossierMedical>, IDossierService
    {
        public DossierService(IUnitOfWork utwk, IRepositoryBase<DossierMedical> repository) : base(utwk, repository)
        {
        }
    }
}
