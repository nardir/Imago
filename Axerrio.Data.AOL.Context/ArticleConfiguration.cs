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
    internal partial class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public ArticleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Article");
            HasKey(x => x.ArticleKey);

            Property(x => x.ArticleKey).HasColumnName("ArticleKey").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(255);
            Property(x => x.LongDescription).HasColumnName("LongDescription").IsOptional().HasMaxLength(4000);
            Property(x => x.Code).HasColumnName("Code").IsRequired().HasMaxLength(50);
            Property(x => x.Active).HasColumnName("Active").IsRequired();
            Property(x => x.Deleted).HasColumnName("Deleted").IsRequired();
            Property(x => x.Created).HasColumnName("Created").IsRequired();
            Property(x => x.Modified).HasColumnName("Modified").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
