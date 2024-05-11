using HouseRentAndSaleWebApp.DB.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentAndSale.DB
{
    internal class Context : DbContext
    {
        public static string con_str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\zDocs\C_Sharp\ASP NET\HouseRentAndSaleWebApp\DB\RentSaleDB.mdf"";Integrated Security=True;Connect Timeout=30";

        
        
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<ObjTypeEntity> ObjType { get; set; }
        public DbSet<ObjectEntity> Objects { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(con_str);
        }

    }
}
