using System.Net.Mail;

namespace EmployeeManagement.Classes
{
    /// <summary>
    /// Contains functions for field validation.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True/False if email is valid/invalid.</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                // By creating a MailAddress object, 
                // we can compare the resulting Address property to the passed email string
                // for a basic validation
                MailAddress addr = new MailAddress(email);
                return (addr.Address == email);
            }
            catch
            {
                return false;
            }
        }
    }
}
