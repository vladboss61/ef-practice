using ConsoleEFCoreLazy.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEFCoreLazy
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
                var users1 = context
                    .Users
                    .Include(user => user.Company)
                    .ThenInclude(company => company.SupplyHistory);

                var users2 = context
                    .Users
                    .Include(x => x.Company)
                    .Include(user => user.Profile);

                var companies = context.Users.Select(x => x.Company);

                foreach (var company in companies)
                {
                    Console.WriteLine(company.Name);
                }

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
            }
            Console.WriteLine("Hello World!");
        }
    }
}