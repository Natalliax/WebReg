using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class NameService
    {
        [Key] public int Id { get; set; }
        public string Usl { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Timecomletion { get; set; }

        public override string ToString()
        {
            return Usl;
        }

    }
}
