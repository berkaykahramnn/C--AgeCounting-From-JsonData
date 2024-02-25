using System; 
using System.IO; 
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

class MainClass {
  static async Task Main() {
    HttpClient client = new HttpClient();
    //Veriyi Json formatında string olarak al | Get the Json data as a string
    string s = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/age-counting");
    Console.WriteLine(AgeCounter(s));
  } 
  
  public static int AgeCounter(string value)
  {
    //Deserialize JSON
    DataObj obj = JsonConvert.DeserializeObject<DataObj>(value);
    //Stringi virgülle ayırarak parçala | Split the string into parts by comma
    string[] parts = obj.data.Split(',');
    int counter =0;
    foreach (string part in parts)
        {
            //Parçaları 'age=' göre ayır ve age değerini al | Separate each part with 'age=' and get the age value
            if (part.Contains("age="))
            {
                int age = int.Parse(part.Split('=')[1]);
                if (age >= 50)
                {
                    counter++;
                }
            }
        }
    return counter;
  }
}
//Json formatındaki veriyi, string olarak tutacak objenin sınıfı | Class for storing data in JSON format as a string.
public class DataObj {
    public string data { get; set; }
  }
