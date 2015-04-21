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
    internal partial class PictureTypeConfiguration : EntityTypeConfiguration<PictureType>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public PictureTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PictureType");
            HasKey(x => x.PictureTypeId);

            Property(x => x.PictureTypeId).HasColumnName("PictureTypeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            Property(x => x.Created).HasColumnName("Created").IsRequired();
            Property(x => x.Modified).HasColumnName("Modified").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
