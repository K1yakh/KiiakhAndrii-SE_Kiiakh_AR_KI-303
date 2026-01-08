using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace lab2_12.api.Post;

public static class AddReviewService
{
    public static async Task<(bool success, string message)> Send(int roomId, string reviewText)
    {
        try
        {
            using var client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 5000);
            
            var stream = client.GetStream();
            
            var request = new
            {
                command = "addreview",
                roomId = roomId.ToString(),
                text = reviewText
            };
            
            var jsonRequest = JsonSerializer.Serialize(request);
            var data = Encoding.UTF8.GetBytes(jsonRequest);
            
            await stream.WriteAsync(data, 0, data.Length);
            
            var buffer = new byte[1024];
            var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            
            var responseData = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            
            bool success = responseData?.ContainsKey("success") == true && 
                          responseData["success"]?.ToString()?.ToLower() == "true";
            string message = responseData?.ContainsKey("message") == true ? 
                           responseData["message"]?.ToString() ?? "No message" : "No message";
            
            return (success, message);
        }
        catch (Exception ex)
        {
            return (false, $"Error adding review: {ex.Message}");
        }
    }
}