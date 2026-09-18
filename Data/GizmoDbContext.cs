using Microsoft.EntityFrameworkCore;
using GizmoApp.Models;

namespace GizmoApp.Data;

public class GizmoDbContext(DbContextOptions<GizmoDbContext> options)
    : DbContext(options)
{
    public DbSet<Opinion> Opinions => Set<Opinion>();
}