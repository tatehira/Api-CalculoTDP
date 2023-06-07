using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProductsApi.Models
{
    [Table("ComputerComponent")]
    public class ComputerComponents
    {
        public Guid Id { get; set; }
        public string Cpu { get; set; }
        public int TdpCpu { get; set; }
        public string Gpu { get; set; }
        public int TdpGpu { get; set; }
        public string Motherboard { get; set; }
        public int TdpMotherboard { get; set; }
        public string Ram { get; set; }
        public int TdpRam { get; set; }
        public int QntRam { get; set; }
        public SSDCategory SSD { get; set; }
        public int TdpSSD { get; set; }
        public string HDD { get; set; }
        public int TdpHDD { get; set; }
    }

    public enum SSDCategory
    {
        Sata = 0,
        Nvme = 1,
    }
}
