using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterRandomizer.Models
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public string Name {get;set;}
        public virtual ICollection<PersonalName> PersonalNames {get;set;}
        public virtual ICollection<FamilyName> FamilyNames {get;set;}

        public Race()
        {
            PersonalNames = new HashSet<PersonalName>();
            FamilyNames = new HashSet<FamilyName>();
        }

    }
}