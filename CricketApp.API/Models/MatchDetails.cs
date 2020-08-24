using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class MatchDetails
    {
        [Key]
        public int Match_Id { get; set; }
        public string Team_Name { get; set; }

        public int Winner_Id { get; set; }

        public int Looser_Id { get; set; }

        public int Man_Match_Id { get; set; }

        public int Bowler_Match_Id { get; set; }

        public int Best_Fielder_Id { get; set; }
        

    }
}