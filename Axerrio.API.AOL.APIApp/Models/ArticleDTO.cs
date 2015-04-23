using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axerrio.API.AOL.APIApp.Models
{
    public class ArticleDTO
    {
        public ArticleDTO()
        {
            Pictures = new List<PictureDTO>();
        }
        public int ArticleKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public List<PictureDTO> Pictures { get; set; }
    }
}