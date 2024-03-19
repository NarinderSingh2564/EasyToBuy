using EasyToBuy.Data.DBClasses;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Repository.Concrete
{
    public class AccountRepository:IAccountRepository
    {
         
        public List<User> GetUsers()
        {
            using (AccountService accountService = new AccountService())
            {
                return accountService.GetUsers();
            }
        }

    }
}
