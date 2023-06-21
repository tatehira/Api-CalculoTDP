using static ProductsApi.Models.Enums.Enums;

namespace ProductsApi.Models
{
    public static class CompomentData
    {
        public static List<ComputerComponents> ProcessorTdpList { get; set; } = new List<ComputerComponents>
        {
            // Lista de processadores Intel Serie I
            new ComputerComponents { Cpu = "Intel Core i9-11900K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i7-11700K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i5-11600K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i9-10900K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i7-10700K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i5-10400F", TdpCpu = 65 },
            new ComputerComponents { Cpu = "Intel Core i7-9700K", TdpCpu = 95 },
            new ComputerComponents { Cpu = "Intel Core i9-12900K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i7-12700K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i5-12600K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i9-11900KF", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i7-11700KF", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i9-10900KF", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i7-10700KF", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i5-10400", TdpCpu = 65 },
            new ComputerComponents { Cpu = "Intel Core i7-9700KF", TdpCpu = 95 },

            // Lista de processadores AMD
            new ComputerComponents { Cpu = "AMD Ryzen 9 5950X", TdpCpu = 105 },
            new ComputerComponents { Cpu = "AMD Ryzen 9 5900X", TdpCpu = 105 },
            new ComputerComponents { Cpu = "AMD Ryzen 7 5800X", TdpCpu = 105 },
            new ComputerComponents { Cpu = "AMD Ryzen 5 5600X", TdpCpu = 65 },
            new ComputerComponents { Cpu = "Intel Core i5-10600K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "Intel Core i9-10850K", TdpCpu = 125 },
            new ComputerComponents { Cpu = "AMD Ryzen 7 3700X", TdpCpu = 65 },
            new ComputerComponents { Cpu = "AMD Ryzen 5 3600X", TdpCpu = 95 },
            new ComputerComponents { Cpu = "AMD Ryzen 9 5900HX", TdpCpu = 45 },
            new ComputerComponents { Cpu = "AMD Ryzen 7 5800HX", TdpCpu = 45 },
            new ComputerComponents { Cpu = "AMD Ryzen 5 5600H", TdpCpu = 45 },
            new ComputerComponents { Cpu = "AMD Ryzen 9 5950H", TdpCpu = 45 },
            new ComputerComponents { Cpu = "AMD Ryzen 7 3700XT", TdpCpu = 65 },
            new ComputerComponents { Cpu = "AMD Ryzen 5 3600XT", TdpCpu = 95 },

            // Lista de processadores Intel Serie Xeon Server
            new ComputerComponents { Cpu = "Xeon E3-1220 v3", TdpCpu = 80 },
            new ComputerComponents { Cpu = "Xeon E3-1230 v3", TdpCpu = 80 },
            new ComputerComponents { Cpu = "Xeon E5-2620 v4", TdpCpu = 85 },
            new ComputerComponents { Cpu = "Xeon E5-1650 v3", TdpCpu = 140 },
            new ComputerComponents { Cpu = "Xeon E5-2680 v4", TdpCpu = 120 },
            new ComputerComponents { Cpu = "Xeon E5-2690 v3", TdpCpu = 135 },
            new ComputerComponents { Cpu = "Xeon E3-1270 v5", TdpCpu = 80 },
            new ComputerComponents { Cpu = "Xeon E3-1230 v3", TdpCpu = 80 },
            new ComputerComponents { Cpu = "Xeon E5-2630 v4", TdpCpu = 85 },
            new ComputerComponents { Cpu = "Xeon E5-1660 v3", TdpCpu = 140 },
            new ComputerComponents { Cpu = "Xeon E5-2683 v4", TdpCpu = 120 },

            // Lista de placas de video
            new ComputerComponents { Gpu = "NVIDIA GeForce RTX 3090", TdpGpu = 350 },
            new ComputerComponents { Gpu = "NVIDIA GeForce RTX 3080", TdpGpu = 320 },
            new ComputerComponents { Gpu = "AMD Radeon RX 6800 XT", TdpGpu = 300 },
            new ComputerComponents { Gpu = "NVIDIA GeForce RTX 3070", TdpGpu = 220 },
            new ComputerComponents { Gpu = "AMD Radeon RX 6700 XT", TdpGpu = 230 },
            new ComputerComponents { Gpu = "NVIDIA GeForce RTX 3060 Ti", TdpGpu = 200 },
            new ComputerComponents { Gpu = "AMD Radeon RX 6600 XT", TdpGpu = 160 },
            new ComputerComponents { Gpu = "NVIDIA GeForce RTX 2080 Ti", TdpGpu = 250 },
            new ComputerComponents { Gpu = "AMD Radeon RX 5700 XT", TdpGpu = 225 },
            new ComputerComponents { Gpu = "NVIDIA GeForce GTX 1660 Super", TdpGpu = 125 },
            new ComputerComponents { Gpu = "AMD Radeon RX 5600 XT", TdpGpu = 150 },

            // Lista SSDs e HD
            new ComputerComponents { SSD = SSDType.Sata, TdpSSDSata = 3 },
            new ComputerComponents { SSD = SSDType.Nvme, TdpSSDNvme = 5 },
            new ComputerComponents { HDD = HDDType.HDDDesktop, TdpHDDPC = 8 },
            new ComputerComponents { HDD = HDDType.HDDNotebook, TdpHDDNote = 5 },

            //Lista de placas mãe
            new ComputerComponents { Motherboard = MotherboardEnum.MicroATX, TdpMotherboardMicro = 8 },
            new ComputerComponents { Motherboard = MotherboardEnum.MiniATX, TdpMotherboardMini = 6 },
            new ComputerComponents { Motherboard = MotherboardEnum.ATX, TdpMotherboardATX = 10 },
            new ComputerComponents { Motherboard = MotherboardEnum.ExtendedATX, TdpMotherboardExtended = 12 }
        };
       
    }
}
