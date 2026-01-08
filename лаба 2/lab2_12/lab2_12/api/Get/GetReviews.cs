using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using lab2_12.Entity;

namespace lab2_12.api.Get
{
    public class GetReviews
    {
        public static async Task<(bool, List<Review>)> Send(int roomId)
        {
            try
            {
                // Імітація запиту (щоб виклик залишався async)
                await Task.Delay(200);

                // Статичні дані
                var reviews = new List<Review>
                {
                    new Review { Text = "Чиста кімната, все сподобалось", Date = "2025-09-01" },
                    new Review { Text = "Було трохи шумно вночі", Date = "2025-09-05" },
                    new Review { Text = "Зручне розташування і привітний персонал", Date = "2025-09-10" }
                };

                return (true, reviews);
            }
            catch
            {
                MessageBox.Show("Помилка при завантаженні відгуків");
                return (false, new List<Review>());
            }
        }

        public class ResponseWrapper
        {
            public bool success { get; set; }
            public string message { get; set; }
            public List<Review> reviews { get; set; }
        }
    }
}