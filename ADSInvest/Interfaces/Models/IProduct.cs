namespace ADSInvest.Interfaces.Models
{
    /// <summary> Товар на складе </summary>
    
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string UnitOfMeasurement { get; set; }
        double PricePerUnit { get; set; }
        int Quantity { get; set; }
    }
}
