using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;


HttpClient client = new HttpClient();

// ===============================
// GET - Retrieve all weather data
// ===============================
Console.WriteLine("===== GET =====");

var getResponse = await client.GetAsync("https://localhost:7252/weatherforecast");

Console.WriteLine($"Status: {getResponse.StatusCode}");

string getResult = await getResponse.Content.ReadAsStringAsync();

Console.WriteLine(getResult);


// =================================
// POST - Create a new weather record
// =================================
Console.WriteLine("\n===== POST =====");

var postRequest = new
{
    Date = new DateOnly(2026, 7, 6),
    TemperatureC = 30,
    Summary = "Sunny"
};

string postJson = JsonSerializer.Serialize(postRequest);

var postContent = new StringContent(
    postJson,
    Encoding.UTF8,
    "application/json");

var postResponse = await client.PostAsync(
    "https://localhost:7252/weatherforecast",
    postContent);

Console.WriteLine($"Status: {postResponse.StatusCode}");

string postResult = await postResponse.Content.ReadAsStringAsync();

Console.WriteLine(postResult);


// ===============================
// PUT - Update a weather record
// ===============================
Console.WriteLine("\n===== PUT =====");

var putRequest = new
{
    Date = new DateOnly(2026, 7, 7),
    TemperatureC = 35,
    Summary = "Very Hot"
};

string putJson = JsonSerializer.Serialize(putRequest);

var putContent = new StringContent(
    putJson,
    Encoding.UTF8,
    "application/json");

var putResponse = await client.PutAsync(
    "https://localhost:7252/weatherforecast",
    putContent);

Console.WriteLine($"Status: {putResponse.StatusCode}");

string putResult = await putResponse.Content.ReadAsStringAsync();

Console.WriteLine(putResult);


// ==================================
// DELETE - Delete weather record #1
// ==================================
Console.WriteLine("\n===== DELETE =====");

var deleteResponse =
    await client.DeleteAsync("https://localhost:7252/weatherforecast/1");

Console.WriteLine($"Status: {deleteResponse.StatusCode}");

string deleteResult =
    await deleteResponse.Content.ReadAsStringAsync();

Console.WriteLine(deleteResult);

Console.WriteLine("\nFinished!");
Console.ReadKey();
