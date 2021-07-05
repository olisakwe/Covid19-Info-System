using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19_Info_System.Models
{
   public class ArticleModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public bool isActive { get; set; }

    }
}
