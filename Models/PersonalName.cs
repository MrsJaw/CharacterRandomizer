using System.ComponentModel.DataAnnotations;

namespace CharacterRandomizer.Models
{
    public class PersonalName
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public int? RaceId {get;set;}
        protected virtual Race Race {get;set;}
    }
}