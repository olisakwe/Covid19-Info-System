using SQLite;
using System;

namespace Covid19_Info_System.Models
{
    public class Item
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}