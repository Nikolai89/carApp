using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarApplication.Models
{
    public class CarContext : DbContext
    {
        public CarContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
    public class CarDbInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "user" });
            db.Users.Add(new User
            {
                Id = 1,
                Email = "somemail@gmail.com",
                Password = "123456",
                Age = 25,
                RoleId = 1,
            });

            db.Cars.Add(new Car { Model = "Nissan", Color = "Black", TypeTransmission = "Manual", TypeEngine = "Disel", Price = 20000 });
            db.Cars.Add(new Car { Model = "Toyota", Color = "White", TypeTransmission = "Automatic", TypeEngine = "Gasoline", Price = 25000 });
            db.Cars.Add(new Car { Model = "Ford", Color = "Red", TypeTransmission = "Manual", TypeEngine = "Disel", Price = 20000 });
            db.Cars.Add(new Car { Model = "Subaru", Color = "Green", TypeTransmission = "Manual", TypeEngine = "Gasoline", Price = 20000 });
            db.Cars.Add(new Car { Model = "Mersedes", Color = "Blue", TypeTransmission = "Manual", TypeEngine = "Disel", Price = 25000 });
            db.Cars.Add(new Car { Model = "Honda", Color = "Gray", TypeTransmission = "Automatic", TypeEngine = "Gasoline", Price = 20000 });
            db.Cars.Add(new Car { Model = "Audi", Color = "Green", TypeTransmission = "Manual", TypeEngine = "Disel", Price = 30000 });
            db.Cars.Add(new Car { Model = "Kia", Color = "Yellow", TypeTransmission = "Automatic", TypeEngine = "Gasoline", Price = 20000 });
            db.Cars.Add(new Car { Model = "Mazda", Color = "Black", TypeTransmission = "Automatic", TypeEngine = "Disel", Price = 15000 });

            base.Seed(db);
        }
    }
}