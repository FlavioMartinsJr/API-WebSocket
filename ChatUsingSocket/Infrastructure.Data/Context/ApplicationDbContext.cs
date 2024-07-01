using System;
using System.Collections.Generic;
using Domain.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    public ApplicationDbContext() : base() { }
    public DbSet<TblUsuario> Usuario { get; set; }
    public DbSet<TblChat> Chat { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
