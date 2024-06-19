using LibraryDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccess
{
    public class SqlCRUD
    {
        private readonly string _connectionString;
        private SqlDataAccess db = new SqlDataAccess();
        public SqlCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<BasicContactModel> GetAllContacts()
        {
            string sqlStatement = "Select Id, FirstName, LastName from dbo.Contacts";
            return db.LoadData<BasicContactModel, dynamic>(sqlStatement, new { }, _connectionString);
        }
        public BasicContactModel GetContactById(int id)
        {
            //--------This is vulnerable to SQL injection------
            //string sqlStatement = $"Select Id, FirstName, LastName from dbo.Contacts where Id={id}";
            //return db.LoadData<BasicContactModel, dynamic>(sqlStatement, new { }, _connectionString)[0];

            //--------This is proper way to SQL injection------
            string sqlStatement = $"Select Id, FirstName, LastName from dbo.Contacts where Id=@id";
            return db.LoadData<BasicContactModel, dynamic>(sqlStatement, new { Id = id },_connectionString).FirstOrDefault();
        }
        public FullContactModel GetFullContactModel(int id)
        {
            string sqlStatement = $"Select Id, FirstName, LastName from dbo.Contacts where Id=@id";
            FullContactModel output = new FullContactModel();
            output.BasicInfo = db.LoadData<BasicContactModel, dynamic>(sqlStatement, new { Id = id }, _connectionString).First();
            if (output.BasicInfo == null)
            {
                //tell user record not found
                //return null;
                throw new Exception("User not found");
            }
            sqlStatement = @"Select *
                            from dbo.EmailAddress e
                            inner join dbo.ContactEmail ce on ce.EmailAddressId = e.Id
                            where ce.ContactId= @Id;";
            output.EmailAddresses = db.LoadData<EmailAddressModel, dynamic>(sqlStatement, new {Id=id},_connectionString);

            sqlStatement = @"Select *
                            from dbo.PhoneNumbers p
                            inner join dbo.ContactPhoneNumbers cp on cp.PhoneNumberId = p.Id
                            where cp.ContactId=@Id;";
            output.PhoneNumbers = db.LoadData<PhoneNumberModel, dynamic>(sqlStatement, new { Id = id }, _connectionString);

            return output;
        }
    }
}
