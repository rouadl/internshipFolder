using GP.Data.Infrastructure;
using GP.Domain.Entities;
using GP.ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Service
{
    public class PatientService : EntityService<Patient>, IPatientService
    {
        public PatientService(IUnitOfWork utwk, IRepositoryBase<Patient> repository) : base(utwk, repository)
        {
        }
    }
}

