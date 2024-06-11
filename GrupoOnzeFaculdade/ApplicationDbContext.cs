using GrupoOnzeFaculdade.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Xml;

public class ApplicationDbContext : DbContext
{
    public DbSet<CadastroAluno> cadastro_aluno { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CadastroAluno>().ToTable("cadastro_aluno");
    }
}