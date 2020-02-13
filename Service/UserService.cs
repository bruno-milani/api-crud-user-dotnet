using System;
using System.Collections.Generic;
using System.Linq;
using myApi.Data.Context;
using myApi.Domain.Entities;

namespace myApi.Service
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

    public class UserService : IUserService
    {
        private MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public User Authenticate(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return null;

                var user = _context.Users.SingleOrDefault(x => x.Email == email);

                if (user == null)
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var user = _context.Users.Where(x => x.Deleted_at == null);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetById(int id)
        {
            try
            {
                var userId = _context.Users.Where(x => x.Deleted_at == null && x.Id == id).FirstOrDefault();

                return userId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(User userParam)
        {
            try
            {
                var user = _context.Users.Find(userParam.Id);

                user.Name = userParam.Name;
                user.DateOfBird = userParam.DateOfBird;
                user.Sex = userParam.Sex;

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    user.Deleted_at = DateTime.UtcNow;

                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
