namespace src.Interface
{
    public interface ILineParser
    {
        int GetAmount();
        string GetName();
        string GetFullName();
        decimal GetPrice();
        bool IsImport();
    }
}
