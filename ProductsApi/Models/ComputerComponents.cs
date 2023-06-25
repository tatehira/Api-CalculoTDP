using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
    [Table("ComputerComponent")]
    public class ComputerComponents
    {
        // Componentes
        public int Id { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Ram { get; set; }
        public string HDD { get; set; }
        public string SSD { get; set; }
        public string Motherboard { get; set; }
        public int TdpDefault { get; set; } = 0;
        public int TdpTotal { get; set; }
    }
}
