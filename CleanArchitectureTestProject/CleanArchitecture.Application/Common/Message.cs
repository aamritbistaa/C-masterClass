using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common
{
    public static class Message
    {
       public static class DepartmentMessage
        {
            public static string Empty = "Department table is empty.";
            public static string Displaying = "Displaying department records.";
            public static string ItemNotFound = "Department with specified id does not exist.";

            public static string ErrorWhileAdding = "Error adding department";
            public static string SuccessAdding = "Deprtment added successfully";

            public static string ErrorWhileUpdating = "Error occured while updaing the department.";
            public static string SuccessUpdating = "Department updated successfully.";

            public static string ErrorWhileDeleting = "Error occured while deleting the department.";
            public static string SuccessDeleting = "Department deleted successfully.";
        }
        public static class UserMessage
        {
            public static string Empty = "User table is empty.";
            public static string Displaying = "Displaying User records.";
            public static string ItemNotFound = "User with specified id does not exist.";

            public static string ErrorWhileAdding = "Error adding User";
            public static string SuccessAdding = "User added successfully";

            public static string ErrorWhileUpdating = "Error occured while updaing the User.";
            public static string SuccessUpdating = "User updated successfully.";

            public static string ErrorWhileDeleting = "Error occured while deleting the User.";
            public static string SuccessDeleting = "User deleted successfully.";
        }
        public static class AddressMessage
        {
            public static string Empty = "Address table is empty.";
            public static string Displaying = "Displaying Address records.";
            public static string ItemNotFound = "Address with specified id does not exist.";

            public static string ErrorWhileAdding = "Error adding Address";
            public static string SuccessAdding = "Address added successfully";

            public static string ErrorWhileUpdating = "Error occured while updaing the Address.";
            public static string SuccessUpdating = "Address updated successfully.";

            public static string ErrorWhileDeleting = "Error occured while deleting the Address.";
            public static string SuccessDeleting = "Address deleted successfully.";
        }
    }
}
