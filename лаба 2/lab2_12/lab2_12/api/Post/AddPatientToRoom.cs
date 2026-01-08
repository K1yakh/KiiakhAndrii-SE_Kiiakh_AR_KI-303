using System.Threading.Tasks;
using System.Windows;

namespace lab2_12.api.Post
{
    public class AddPatientToRoom
    {
        public static async Task<bool> Send(string patientName, int roomId)
        {
            try
            {
                // Імітуємо затримку, щоб виглядало як запит
                await Task.Delay(200);

                if (string.IsNullOrWhiteSpace(patientName))
                {
                    MessageBox.Show("Ім'я пацієнта не може бути порожнім");
                    return false;
                }

                if (roomId <= 0)
                {
                    MessageBox.Show("Некоректний номер кімнати");
                    return false;
                }

                // Успішна відповідь
                return true;
            }
            catch
            {
                MessageBox.Show("Помилка при додаванні пацієнта");
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