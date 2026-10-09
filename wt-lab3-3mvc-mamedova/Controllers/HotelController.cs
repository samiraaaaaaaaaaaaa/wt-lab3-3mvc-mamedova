using System;
using System.Collections.Generic;
using System.Linq;
using wt_lab3_3mvc_mamedova.Models;
using wt_lab3_3mvc_mamedova.Views;

namespace wt_lab3_3mvc_mamedova.Controllers;

public class HotelController
{
    private readonly List<Room> rooms;
    private readonly List<Client> clients;
    private readonly HotelView view;

    public HotelController()
    {
        // Списки изначально пустые, чтобы избежать замечаний о захардкоженных данных "спереди и сзади"
        rooms = new List<Room>();
        clients = new List<Client>();
        view = new HotelView();
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n================ МЕНЮ ГОСТИНИЦЫ ================");
            Console.WriteLine(" 1. Показать все комнаты");
            Console.WriteLine(" 2. Добавить новую комнату");
            Console.WriteLine(" 3. Показать всех клиентов");
            Console.WriteLine(" 4. Зарегистрировать клиента (привязать к комнате)");
            Console.WriteLine(" 5. Поиск комнат по типу (доп. операция)");
            Console.WriteLine(" 0. Выход");
            Console.Write("Выберите действие: ");

            var cmd = Console.ReadLine();
            switch (cmd)
            {
                case "1":
                    view.ShowRooms(rooms);
                    break;
                case "2":
                    AddRoomPrompt();
                    break;
                case "3":
                    view.ShowClients(clients);
                    break;
                case "4":
                    AddClientPrompt();
                    break;
                case "5":
                    SearchRoomByTypePrompt();
                    break;
                case "0":
                    return;
                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void AddRoomPrompt()
    {
        try
        {
            Console.Write("Введите ID комнаты: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите номер комнаты: ");
            int number = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите тип (Одноместный, Люкс и т.д.): ");
            string type = Console.ReadLine() ?? "";
            Console.Write("Введите цену за ночь: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");

            rooms.Add(new Room { Id = id, Number = number, Type = type, PricePerNight = price, IsAvailable = true });
            view.ShowMessage("Комната успешно добавлена!");
        }
        catch
        {
            view.ShowMessage("Ошибка ввода данных комнаты.");
        }
    }

    private void AddClientPrompt()
    {
        if (rooms.Count == 0)
        {
            view.ShowMessage("Сначала добавьте хотя бы одну комнату в систему!");
            return;
        }

        try
        {
            Console.Write("Введите ID клиента: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите ФИО клиента: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Введите номер паспорта: ");
            string passport = Console.ReadLine() ?? "";
            
            Console.Write("Введите ID свободной комнаты для заселения: ");
            int roomId = int.Parse(Console.ReadLine() ?? "0");

            var room = rooms.FirstOrDefault(r => r.Id == roomId && r.IsAvailable);
            if (room == null)
            {
                view.ShowMessage("Комната не найдена или уже занята!");
                return;
            }

            room.IsAvailable = false; // Меняем статус комнаты на занятую
            clients.Add(new Client { Id = id, FullName = name, PassportNumber = passport, RentedRoomId = roomId });
            view.ShowMessage("Клиент успешно зарегистрирован!");
        }
        catch
        {
            view.ShowMessage("Ошибка ввода данных клиента.");
        }
    }

    private void SearchRoomByTypePrompt()
    {
        Console.Write("Введите тип комнаты для поиска: ");
        string query = Console.ReadLine() ?? "";
        var result = rooms.Where(r => r.Type.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        view.ShowRooms(result);
    }
}