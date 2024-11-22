using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class People
    {
        [Key] public int Id { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Name { get; set; }
        public string? Price1 { get; set; }
        public string? Price2 { get; set; }
        public string? Price { get; set; }
        public int NameService_Id { get; set; }
        public int  Material_Id { get; set; }
        public int MastSchedule_Id { get; set; }

    }
}
