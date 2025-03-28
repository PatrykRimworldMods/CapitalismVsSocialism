namespace CapitalismVsSocialism;

public class Stockpile
{
    public string Owner { get; set; }
    public int Resources { get; set; }

    public Stockpile(string owner)
    {
        Owner = owner;
        Resources = 0; // Initial stockpile starts empty
    }
}