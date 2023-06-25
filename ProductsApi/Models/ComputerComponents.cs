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


        // TDPs
        public int TdpCpu { get; set; }
        public int TdpGpu { get; set; }

        public int TdpRamSingles { get; set; }
        public int TdpRamDual { get; set; }
        public int TdpRamTri { get; set; }
        public int TdpRamQuad { get; set; }

        public int TdpHDDPC { get; set; }
        public int TdpHDDNote { get; set; }
        public int TdpSSDSata { get; set; }
        public int TdpSSDNvme { get; set; }

        public int TdpDefault { get; set; }
        public int TdpTotal { get; set; }

        public int TdpMotherboardMini { get; set; }
        public int TdpMotherboardMicro { get; set; }
        public int TdpMotherboardATX { get; set; }
        public int TdpMotherboardExtended { get; set; }
    }
}
