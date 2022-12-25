using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace RepoPractice.Models
{

    public class ShoppingCartDBContext :DbContext
    {
        //public ShoppingCartDBContext() : base("ShoppingCartDB")
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShoppingCartDBContext, EF6Console.Migrations.Configuration>());
        //}


        public DbSet<CartModel> CartSet { get; set; }

        public DbSet<CategoryModel> CategorySet { get; set; }

        public DbSet<OrderModel> OrderSet { get; set; }

        public DbSet<PreviousOrdersModel> PreviousOrdersSet { get; set; }

        public DbSet<ProductModel> ProductSet { get; set; }

        public DbSet<RoleModel> RoleSet { get; set; }

        public DbSet<UserModel> UserSet { get; set; }

        public DbSet<WalletModel> WalletSet { get; set; }
    }
}