using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Axerrio.Data.AOL.Model.DTO;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;
using Axerrio.Images.AOL;

namespace Axerrio.WebJobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }

        
        
    }
}
