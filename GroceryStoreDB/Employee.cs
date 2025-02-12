using LibrarySystem324;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStoreDB
{
    internal class Employee
    {
        private DataRow _Row;
        public Employee(DataRow aRow)
        {
            int EmpID = (int)aRow["EmpID"];
            DataTable dt = DBEngine.GetTable("Select * From Employee where EmpID=" + EmpID.ToString());

            _Row = dt.Rows[0];
        }

        public static DataTable EmployeeTables()
        {
            return DBEngine.GetTable("select * from Employee");
        }


        public static DataTable search(string filter)
        {
            DataTable Tbl = new DataTable();
            string SQL = "select * from Employee ";
            if (filter.Trim() != "") { SQL += "where " + filter.Trim(); }

            Tbl = DBEngine.GetTable(SQL);

            return Tbl;
        }

        public static void createNew()
        {
            string SQL = "INSERT INTO Employee(Firstname, Lastname, Position, Email) values ('GoodBlake', 'EvilStinson', 'Boss', 'mail@mail.com')";
            DBEngine.Execute(SQL);
        }
        public static DataTable EmployeeTable()
        {
            return DBEngine.GetTable("select * from Employee");
        }
        public void save()
        {

            string SQL = "UPDATE Employee SET Firstname='" + Firstname + "', Lastname='" + Lastname + "', Position='" + Position.ToString() + "', Email='" + Email.ToString() + "' WHERE EmpID=" + EmpID.ToString();
            DBEngine.Execute(SQL);

        }

        public void delete()
        {

            string sqldel = "SELECT * FROM Sale Where EmployeeID=" + EmpID.ToString();
            DataTable dt = DBEngine.GetTable(sqldel);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("You cannot delete this Employee!");
            }
            else
            {
                string SQL = "DELETE FROM Employee WHERE EmpID=" + EmpID.ToString();
                DBEngine.Execute(SQL);
            }


        }


        public string Firstname
        {
            get
            {
                return (string)_Row["Firstname"];
            }
            set
            {
                _Row["Firstname"] = value;
            }
        }
        public string Lastname
        {
            get
            {
                return (string)_Row["Lastname"];
            }
            set
            {
                _Row["Lastname"] = value;
            }
        }
       

        public int EmpID => (int)_Row["EmpID"];
        public string Email
               {
                   get
                   {
                       return (string)_Row["Email"];
                   }
                   set
                   {
                       _Row["Email"] = value;
                   }
               }
        public string Position
        {
            get
            {
                return (string)_Row["Position"];
            }
            set
            {
                _Row["Position"] = value;
            }
        }
    }
}
