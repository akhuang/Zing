using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Data;
using Zing.Modules.Customer.Models;

namespace Zing.Modules.Customer.Services
{
    public interface ICustomerService : IService<CustomerEntity>, IDependency
    {
    }

    public class CustomerService : ServiceBase<CustomerEntity>, ICustomerService
    {
        private readonly IRepository<CustomerEntity> _rep;
        public CustomerService(IRepository<CustomerEntity> rep) : base(rep)
        {
            _rep = rep;
        }

        //public IEnumerable<CustomerEntity> GetList
    }
}
