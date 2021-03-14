using System.ComponentModel.DataAnnotations;

namespace CharacterRandomizer.Models
{
    public class Name
    {
        [Key]
        public int Id { get; set; }
        public int? RaceId { get; set; }
        public virtual Race Race {get;set;}

        public string FamilyName { get; set; }
        public string PersonalName { get; set; }

    }
}