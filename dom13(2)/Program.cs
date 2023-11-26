using System;
using System.Collections.Generic;
using System.Threading;

// Класс, представляющий клиента
public class Client
{
    public int Id { get; }
    public string Name { get; set; }
    public string ServiceType { get; set; }

    public Client(int id)
    {
        Id = id;
    }
}

// Класс, представляющий банк
public class Bank
{
    private Queue<Client> clientQueue = new Queue<Client>();

    // Метод для добавления клиентов в очередь
    public void EnqueueClient(Client client)
    {
        clientQueue.Enqueue(client);
        Console.WriteLine($"Клиент {client.Name} добавлен в очередь.");
    }

    // Метод для обслуживания клиентов
    public void ServeClients()
    {
        while (clientQueue.Count > 0)
        {
            Client currentClient = clientQueue.Dequeue();
            Console.WriteLine($"Клиент {currentClient.Name} начал обслуживание ({currentClient.ServiceType}).");

            // Имитация времени обслуживания разных типов
            int serviceTime = GetServiceTime(currentClient.ServiceType);
            Thread.Sleep(serviceTime);

            Console.WriteLine($"Клиент {currentClient.Name} обслужен за {serviceTime / 1000} сек.");
        }

        Console.WriteLine("Все клиенты обслужены.");
    }

    // Вспомогательный метод для получения времени обслуживания по типу
    private int GetServiceTime(string serviceType)
    {
        switch (serviceType)
        {
            case "Кредитование":
                return 5000; // 5 секунд
            case "Открытие вклада":
                return 3000; // 3 секунды
            case "Консультация":
                return 2000; // 2 секунды
            default:
                return 4000; // 4 секунды (по умолчанию)
        }
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        // Добавление клиентов в очередь
        bank.EnqueueClient(new Client(1) { Name = "John", ServiceType = "Кредитование" });
        bank.EnqueueClient(new Client(2) { Name = "Alice", ServiceType = "Открытие вклада" });
        bank.EnqueueClient(new Client(3) { Name = "Bob", ServiceType = "Консультация" });

        // Обслуживание клиентов
        bank.ServeClients();
    }
}
