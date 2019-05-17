using System;
using System.Linq;
using System.Reflection;
using ContactsService.Core;
using ContactsService.Infrastructure.Entityframework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ContactsService.Infrastructure.Entityframework
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var implementedConfigTypes =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => !t.IsAbstract
                        && !t.IsGenericTypeDefinition
                        && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
                            i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in implementedConfigTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }
        }
    }
}