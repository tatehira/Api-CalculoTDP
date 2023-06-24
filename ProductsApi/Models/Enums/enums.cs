namespace ProductsApi.Models.Enums
{
    public class Enums
    {
        public enum SSDType
        {
            Default = 0,
            Sata = 1,
            Nvme = 2
        }
        public enum HDDType
        {
            Default = 0,
            HDDDesktop = 2,
            HDDNotebook = 3
        }

        public enum MotherboardEnum
        {
            Default = 0,
            MicroATX = 1,
            MiniATX = 2,
            ATX = 3,
            ExtendedATX = 4
        }

        public enum RamEnum
        {
            Default = 0,
            Single = 1,
            Dual = 2,
            Tri = 3,
            Quad = 4
        }
    }
}
