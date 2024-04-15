// See https://aka.ms/new-console-template for more information

using System.Text;
using CustomerClient.FixedWidthParser;
using Newtonsoft.Json;

var filePath = "CustomerData.txt";

// Following are the three ways to parse fixed width files
var customers = CustomerParserInBuilt.Parse(filePath);
// var customers = CustomerParserFileHelpers.Parse(filePath);
// var customers = CustomerParserFlatFiles.Parse(filePath);

var httpClient = new HttpClient();
var url = "http://localhost:5190/api/customers/bulk";

var content = new StringContent(
    JsonConvert.SerializeObject(customers),
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