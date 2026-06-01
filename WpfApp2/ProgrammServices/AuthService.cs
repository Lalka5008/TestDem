using Microsoft.EntityFrameworkCore;
using WpfApp2.Data;
using WpfApp2.Model;

namespace WpfApp2.ProgrammServices
{
    internal class AuthService
    {
        public User TryAuth(string login, string password)
        {
            using (var context = new TestDemContext())
            {
                User user = context.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null) return null;
                return user;
            }
        }
    }
}
