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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axerrio.Data.AOL.Model
{
    public partial class Picture: StatefulEntity
    {

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int PictureKey { get; internal set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int PictureTypeId { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string UrlSmall { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string UrlMedium { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string UrlLarge { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public bool Deleted { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public bool External { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTime Created { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTime Modified { get; set; }

        public virtual ICollection<PictureArticle> PictureArticles { get; set; }

        public virtual PictureType PictureType { get; set; }
        
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public Picture()
        {
            Deleted = false;
            External = false;
            Created = System.DateTime.Now;
            Modified = System.DateTime.Now;
            PictureArticles = new List<PictureArticle>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
