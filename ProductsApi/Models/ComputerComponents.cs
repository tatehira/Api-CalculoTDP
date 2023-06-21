﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using static ProductsApi.Models.Enums.Enums;

namespace ProductsApi.Models
{
    [Table("ComputerComponent")]
    public class ComputerComponents
    {
        // Componentes
        public int Id { get; set; }
        public int QntRam { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Ram { get; set; }

        // TDPs
        public int TdpCpu { get; set; }
        public int TdpGpu { get; set; }
        public int TdpRam { get; set; }
        public int TdpMotherboardMini { get; set; }
        public int TdpMotherboardMicro { get; set; }
        public int TdpMotherboardATX { get; set; }
        public int TdpMotherboardExtended { get; set; }
        public int TdpHDD { get; set; }
        public int TdpSSD { get; set; }
        public int TdpTotal { get; set; }

        // Enums
        public MotherboardEnum Motherboard { get; set; }
        public HDDType HDD { get; set; }
        public SSDType SSD { get; set; }
        public RotuloCategory RotuloCategory { get; set; }
    }
}
