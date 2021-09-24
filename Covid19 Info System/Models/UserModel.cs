using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19_Info_System.Models
{
    public class UserModel
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Password { get; set; }
        public  bool IsActive { get; set; }
        public  string Role { get; set; }
    }
}
