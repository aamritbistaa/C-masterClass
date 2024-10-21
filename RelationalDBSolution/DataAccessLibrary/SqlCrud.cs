using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        private SqlDataAccess db = new SqlDataAccess();
        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<BasicContactModel>> GetAllContacts()
        {
            string sqlStatement = "Select Id, FirstName, LastName from dbo.Contacts";
            var datas = await db.LoadDataAsync<BasicContactModel, dynamic>(sqlStatement, new { }, _connectionString);
            return datas;
        }

        public async Task<FullContactModel> GetFullContactById(int id)
        {
            FullContactModel output = new FullContactModel();

            //parameterized query to eliminate sql injection
            string sqlStatement = "Select Id, FirstName, LastName from dbo.Contacts where Id = @Id";
            output.BasicInfo = (await db.LoadDataAsync<BasicContactModel, dynamic>(sqlStatement, new { Id = id }, _connectionString)).First();
            if (output.BasicInfo == null)
            {
                //Record was not found
                return null;
            }

            sqlStatement = @"Select e.* 
                            from dbo.EmailAddresses e
                            inner join dbo.ContactsEmail ce on ce.EmailAddressId = e.Id
                            where ce.ContactId = @Id";
            output.EmailAddresses = (await db.LoadDataAsync<EmailAddressModel, dynamic>(sqlStatement, new { Id = id }, _connectionString));

            sqlStatement = @"select p.* 
                            from dbo.PhoneNumber p 
                            inner join dbo.ContactPhoneNumbers cp on cp.PhoneNumberId = p.Id
                            where cp.ContactId = @Id";
            output.PhoneNumbers = (await db.LoadDataAsync<PhoneNumberModel, dynamic>(sqlStatement, new { Id = id }, _connectionString));

            return output;
        }


        public async Task CreateContact(FullContactModel contact)
        {
            string sqlStatement = "Insert into dbo.Contacts(FirstName, LastName) values (@FirstName, @LastName);";

            //Save the basic Contact
            db.SaveData(sqlStatement, new { FirstName = contact.BasicInfo.FirstName, LastName = contact.BasicInfo.LastName }, _connectionString);

            // Get the Id number of the contact
            sqlStatement = "Select Id from dbo.Contacts where FirstName = @FirstName and LastName = @LastName";
            int contactId = (await db.LoadDataAsync<IdLookupModel, dynamic>(sqlStatement, new { FirstName = contact.BasicInfo.FirstName, LastName = contact.BasicInfo.LastName }, _connectionString)).First().Id;
            //Identify if the phone the number exist
            foreach (var phoneNumber in contact.PhoneNumbers)
            {
                if(phoneNumber.Id == 0)
                {
                    sqlStatement = "Insert into dbo.PhoneNumber (PhoneNumber) values (@PhoneNumber);";
                    db.SaveData(sqlStatement, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString);

                    sqlStatement = "Select Id from dbo.PhoneNumber where PhoneNumber = @PhoneNumber";
                    phoneNumber.Id = (await db.LoadDataAsync<IdLookupModel, dynamic>(sqlStatement, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString)).First().Id;
                }

                sqlStatement = "Insert into dbo.ContactPhoneNumbers(ContactId,PhoneNumberId) values(@ContactId,@PhoneNumberId);";

                db.SaveData(sqlStatement, new {ContactId = contactId, PhoneNumberId = phoneNumber.Id }, _connectionString);

            }
            //Insert into the lisnk table for that number
            //Insert the new phone number if not, and get the id
            //Then d the link table insert
            //Similar for the email
            foreach (var emailAddress in contact.EmailAddresses)
            {
                if (emailAddress.Id == 0)
                {
                    sqlStatement = "Insert into dbo.EmailAddresses (EmailAddress) values (@EmailAddress);";
                    db.SaveData(sqlStatement, new { EmailAddress = emailAddress.EmailAddress }, _connectionString);

                    sqlStatement = "Select Id from dbo.EmailAddresses where EmailAddress = @EmailAddress";
                    emailAddress.Id = (await db.LoadDataAsync<IdLookupModel, dynamic>(sqlStatement, new { EmailAddress = emailAddress.EmailAddress }, _connectionString)).First().Id;
                }

                sqlStatement = "Insert into dbo.ContactsEmail(ContactId, EmailAddressId) values(@ContactId,@EmailAddressId);";

                db.SaveData(sqlStatement, new { ContactId = contactId, EmailAddressId = emailAddress.Id }, _connectionString);

            }
        }
    }
}
