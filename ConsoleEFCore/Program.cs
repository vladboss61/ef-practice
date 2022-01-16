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
            using (var context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                IQueryable<User> users1 = context.Users.Where(x => x.FirstName.Contains("A"));
                var sqlQueriable = users1.ToSql();
                Console.WriteLine(sqlQueriable);
                DbSet<Product> products = context.Products; // SELECT * FROM dbo.Products
                IQueryable<Product> products2 = context.Products.Where(x => x.Name.Equals("Audi")); // SELECT * FROM dbo.Products as p WHERE p.Name = "Audi"

                //var userProfiles = context.UserProfiles.ToList();
            }
            Console.WriteLine("Hello World!");
        }
    }
}