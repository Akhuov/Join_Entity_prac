using Join_Entity_prac.Models;
using Microsoft.EntityFrameworkCore;

namespace Join_Entity_prac.DataBase
{
    public class SeedData
    {
        DBContext db = new DBContext();
        public SeedData()
        {
            //db.Database.EnsureCreated();
            db.Database.Migrate();
            AddGroup();
        }

        void AddGroup()
        {
            string Company_1 = "Apple";
            string Company_2 = "Samsung";
            string Company_3 = "Huawei";


            string User_1 = "Javoxir";
            string User_2 = "Hadiz";
            string User_3 = "Kamron";
            string User_4 = "Amir";
            string User_5 = "Atxam";

            if (!db.Jobs.Any(l => l.Name.Equals(Company_1)))
            {
                db.Add(new Job()
                {
                    //Id = 1,
                    Name = Company_1,
                });
            }

            if (!db.Jobs.Any(l => l.Name.Equals(Company_2)))
            {
                db.Add(new Job()
                {
                    //Id = 2,
                    Name = Company_2
                });
            }

            if (!db.Jobs.Any(l => l.Name.Equals(Company_3)))
            {
                db.Add(new Job()
                {
                    //Id = 2,
                    Name = Company_3
                });
            }


            if (!db.Jobs.Any(l => l.Name.Equals(Company_3)))
            {
                db.Add(new Job()
                {
                    //Id = 2,
                    Name = Company_3
                });
            }



            //---Users---

            if (!db.Users.Any(l => l.Name.Equals(User_1)))
            {
                db.Add(new User()
                {
                    Name = User_1,
                    Age = 21,
                    JobId = 3
                });
            }

            if (!db.Users.Any(l => l.Name.Equals(User_2)))
            {
                db.Add(new User()
                {
                    Name = User_2,
                    Age = 23,
                    JobId = 1
                });
            }

            if (!db.Users.Any(l => l.Name.Equals(User_3)))
            {
                db.Add(new User()
                {
                    Name = User_3,
                    Age = 18,
                    JobId = 1
                });
            }

            if (!db.Users.Any(l => l.Name.Equals(User_4)))
            {
                db.Add(new User()
                {
                    Name = User_4,
                    Age = 26,
                    JobId = 2
                });
            }

            if (!db.Users.Any(l => l.Name.Equals(User_5)))
            {
                db.Add(new User()
                {
                    Name = User_5,
                    Age = 30,
                    JobId = 3
                });
            }
            db.SaveChanges();
        }
    }
}
