using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class TblTeamName
    {
        [Key]
        public int Team_ID { get; set; }
        public string Team_Name { get; set; }
        public int Matches { get; set; }
    }
}