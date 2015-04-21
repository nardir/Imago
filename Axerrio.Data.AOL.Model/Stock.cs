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
    public partial class Stock: StatefulEntity
    {

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int StockKey { get; internal set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int StockTypeId { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string LogisticIdentifier { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTime Created { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTime Modified { get; set; }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int ArticleKey { get; set; }

        public virtual Article Article { get; set; }
        public virtual StockType StockType { get; set; }
        
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public Stock()
        {
            Created = System.DateTime.Now;
            Modified = System.DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
