using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterRandomizer.DataContexts;
using CharacterRandomizer.Models;
using CharacterRandomizer.Common;

//TODO: AASIMAR TAKE HUMAN NAMES
//TODO: FIRBOLGS TAKE ELVEN NAMES
//TODO: GENASI TAKE HUMAN NAMES 
//TODO: GENASI SUBRACE THEMATIC NAMES
//TODO: GOLIATH NICKNAMES
//TODO: ELF SUBRACE NAMES
//TODO: HALF-ELF TAKE ELF OR HUMAN NAMES
//TODO: HALF-ORC TAKE ORC OR HUMAN NAMES

namespace CharacterRandomizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Names
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Name>>> GetRandomNames(int? raceId, int? numberOfResults)
        {
            List<Name> Results = new List<Name>();
            int ResultSetCount = numberOfResults ?? 10;
            for(int i = 0; i < ResultSetCount; i++)
            {
                Results.Add(GenerateRandomName(raceId));
            }
            return Results;
        }

              // GET: api/Names/5
        [HttpGet("{raceId}")]
        public async Task<ActionResult<Name>> GetRandomName(int? raceId)
        {
            if(raceId != null && raceId > 0)
            {
                var race = await _context.Races.FindAsync(raceId);

                if (race == null)
                {
                    return NotFound();
                }
            }

            return GenerateRandomName(raceId);
        }

        private Name GenerateRandomName(int? raceId)
        {
            Name Result = new Name() {RaceId = raceId};
            IEnumerable<PersonalName> PersonalNames = _context.PersonalNames;
            IEnumerable<FamilyName> FamilyNames = _context.FamilyNames;

            if(raceId != null && raceId > 0)
            {
                PersonalNames = _context.PersonalNames.Where(p => p.RaceId == raceId);
                FamilyNames = _context.FamilyNames.Where(f => f.RaceId == raceId);
            }

            Result.PersonalName = PersonalNames.RandomElement().Value;
            Result.FamilyName = FamilyNames.RandomElement().Value;

            return Result;
        }

    }
}
