using System.Threading.Tasks;
using System.Windows;
using lab2_12.Entity;

namespace lab2_12.api.Post
{
    public class RoomCreateService
    {
        public static async Task<bool> Send(Room room)
        {
            try
            {
                // Імітуємо затримку, як ніби запит йде на сервер
                await Task.Delay(200);

                if (room == null)
                {
                    MessageBox.Show("Кімната не може бути порожньою");
                    return false;
                }

                if (room.Number <= 0)
                {
                    MessageBox.Show("Некоректний номер кімнати");
                    return false;
                }

                if (room.Capacity <= 0)
                {
                    MessageBox.Show("Місткість кімнати має бути більшою за 0");
                    return false;
                }

                // Успішна відповідь (ніби кімната створена)
                return true;
            }
            catch
            {
                MessageBox.Show("Помилка при створенні кімнати");
                return false;
            }
        }

        public class ResponseWrapper
        {
            public bool success { get; set; }
            public string message { get; set; }
        }
    }
}