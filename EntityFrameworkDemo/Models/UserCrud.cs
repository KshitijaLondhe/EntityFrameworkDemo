using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Models
{
    public class UserCrud
    {
        private readonly ApplicationDbContext db;

        

        public UserCrud(ApplicationDbContext db)
        {
            this.db = db;
        }


        //public User ValidateUser(User user)
        //{
            
            
        //}
        public int AddUser(User user)
        {
            int result = 0;
            db.Users.Add(user);
            result = db.SaveChanges();
            return result;
        }

    }
}
