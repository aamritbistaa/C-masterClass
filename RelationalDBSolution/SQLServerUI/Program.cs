using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Data;



var connectionString = GetConnectionString("Default");

SqlCrud sql = new SqlCrud(connectionString);

//await ReadAllContactsAsync(sql);
//await CreateContact(sql);
await GetFullContactId(sql, 8);




Console.ReadLine();




string GetConnectionString(string connectionStringName = "DefaultConnection")
{
    string output = "";
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

    var config = builder.Build();

    output = config.GetConnectionString(connectionStringName);

    return output;
}

async Task CreateContact(SqlCrud sql)
{
    FullContactModel request = new FullContactModel
    {
        BasicInfo = new BasicContactModel
        {
            FirstName = "Amrit",
            LastName = "Bista"
        },
        EmailAddresses = new List<EmailAddressModel>()
    {
        new EmailAddressModel
        {
            EmailAddress = "email1@gmail.com"
        },
        new EmailAddressModel
        {
            EmailAddress = "email2@gmail.com"
        }
    },
        PhoneNumbers = new List<PhoneNumberModel>()
    {
        new PhoneNumberModel
        {
            PhoneNumber = "291832"
        },
        new PhoneNumberModel
        {
            PhoneNumber = "291832asd"
        }
    }
    };

    await sql.CreateContact(request);
}
async Task ReadAllContactsAsync(SqlCrud sql)
{
    var rows = await sql.GetAllContacts();
    foreach (var row in rows)
    {
        Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
    }
}

async Task GetFullContactId(SqlCrud sql, int contactId)
{
    Console.WriteLine($"\nDisplaying full contact for {contactId}\n");

    var data = await sql.GetFullContactById(contactId);
    Console.WriteLine($"{data.BasicInfo.Id}: {data.BasicInfo.FirstName} {data.BasicInfo.LastName}");
    foreach (var item in data.PhoneNumbers)
    {
        Console.WriteLine($"{item.Id}: {item.PhoneNumber}");
    }
    foreach (var item in data.EmailAddresses)
    {
        Console.WriteLine($"{item.Id}: {item.EmailAddress}");
    }
}

