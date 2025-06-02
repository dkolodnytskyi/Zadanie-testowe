namespace ZadanieTestowe.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Campaign Campaign { get; set; }
}