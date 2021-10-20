using ADSInvest.Interfaces.Models;

namespace ADSInvest.Models
{
    public sealed class ProductModel : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double PricePerUnit { get; set; }
        public int Quantity { get; set; }

        public string FormatQuantityString { get; set; }
        public string FormatPricePerUnitString { get; set; }
    }
}
