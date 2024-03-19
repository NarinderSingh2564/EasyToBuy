using EasyToBuy.Data.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Repository.Abstract
{
    public interface IAccountRepository
    {
        List<User> GetUsers();
    }
}
