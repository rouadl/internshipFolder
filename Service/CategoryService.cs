
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using GP.Data;
using GP.Data.Infrastructure;
using GP.Domain.Entities;
using GP.ServicePattern;


namespace GP.Service
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork utwk, IRepositoryBase<Category> repository) : base(utwk, repository)
        {
        }
    }
}
