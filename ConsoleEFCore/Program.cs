using ConsoleEFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConsoleEFCore
{
    public sealed class Program
    {
        #region
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.CreateTable(
        //        name: "ProductVersion",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false),
        //            Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductVersionId", x => x.Id);
        //        });
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable("ProductVersion");
        //}
        #endregion

        internal static async Task Main(string[] args)
        {
            await using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                context
                    .Companies
                    .Add(new Company
                    {
                        Id = 3999,
                        FoundationDate = DateTime.UtcNow,
                        Name = "A-Code",
                        Revenue = 2500
                    });


                context
                    .UserProfiles
                    .Add(new UserProfile
                    {
                         Id = 2000,
                         UserId = 2777,
                         About = "In Code User Profile",
                         ImageUrl = "123"
                    });

                context
                    .Users
                    .Add(new User
                    {
                        Id = 2777,
                        CompanyId = 3999,
                        FirstName = "FirstName10 SaveChangesAsync",
                        LastName = "LastName SaveChangesAsync",
                        HiredDate = DateTime.UtcNow,
                    });

                await context.SaveChangesAsync();

                var explicitUsers = context.Users;

                foreach (var user in explicitUsers)
                {
                    await context
                        .Entry(user)
                        .Reference(b => b.Company)
                        .LoadAsync();
                }

                var companies2 = context.Companies;
                foreach (var comp in companies2)
                {
                    await context.SupplyHistories
                        .Where(x => x.SupplyHistoryId == comp.Id)
                        .LoadAsync();

                    await context
                        .Entry(comp)// Explicit Loading.
                        .Collection(b => b.SupplyHistory)
                        .LoadAsync();
                }

                foreach (var comp in companies2)
                {
                    IQueryable<SupplyHistory> supps = context
                        .Entry(comp) // Explicit Loading.
                        .Collection(b => b.SupplyHistory)
                        .Query();
                }


                var secondUser = context.Users.SingleOrDefault(x => x.Id == 2);

                if (secondUser is not null)
                {
                    secondUser.LastName = "New FirstName - secondUser";
                }

                context.SaveChanges();
                IQueryable<User> users1 = context.Users.Where(x => x.FirstName.Contains("A"));
                
                var sqlQueryable = users1.ToSql();
                var newWay = users1.ToQueryString();

                Console.WriteLine(sqlQueryable);

                IEnumerable<User> users2 = context.Users.AsEnumerable().Where(x => x.FirstName.Contains("A")); // SELECT * FROM dbo.Products 

                DbSet<Product> products = context.Products; // SELECT * FROM dbo.Products
                IQueryable<Product> products2 = context.Products.Where(x => x.Name.Equals("Audi")); // SELECT * FROM dbo.Products as p WHERE p.Name = "Audi"

                //var userProfiles = context.UserProfiles.ToList();
            }
            Console.WriteLine("Hello World!");
        }
    }
}