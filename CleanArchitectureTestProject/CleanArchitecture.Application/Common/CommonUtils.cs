using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common
{
    public static class CommonUtils
    {

        public static DateTime SetKindUtc(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc) { return dateTime; }
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
        public async static Task<T> DeserializeObject<T>(string obj)
        {
            var items = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(obj);
            return items;
        }

        public static string GetEnumDescription<T>(this T enumValue) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new Exception("T must be enumerated type");

            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = ConvertDataTableToObject<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T ConvertDataTableToObject<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static string HashValue(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            using (var sha = new SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(value);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        public static string PasswordHash1 => PasswordHash;
        public static string Encrypt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(value);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash1, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);

        }
        public static string Decrypt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            byte[] cipherTextBytes = Convert.FromBase64String(value);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash1, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public static DateTime ToDateTime(this string value)
        {

            try
            {
                return DateTime.ParseExact(value, "dd/MM/yyyy", null);
            }
            catch (Exception)
            {

                return new DateTime();
            }
        }

        public static bool ValidateAge(this DateTime? dateOfBirth)
        {
            DateTime bday = dateOfBirth ?? new DateTime();
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (age < 18)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDate(this DateTime? dateTime)
        {
            DateTime incorporationDate = dateTime ?? new DateTime();
            DateTime todayDate = DateTime.Today;
            if (incorporationDate > DateTime.Today)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// this function is applicable only if all the target object members are present on source object.
        /// Be aware of member case(uppercase, lowercase) and spelling.
        /// </summary>
        /// <typeparam name="T">target object type</typeparam>
        /// <param name="obj">Source Object</param>
        /// <returns></returns>
        public static T ConvertObjectTo<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
        public static string GetTimeLineDate(DateTime logTime)
        {
            var diff = System.DateTime.Now - logTime;
            if ((int)diff.TotalDays == 0)
            {
                return "" + logTime.ToString("hh:mm tt");
            }
            else if (diff.TotalDays == 1)
            {
                return (int)diff.TotalDays + " Day Ago";// + logTime.ToString("hh:mm tt");
            }
            else
                return (int)diff.TotalDays + " Days Ago";// + logTime.ToString("hh:mm tt");
        }
        public static Dictionary<string, object> ConvertToDictionary(object viewModel)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var type = viewModel.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(viewModel);
                dictionary[propertyName] = propertyValue;
            }

            return dictionary;
        }
        public class ResponseClass<T>
        {
            public int ResponseNumber { get; set; }
            public ResponseType ResponseType { get; set; }
            public string Message { get; set; }
            public T data { get; set; }
        }
        public enum ResponseType
        {
            Ok,
            InvalidToken,
            Error
        }

    }
}
