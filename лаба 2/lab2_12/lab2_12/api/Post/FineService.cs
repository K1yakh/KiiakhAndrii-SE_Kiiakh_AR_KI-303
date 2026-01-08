using System.Threading.Tasks;
using System.Windows;

namespace lab2_12.api.Post
{
    public class FineService
    {
        public static async Task<bool> Send(int fineAmount, int roomId)
        {
            try
            {
                // Імітація затримки як при реальному запиті
                await Task.Delay(200);

                if (roomId <= 0)
                {
                    MessageBox.Show("Некоректний номер кімнати");
                    return false;
                }

                if (fineAmount <= 0)
                {
                    MessageBox.Show("Штраф має бути більший за 0");
                    return false;
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Помилка при нарахуванні штрафу");
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