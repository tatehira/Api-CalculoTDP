namespace ProductsApi.Models.Enums
{
    public class Enums
    {
        public enum SSDType
        {
            Sata = 0,
            Nvme = 1,
        }

        public enum RotuloCategory
        {
            Upgrade = 0,
            Novo = 1,
        }

        public enum HDDType
        {
            HDDDesktop = 0,
            HDDNotebook = 0
        }

        public enum MotherboardEnum
        {
            MicroATX = 0,
            MiniATX = 1,
            ATX = 2,
            ExtendedATX = 3

        }
    }
}
