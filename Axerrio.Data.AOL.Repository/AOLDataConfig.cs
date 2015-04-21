using Axerrio.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axerrio.Data.AOL.Repository
{
    public static class AOLDataConfig
    {
        public static void Configure()
        {
            ContextDbConfiguration.SetExecutionStrategy(new SqlAzureExecutionStrategy());
        }
    }
}
