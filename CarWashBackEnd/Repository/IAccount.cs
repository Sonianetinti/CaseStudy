using CarWashBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashBackEnd.Repository
{
    internal interface IAccount
    {
        UserTable VerifyLogin(string Email, string Password);
    }
}
