using ConsoleEFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        internal static void Main(string[] args)
        {
            using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                var fixedUser = context.Users.ToArray();

                var allUsers = context.Users.Include(x => x.Company);

                context.Users.Join(context.Companies, user => user.CompanyId,
                    company => company.Id,
                    (user, company) => new { User = user, Company = company });

                var firsUser = context.Users.SingleOrDefault(x => x.Id == 1);

                if (firsUser is not null)
                {
                    firsUser.LastName = "New FirstName - firsUser";
                }

                var secondUser = context.Users.SingleOrDefault(x => x.Id == 2);

                if (secondUser is not null)
                {
                    secondUser.LastName = "New FirstName - secondUser";
                }

                context.SaveChanges();
                IQueryable<User> users1 = context.Users.Where(x => x.FirstName.Contains("A"));
                
                var sqlQueriable = users1.ToSql();
                var newWay = users1.ToQueryString();

                Console.WriteLine(sqlQueriable);

                IEnumerable<User> users2 = context.Users.AsEnumerable().Where(x => x.FirstName.Contains("A")); // SELECT * FROM dbo.Products 

                DbSet<Product> products = context.Products; // SELECT * FROM dbo.Products
                IQueryable<Product> products2 = context.Products.Where(x => x.Name.Equals("Audi")); // SELECT * FROM dbo.Products as p WHERE p.Name = "Audi"

                //var userProfiles = context.UserProfiles.ToList();
            }
            Console.WriteLine("Hello World!");
        }
    }
}