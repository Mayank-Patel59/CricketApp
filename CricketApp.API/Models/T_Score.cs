using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class T_Score
    {
        [Key]
        public int Score_ID { get; set; }
        public string Team_Name { get; set; }
        public int Matches { get; set; }

        public int Won { get; set; }
        public int Lost { get; set; }
        public int Tied { get; set; }
        public int Pts { get; set; }
    }
}