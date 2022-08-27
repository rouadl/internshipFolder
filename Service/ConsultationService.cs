using GP.Data.Infrastructure;
using GP.Domain.Entities;
using GP.ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Service
{
    public class ConsultationService : EntityService<Consultation>, IConsultationService
    {
        public ConsultationService(IUnitOfWork utwk, IRepositoryBase<Consultation> repository) : base(utwk, repository)
        {
        }
    }
}
