using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertNinja();
            //SimpleNinjaQueries();
            //QueryAndUpdateNinja();
            QueryAndUpdateNinjaDisconnected();
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
                context.Entry(ninja).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
