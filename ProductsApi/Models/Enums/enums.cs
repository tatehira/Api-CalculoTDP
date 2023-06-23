namespace ProductsApi.Models.Enums
{
    public class Enums
    {
        public enum SSDType
        {
            Sata = 0,
            Nvme = 1,
        }
        public enum HDDType
        {
            HDDDesktop = 0,
            HDDNotebook = 1
        }

        public enum MotherboardEnum
        {
            MicroATX = 0,
            MiniATX = 1,
            ATX = 2,
            ExtendedATX = 3
        }

        public enum RamEnum
        {
            Single = 0,
            Dual = 1,
            Tri = 2,
            Quad = 3
        }
    }
}
