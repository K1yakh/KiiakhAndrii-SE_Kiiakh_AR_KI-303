using System.Threading.Tasks;
using System.Windows;

namespace lab2_12.api.Post
{
    public class KickPatientFromRoom
    {
        public static async Task<bool> Send(int roomId, int patientId)
        {
            try
            {
                // Імітуємо затримку, щоб виглядало як реальний запит
                await Task.Delay(200);

                if (roomId <= 0)
                {
                    MessageBox.Show("Некоректний номер кімнати");
                    return false;
                }

                if (patientId <= 0)
                {
                    MessageBox.Show("Некоректний ID пацієнта");
                    return false;
                }

                // Успішна відповідь (ніби пацієнта вигнали)
                return true;
            }
            catch
            {
                MessageBox.Show("Помилка при видаленні пацієнта");
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