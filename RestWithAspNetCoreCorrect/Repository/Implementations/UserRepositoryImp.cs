using RestWithAspNetCore.Model.Context;
using RestWithAspNetCoreCorrect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Repository.Implementations
{
    public class UserRepositoryImp : IUserRepository
    {
        private readonly MysqlContext _context;
        public UserRepositoryImp(MysqlContext context)
        {
            _context = context;
        } 

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.login.Equals(login));
        }
    }
}
