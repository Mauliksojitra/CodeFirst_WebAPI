using Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Application.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ApplicationDBContext")
        {
            Database.SetInitializer<ApplicationDBContext>(null);

            this.Configuration.LazyLoadingEnabled = true;
        }

        #region DbContext

        public DbSet<UserMaster> UserMaster { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDBContext>
        {
            protected override void Seed(ApplicationDBContext context)
            {
                #region UserMaster

                IList<UserMaster> defaultUserMaster = new List<UserMaster>();

                defaultUserMaster.Add(new UserMaster()
                {
                    Id = Guid.Parse("76cc37a4-bb83-4c4c-92d8-d433c023d3b6"),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    FirstName = "Maulik",
                    LastName = "Sojitra",
                    EmailId = "Maulik@domainName.com",
                    IsActive = true,
                    IsAdmin = true
                });

                foreach (UserMaster userMaster in defaultUserMaster)
                    context.UserMaster.Add(userMaster);

                #endregion

                base.Seed(context);
            }
        }
    }
}

