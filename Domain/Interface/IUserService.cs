
using System.Collections.Generic;
using myApi.Domain.Entities;

namespace myApi.Domain.Interface
{
    public interface IUserService
    {
        User Authenticate(string email);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
