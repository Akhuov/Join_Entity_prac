using Join_Entity_prac.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Join_Entity_prac
{
    public class Servis
    {
        public static void JoinFunc()
        {
            using (DBContext db = new DBContext())
            {
                var users = db.Users.Join(db.Jobs,
                    u => u.JobId,
                    c => c.Id,
                    (u, c) => new
                    {
                        Name = u.Name,
                        Company = c.Name,
                        Age = u.Age
                    });
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
            }
        }

        public static void IncludeFunc()
        {
            using (DBContext db = new DBContext())
            {
                var users = (from user in db.Users.Include(p => p.Jobs)
                             where user.JobId == 1
                             select user).ToList();

                foreach (var user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Jobs.Name}");
            }
        }

        public static void SelectUserByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                var users = context.Users.Select(u=>u).Where(u => u.JobId == id).ToList();
                if (users.Count != 0)
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.Name} ({user.Age}) - {user.JobId}");
                    }
                }
                else { Console.WriteLine("User not found!"); }
            }
        }


        public static void GroupJoinFunc()
        {
            using (DBContext db = new DBContext())
            {
                var groups = from u in db.Users group u by u.Jobs.Name into g 
                             select new
                             {
                                 g.Key,
                                 Count = g.Count()
                             };
                foreach (var group in groups)
                {
                    Console.WriteLine($"{group.Key} - {group.Count}");
                }
            }
        }

        public static void IncludeFuncWithAsnotracking()
        {
            using (DBContext db = new DBContext())
            {
                var users = (from user in db.Users.Include(p => p.Jobs)
                             select user).AsNoTracking().ToList();

                foreach (var user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Jobs.Name}");
            }
        }

    }
}
