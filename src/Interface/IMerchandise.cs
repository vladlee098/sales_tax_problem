namespace src.Interface
{
    public interface IMerchandise
    {
        MerchandiseTypes MerchandiseType { get; }
        string Name { get; }
        int Amount { get; }
        decimal Price { get; }
        bool Import { get; }
    }
}
