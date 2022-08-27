using GP.Data.Infrastructure;
using GP.Domain.Entities;
using GP.ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Service
{
    public class MedecinService : EntityService<Medecin>, IMedecinService
    {
        public MedecinService(IUnitOfWork utwk, IRepositoryBase<Medecin> repository) : base(utwk, repository)
        {
        }
    }
}
