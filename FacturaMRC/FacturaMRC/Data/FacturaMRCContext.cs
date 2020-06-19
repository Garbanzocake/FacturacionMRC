using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FacturacionMRC.Models;

namespace FacturaMRC.Data
{
    public class FacturaMRCContext : DbContext
    {
        public FacturaMRCContext (DbContextOptions<FacturaMRCContext> options)
            : base(options)
        {
        }

        public DbSet<FacturacionMRC.Models.Bill> Bill { get; set; }

        public DbSet<FacturacionMRC.Models.Brand> Brand { get; set; }

        public DbSet<FacturacionMRC.Models.DetailBill> DetailBill { get; set; }

        public DbSet<FacturacionMRC.Models.Employee> Employee { get; set; }

        public DbSet<FacturacionMRC.Models.Iva> Iva { get; set; }

        public DbSet<FacturacionMRC.Models.Product> Product { get; set; }

        public DbSet<FacturacionMRC.Models.TypeProduct> TypeProduct { get; set; }

        public DbSet<FacturacionMRC.Models.Customer> Customer { get; set; }
    }
}
