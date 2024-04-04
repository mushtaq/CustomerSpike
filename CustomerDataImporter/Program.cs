// See https://aka.ms/new-console-template for more information

using System.Text;
using DTO;

var filePath = "CustomerData.txt";
var customersLines = File.ReadAllLines(filePath);
List<Customer> customers = new List<Customer>();

foreach (string customerLine in customersLines)
{
    var customerArray = customerLine.Split('\t').Select(p => p.Trim('~')).ToArray();
    var names = customerArray[1].Split(" ");
    
    var customer = new Customer()
    {
        Id = int.Parse(customerArray[0]) ,
        FirstName = names[0],
        LastName = names[1],
        EscoId = int.Parse(customerArray[2])
    };
    customers.Add(customer);
}

var httpClient = new HttpClient();
var url = "http://localhost:5190/api/customers/bulk";

var content = new StringContent(
    Newtonsoft.Json.JsonConvert.SerializeObject(customers),
    Encoding.UTF8,
    "application/json");

HttpResponseMessage response = await httpClient.PostAsync(url, content);

if (response.IsSuccessStatusCode)
{
    string responseData = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Customers created");
}
else
{
    Console.WriteLine($"Failed to POST data: {response.ReasonPhrase}");
}