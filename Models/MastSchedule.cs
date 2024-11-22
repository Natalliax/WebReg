using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class MastSchedule
    {
        [Key]public int Id { get; set; }
        public string? Master { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public bool IsRegistered { get; set; } // Новое свойство


        public override string ToString() => Master;
    }
}
