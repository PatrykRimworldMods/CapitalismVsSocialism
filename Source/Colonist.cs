namespace CapitalismVsSocialism;

public class Colonist
{
    public string Name { get; set; }
    public bool IsEntrepreneur { get; set; }
    public Stockpile PersonalStockpile { get; set; }

    public Colonist(string name)
    {
        Name = name;
        IsEntrepreneur = false;
        PersonalStockpile = new Stockpile(name); // Each colonist gets their own stockpile
    }
}