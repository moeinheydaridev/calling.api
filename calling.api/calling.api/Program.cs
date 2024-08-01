using System.ComponentModel.Design;
using System.Text;
using System.Text.Json;

namespace SendPostRequest;

class Program
{
    static void Main(string[] args)
    {
        var postdata = new Class1
        {
                 Address = "Kermanshah",
                Age = 21,
              Name = "Moein",
        };

        var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.blockchain.com/v3/exchange");
        var json = JsonSerializer.Serialize(postdata);
        var content = new StringContent(json, Encoding.UTF8, "application/Json");
        var response = client.PostAsync("posts", content).Result;
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseContent);
        }
        else
        {
            Console.WriteLine("Error" + response.StatusCode);
        }

    }
}
