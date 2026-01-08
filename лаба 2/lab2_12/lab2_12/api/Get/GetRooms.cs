using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using lab2_12.Entity;

namespace lab2_12.api.Get
{
    public class GetRooms
    {
        public static async Task<(bool, List<Room>)> Send()
        {
            try
            {
                // Імітуємо затримку як при реальному запиті
                await Task.Delay(200);

                // Статичні дані (кімнати)
                var rooms = new List<Room>
                {
                    new Room { Id = 1, Number = 101, Capacity = 2, Fine = 0 },
                    new Room { Id = 2, Number = 102, Capacity = 3, Fine = 50 },
                    new Room { Id = 3, Number = 201, Capacity = 1, Fine = 0 },
                    new Room { Id = 4, Number = 202, Capacity = 4, Fine = 100 }
                };

                return (true, rooms);
            }
            catch
            {
                MessageBox.Show("Помилка при завантаженні кімнат");
                return (false, new List<Room>());
            }
        }

        public class ResponseWrapper
        {
            public bool success { get; set; }
            public string message { get; set; }
            public List<Room> rooms { get; set; }
        }
    }
}