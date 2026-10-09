namespace wt_lab3_3mvc_mamedova.Models;

public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string PassportNumber { get; set; } = "";
    public int RentedRoomId { get; set; } // Связь с комнатой
}