using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class Material
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }

        public override string ToString() => Name;
    }
}
