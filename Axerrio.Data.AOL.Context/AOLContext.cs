using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Data.Entity;
using System.Data.Common;
using System.Data.Entity;

namespace Axerrio.Data.AOL.Context
{
    //[DbConfigurationType(typeof(ContextDbConfiguration))]
    public class AOLContext : Context<AOLContext>
    {
        public AOLContext()
            : base("Name=AOL")
        {
        }

        public AOLContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new PictureConfiguration());
            modelBuilder.Configurations.Add(new PictureArticleConfiguration());
            modelBuilder.Configurations.Add(new PictureTypeConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
            modelBuilder.Configurations.Add(new StockTypeConfiguration());
        }
    }
}
