using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class PlayerProfile
    {
        [Key]
        public int Player_ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public int Team_ID { get; set; }
        public string P_Role { get; set; }
        public string R_Role { get; set; }
    }
}