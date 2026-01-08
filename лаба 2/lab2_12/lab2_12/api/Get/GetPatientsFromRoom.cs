using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using lab2_12.Entity;

namespace lab2_12.api.Get
{
    public class GetPatientsFromRoom
    {
        public static async Task<(bool, List<Patient>)> Send(int roomId)
        {
            try
            {
                // Статичні дані, які повертаються незалежно від roomId
                var patients = new List<Patient>
                {
                    new Patient("Іван Петренко") { Id = 1 },
                    new Patient("Олена Коваль") { Id = 2 },
                    new Patient("Микола Шевченко") { Id = 3 }
                };

                return (true, patients);
            }
            catch
            {
                MessageBox.Show("Помилка при завантаженні пацієнтів");
                return (false, new List<Patient>());
            }
        }
    }
}