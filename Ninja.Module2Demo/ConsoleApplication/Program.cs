using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertNinja();
            //SimpleNinjaQueries();
            //QueryAndUpdateNinja();
            //QueryAndUpdateNinjaDisconnected();
            //RetrieveDataWithFind();
            //DeleteNinja();
            //DeleteNinjaSecondVersion();
            //InsertNinjaWithEquipment();
            //SimpleNinjaGraphQuery();
            ProjectionQuery();
            Console.ReadLine();
        }

        private static void InsertNinja()
        {
            #region Create Ninja(s)
            var ninja = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = true,
                DateOfBirth = new DateTime(2008, 7, 4),
                ClanId = 1
            };

            var ninja2 = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = true,
                DateOfBirth = new DateTime(2008, 7, 5),
                ClanId = 1
            };
            #endregion

            #region Insert Ninja to DB
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Add(ninja);
                //context.Ninjas.Add(ninja2);
                context.Ninjas.AddRange(new List<Ninja> { ninja, ninja2 });
                context.SaveChanges();
            }
            #endregion
        }

        private static void SimpleNinjaQueries()
        {

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninjas = context.Ninjas.
                    Where(n => n.DateOfBirth >= new DateTime(1984,1,1))
                    .OrderBy(n=>n.Name)
                    .Skip(1).Take(1)
                    .ToList();
                #region Alternative code
                /*
                 * Using this Name == "Raphael" hardcodes the name into the sql Query..leaving it open for SQL Injection
                 */
                //var ninjas = context.Ninjas.Where(n => n.Name == "Raphael").ToList();
                #endregion
                #region Alternative code -2
                /*
                 * Using this Name == theName will pass the name as PARAMETER to the Query
                 */
                //string theName = "Raphael";
                //var ninjas = context.Ninjas.Where(n => n.Name == theName).ToList()
                #endregion
                #region Alternative code -3
                /*
                 * Using .FirstOrDefault() will return the first element of the sequence OR null if there are no elements.
                 * Usefull in avoiding "ArgumentNullException"
                 */
                //string theName = "Raphael";
                //var ninja = context.Ninjas.Where(n => n.Name == theName).ToList().FirstOrDefault();
                #endregion
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }


                #region Alternative code
                /*
                  ~~Not Recommended~~
                  Using this way will keep the connection open until the foreach finishes. this can eat up a lot of performance/resources
                 */
                //    foreach (var ninja in context.Ninjas)
                //    {
                //        Console.WriteLine(ninja.Name);
                //    }
                #endregion

            }
        }

        private static void QueryAndUpdateNinja()
        {
            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);
                context.SaveChanges();
            }
        }

        private static void QueryAndUpdateNinjaDisconnected()
        {
            Ninja ninja;

            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using(var context= new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Attach(ninja);
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void RetrieveDataWithFind()
        {
            var keyval = 4;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.Find(keyval);
                Console.WriteLine("After Find #1: "+ninja.Name);

                var someNinja = context.Ninjas.Find(keyval);
                Console.WriteLine("After Find #2: " + someNinja.Name);
                ninja = null;
            }
        }

        private static void DeleteNinja()
        {
            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                context.Ninjas.Remove(ninja);
                context.SaveChanges();
            }
        }

        private static void DeleteNinjaSecondVersion()
        {
            Ninja ninja;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
                //context.Ninjas.Remove(ninja);
                //context.SaveChanges();
            }

            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Attach(ninja); //this is VERY Important. when a "context" object is closed he dosen't keep in mind of old objects such as ninja from below.
                //context.Ninjas.Remove(ninja);

                /*
                 * As the process below is pretty tiresome, it is easier to go like this...
                 */
                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private static void InsertNinjaWithEquipment()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = new Ninja
                {
                    Name = "Kacy Catanzaro",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1990, 1, 14),
                    ClanId = 1
                };

                var muscles = new NinjaEquipment
                {
                    Name = "Muscles",
                    Type = EquipmentType.Tool,
                };

                var spunk = new NinjaEquipment
                {
                    Name = "Spunk",
                    Type = EquipmentType.Weapon
                };

                context.Ninjas.Add(ninja);
                ninja.EquipmentOwned.Add(muscles);
                ninja.EquipmentOwned.Add(spunk);
                context.SaveChanges();
            }
        }

        private static void SimpleNinjaGraphQuery()
        {
            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                #region simply getting the ninja (we notice that we can't see his equipment)
                //var ninja = context.Ninjas
                //    .FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                #endregion

                #region [Eager loading]
                //var ninja = context.Ninjas.Include(n => n.EquipmentOwned)
                //    .FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                #endregion

                #region [Explicit Loading]
                //var ninja = context.Ninjas
                //    .FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                //Console.WriteLine("Ninja Retrieved:" + ninja.Name);

                //context.Entry(ninja).Collection(n => n.EquipmentOwned).Load();
                #endregion

                #region [Lazy Loading]
                /*
                 * For Lazy Loading to work dont forget to add 'virtual' keyword to the property you want EF to lazy load.
                      ...
                      public virtual List<NinjaEquipment> EquipmentOwned { get; set; }
                      ...
                 */
                //var ninja = context.Ninjas
                //    .FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                //Console.WriteLine("Ninja Retrieved:" + ninja.Name);

                //Console.WriteLine("Ninja Equipment Count: {0}", ninja.EquipmentOwned.Count());
                #endregion

                #region [Projections]
                //they have their own functions..look below
                #endregion
            }
        }
        private static void ProjectionQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas
                    .Select(n => new { n.Name, n.DateOfBirth, n.EquipmentOwned })
                    .ToList();
            }
        }
    }
}
