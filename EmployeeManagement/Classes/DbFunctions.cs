using EmployeeManagement.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeManagement
{
    /// <summary>
    /// All Database accessing Functions reside in this class. 
    /// </summary>
    public static class DbFunctions
    {                     
        /// <summary>
        /// max number of attempts to access db without prompting the user
        /// this is for intermittent issues like if Azure or internet did not respond immediately
        /// </summary>
        private const int MAX_NUMBER_OF_ATTEMPTS = 3;

        /// <summary>
        /// Gets a List of all Employees from the Database. 
        /// </summary>
        /// <returns>List of all Employee Objects</returns>
        public static List<Employee> GetListOfEmployeesFromDB()
        {
            //count number of database access attempts
            int AttemptCount = 0;
            do
            {
                try
                {
                    AttemptCount++;
                    using (EmpManEntities  db = new EmpManEntities())
                    {
                        return db.Employees.ToList();
                    }

                }
                catch (Exception ex)
                {
                    //log all errors that occur
                    LogFunctions.LogException(ex);
                }
            }
            while ((AttemptCount < MAX_NUMBER_OF_ATTEMPTS) || ConfirmContinue(AttemptCount));

            //give notice to exit application if user decides to not keep trying
            Application.Exit();
            //return empty list
            return new List<Employee>();
        }

        /// <summary>
        /// Saves Edits to a current employee in the database.
        /// </summary>
        /// <param name="employeeIn">An edited employee object</param>
        public async static void SaveEmployeeEditsToDB(Employee employeeIn)
        {
            //count number of database access attempts
            int AttemptCount = 0;
            do
            {
                try
                {
                    AttemptCount++;
                    using (EmpManEntities db = new EmpManEntities())
                    {
                        //find the employee in the db with the same ID as employeeIn
                        Employee EmployeeToEdit = db.Employees.Where(p => p.ID == employeeIn.ID).FirstOrDefault();
                        //set all db employee properties = employeeIn's properties
                        EmployeeToEdit.FirstName = employeeIn.FirstName;
                        EmployeeToEdit.MiddleName = employeeIn.MiddleName;
                        EmployeeToEdit.LastName = employeeIn.LastName;
                        EmployeeToEdit.Phone = employeeIn.Phone;
                        EmployeeToEdit.JobTitle = employeeIn.JobTitle;
                        EmployeeToEdit.Photo = employeeIn.Photo;
                        EmployeeToEdit.Email = employeeIn.Email;
                        EmployeeToEdit.FullName = employeeIn.FullName;
                        // save changes to the database asynchronously for better responsiveness
                        await db.SaveChangesAsync();
                        //return here if successful
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //log all errors that occur
                    LogFunctions.LogException(ex);
                }
            }
            while ((AttemptCount < MAX_NUMBER_OF_ATTEMPTS) || ConfirmContinue(AttemptCount));

            //give notice to exit application if user decides to not keep trying
            Application.Exit();
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employeeIn">The employee to add to the db</param>
        public async static void AddEmployeeToDB(Employee employeeIn)
        {
            //count number of database access attempts
            int AttemptCount = 0;
            do
            {
                try
                {
                    AttemptCount++;
                    using (EmpManEntities db = new EmpManEntities())
                    {
                        // add the employee to the db
                        db.Employees.Add(employeeIn);
                        // save changes to the database asynchronously for better responsiveness
                        await db.SaveChangesAsync();
                        //return here if successful
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //log all errors that occur
                    LogFunctions.LogException(ex);
                }
            }
            while ((AttemptCount < MAX_NUMBER_OF_ATTEMPTS) || ConfirmContinue(AttemptCount));

            //give notice to exit application if user decides to not keep trying
            Application.Exit();
        }

        /// <summary>
        /// Deletes an employee from the database.
        /// </summary>
        /// <param name="employeeIn">The employee to delete from the db</param>
        public async static void DeleteEmployeeFromDB(Employee employeeIn)
        {
            //count number of database access attempts
            int AttemptCount = 0;
            do
            {
                try
                {
                    AttemptCount++;
                    using (EmpManEntities db = new EmpManEntities())
                    {
                        // find and remove employee from the db with the same ID as employeeIn
                        db.Employees.RemoveRange(db.Employees.Where(p => p.ID == employeeIn.ID));
                        // save changes to the database asynchronously for better responsiveness
                        await db.SaveChangesAsync();
                        //return here if successful
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //log all errors that occur
                    LogFunctions.LogException(ex);
                }
            }
            while ((AttemptCount < MAX_NUMBER_OF_ATTEMPTS) || ConfirmContinue(AttemptCount));

            //give notice to exit application if user decides to not keep trying
            Application.Exit();
        }

        /// <summary>
        /// Displays a failed to connect message and asks the user if to keep trying.
        /// </summary>
        /// <param name="attemptCount">Number of unsuccessful attempts</param>
        /// <returns>True if the user wants to continue. False if the user does not.</returns>
        private static bool ConfirmContinue(int attemptCount)
        {
            return (MessageBox.Show($"Connecting to the database failed {attemptCount} times.\n" +
                                    "Details can be found in \n" +
                                    $"{LogFunctions.GetLogFileName()}\n" +
                                    "Would you like to keep trying?",
                                    "Connection to Database Failed",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes);
        }

        /// <summary>
        /// Used to insert test data from a local directory 'c:\projects\images' along with some random data.
        /// </summary>
        public static void InsertTestDataToSQLDB()
        {
            try
            {
                using (EmpManEntities db = new EmpManEntities())
                {
                    int i = 1;
                    foreach (string fileName in Directory.GetFiles("C:\\projects\\IMAGES"))
                    {
                        {
                            Image img = Image.FromFile(fileName);
                            img = ImageFunctions.ResizeImage(img, (int)(100.0m * img.Width / img.Height), 100);
                            Random rnd = new Random();
                            db.Employees.Add(new Employee
                            {
                                FirstName = "Test" + i.ToString(),
                                MiddleName = ((char)(rnd.Next(65 + 6, 65 + 15))).ToString(),
                                LastName = ((char)(rnd.Next(65 + 16, 65 + 25))).ToString() + "Test" + i.ToString(),
                                Email = "email" + i.ToString() + "@testemail.com",
                                Phone = (new Random().Next(111111111, 999999999).ToString() + "5").Insert(3, "-").Insert(7, "-"),
                                JobTitle = "Job" + i.ToString(),
                                Photo = ImageFunctions.GetByteArrayFromBitMapImage(img)
                            });
                            db.SaveChanges();
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }
    }
}
