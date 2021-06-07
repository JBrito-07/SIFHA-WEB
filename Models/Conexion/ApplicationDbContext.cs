using Microsoft.EntityFrameworkCore;
using SIFHA_WEB.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SIFHA_WEB.Models.Conexion
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
       
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
