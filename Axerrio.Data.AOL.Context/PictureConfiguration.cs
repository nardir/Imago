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
    internal partial class PictureConfiguration : EntityTypeConfiguration<Picture>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public PictureConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Picture");
            HasKey(x => x.PictureKey);

            Property(x => x.PictureKey).HasColumnName("PictureKey").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PictureTypeId).HasColumnName("PictureTypeId").IsRequired();
            Property(x => x.UrlSmall).HasColumnName("UrlSmall").IsOptional().HasMaxLength(1024);
            Property(x => x.UrlMedium).HasColumnName("UrlMedium").IsOptional().HasMaxLength(1024);
            Property(x => x.UrlLarge).HasColumnName("UrlLarge").IsOptional().HasMaxLength(1024);
            Property(x => x.Deleted).HasColumnName("Deleted").IsRequired();
            Property(x => x.External).HasColumnName("External").IsRequired();
            Property(x => x.Created).HasColumnName("Created").IsRequired();
            Property(x => x.Modified).HasColumnName("Modified").IsRequired();

            HasRequired(a => a.PictureType).WithMany(b => b.Pictures).HasForeignKey(c => c.PictureTypeId);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
