// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using Axerrio.Data.Entity;
using Axerrio.Data.AOL.Model;
using System.CodeDom.Compiler;
using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace Axerrio.Data.AOL.Context
{
    internal partial class StockConfiguration : EntityTypeConfiguration<Stock>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public StockConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Stock");
            HasKey(x => x.StockKey);

            Property(x => x.StockKey).HasColumnName("StockKey").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.StockTypeId).HasColumnName("StockTypeId").IsRequired();
            Property(x => x.LogisticIdentifier).HasColumnName("LogisticIdentifier").IsOptional().HasMaxLength(50);
            Property(x => x.Created).HasColumnName("Created").IsRequired();
            Property(x => x.Modified).HasColumnName("Modified").IsRequired();
            Property(x => x.ArticleKey).HasColumnName("ArticleKey").IsRequired();

            HasRequired(a => a.StockType).WithMany(b => b.Stocks).HasForeignKey(c => c.StockTypeId);
            HasRequired(a => a.Article).WithMany(b => b.Stocks).HasForeignKey(c => c.ArticleKey);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
