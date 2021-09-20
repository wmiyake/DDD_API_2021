﻿using Entidades.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { 
        }

        public DbSet<Noticia> Noticia { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            string strcon = "Data Source=WINDEV2106EVAL,1433;Initial Catalog=AULA_API_DDD_2021;Integrated Security=False;User ID=sa;Password=123456finan;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                //"Data Source = DESKTOP - HVNTI80\\DESENVOLVIMENTO; Initial Catalog = AULA_API_DDD_2021; Integrated Security = False; User ID = sa; Password = 1234; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = False";
            return strcon;
        }
    }
}
