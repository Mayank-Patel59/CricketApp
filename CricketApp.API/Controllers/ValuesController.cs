using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Controllers.Models.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{ 
    [Route("api/Values/[action]")]
    [ApiController]    
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context){
            _context = context;
        }
        //Get Api/Values
        [HttpGet]
        public async Task<ActionResult<List<TblTeamName>>> GetCountries() 
        {             
            List<TblTeamName> tblTeamName = await _context.Team_Profile.ToListAsync ();
            return Ok (tblTeamName);
        }

        [HttpGet]
        public async Task<ActionResult<List<T_Score>>> GetScore() 
        {             
            List<T_Score> t_Score = await _context.T_Score.ToListAsync ();
            return Ok (t_Score);
        }

        [HttpGet]
        public async Task<ActionResult<List<MatchDetails>>> GetMatches() 
        {             
            var matches = (from ma in _context.Match_Details

                            join pe in _context.Team_Profile
                            on ma.Winner_Id equals pe.Team_ID

                            join pe1 in _context.Team_Profile
                            on ma.Looser_Id equals pe1.Team_ID

                            join pa in _context.Player_Profile
                            on ma.Man_Match_Id equals pa.Player_ID

                            join pa1 in _context.Player_Profile
                            on ma.Best_Fielder_Id equals pa1.Player_ID  

                            join pa2 in _context.Player_Profile
                            on ma.Bowler_Match_Id equals pa2.Player_ID
                            
                            select new {
                                Match_Id = ma.Match_Id,
                                Team_Name = ma.Team_Name,
                                Winner_Id = pe.Team_Name,
                                Looser_Id = pe1.Team_Name,
                                Man_Match_Id = pa.Name,
                                Bowler_Match_Id = pa2.Name,
                                Best_Fielder_Id = pa1.Name
                            }
                            );

            return Ok(matches);                
        }


        [HttpGet]
        public async Task<ActionResult<List<PlayerProfile>>> GetPlayers() 
        {             
            var players = (from pl in _context.Player_Profile
                            join te in _context.Team_Profile
                            on pl.Team_ID equals te.Team_ID
                            
                            select new { Player_ID = pl.Player_ID,
                                        Name = pl.Name,
                                        DOB = pl.DOB,
                                        Age = pl.Age,
                                        Team = te.Team_Name,
                                        P_Role = pl.P_Role,
                                        R_Role = pl.R_Role });

            return Ok(players);                            
        } 

        //Get api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //Get api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {            
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}