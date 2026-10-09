using System;
using System.Collections.Generic;
using wt_lab3_3mvc_mamedova.Models;

namespace wt_lab3_3mvc_mamedova.Views;

public class HotelView
{
    public void ShowRooms(List<Room> rooms)
    {
        Console.WriteLine("\n=== СПИСОК КОМНАТ ===");
        if (rooms.Count == 0) { Console.WriteLine("Список комнат пуст."); return; }
        foreach (var r in rooms)
        {
            Console.WriteLine($"ID: {r.Id} | Номер: {r.Number} | Тип: {r.Type} | Цена: {r.PricePerNight} руб. | Доступна: {r.IsAvailable}");
        }
    }

    public void ShowClients(List<Client> clients)
    {
        Console.WriteLine("\n=== СПИСОК КЛИЕНТОВ ===");
        if (clients.Count == 0) { Console.WriteLine("Список клиентов пуст."); return; }
        foreach (var c in clients)
        {
            Console.WriteLine($"ID: {c.Id} | ФИО: {c.FullName} | Паспорт: {c.PassportNumber} | Занятая комната ID: {c.RentedRoomId}");
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($"[INFO]: {message}");
    }
}