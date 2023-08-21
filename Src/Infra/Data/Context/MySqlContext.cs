namespace api_software_documentation.src.Infra.Data.Context;

using api_software_documentation.src.Domain.Entities;
using api_software_documentation.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectCharter> ProjectCharters { get; set; }
    public DbSet<UserRequirement> UserRequirements { get; set; }
    public DbSet<FunctionalRequirement> FunctionalRequirements { get; set; }
    public DbSet<FunctionalRequirement_UserRequirement> FunctionalRequirements_UserRequirements { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProjectCharter>().HasOne(projectCharter => projectCharter.Project).WithMany(project => project.ProjectCharters).HasForeignKey(projectCharter => projectCharter.ProjectId);
        builder.Entity<UserRequirement>().HasOne(userRequirement => userRequirement.Project).WithMany(project => project.UserRequirements).HasForeignKey(userRequirement => userRequirement.ProjectId);
        builder.Entity<FunctionalRequirement>().HasOne(functionalRequirement => functionalRequirement.Project).WithMany(project => project.FunctionalRequirements).HasForeignKey(functionalRequirement => functionalRequirement.ProjectId);
        builder.Entity<FunctionalRequirement_UserRequirement>().HasOne(functionalRequirement_UserRequirement => functionalRequirement_UserRequirement.FunctionalRequirement).WithMany(functionalRequirements => functionalRequirements.FunctionalRequirements_UserRequirements).HasForeignKey(functionalRequirement_UserRequirement => functionalRequirement_UserRequirement.FunctionalRequirementId);
        builder.Entity<FunctionalRequirement_UserRequirement>().HasOne(functionalRequirement_UserRequirement => functionalRequirement_UserRequirement.UserRequirement).WithMany(userRequirements => userRequirements.FunctionalRequirements_UserRequirements).HasForeignKey(functionalRequirement_UserRequirement => functionalRequirement_UserRequirement.UserRequirementId);

    }
}
