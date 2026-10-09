namespace wt_lab3_3mvc_mamedova.Models;

public class Room
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Type { get; set; } = "";
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; } = true;
}