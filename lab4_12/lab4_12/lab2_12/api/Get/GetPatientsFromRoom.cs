using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using lab2_12.Entity;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace lab2_12.api.Get;

public class GetPatientsFromRoom
{
    private const string ServerAddress = "localhost";
    private const int ServerPort = 5000;
    
    public static async Task<(bool, List<Patient>)> Send(int roomId)
    {
        var registerModel = new
        {
            command = "getroompatients",
            roomId = roomId.ToString()
        };

        var request = JsonSerializer.Serialize(registerModel);
        
        var bytesToSend = Encoding.UTF8.GetBytes(request);

        using (var client = new TcpClient(ServerAddress, ServerPort))
        {
            using (var stream = client.GetStream())
            {
                try
                {
                    await stream.WriteAsync(bytesToSend, 0, bytesToSend.Length);

                    using (var memoryStream = new MemoryStream())
                    {
                        var buffer = new byte[1024];
                        int bytesRead;

                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await memoryStream.WriteAsync(buffer, 0, bytesRead);
                        }

                        string response = Encoding.UTF8.GetString(memoryStream.ToArray());
                
                        var responseObject = JsonSerializer.Deserialize<ResponseWrapper>(response);
                        if (responseObject.success)
                        {
                            return (responseObject.success, responseObject.patients);
                        }
                
                        MessageBox.Show(responseObject.message);
                        return (responseObject.success, new List<Patient>());
                    }
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return (false, new List<Patient>());
                }
            }
        }
    }
    
    public class ResponseWrapper
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Patient> patients { get; set; }
    }
}