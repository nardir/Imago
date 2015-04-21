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
    internal partial class PictureArticleConfiguration : EntityTypeConfiguration<PictureArticle>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public PictureArticleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PictureArticle");
            HasKey(x => new { x.PictureKey, x.ArticleKey });

            Property(x => x.PictureKey).HasColumnName("PictureKey").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ArticleKey).HasColumnName("ArticleKey").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SortOrder).HasColumnName("SortOrder").IsOptional();
            Property(x => x.Created).HasColumnName("Created").IsRequired();

            HasRequired(a => a.Picture).WithMany(b => b.PictureArticles).HasForeignKey(c => c.PictureKey);
            HasRequired(a => a.Article).WithMany(b => b.PictureArticles).HasForeignKey(c => c.ArticleKey);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
