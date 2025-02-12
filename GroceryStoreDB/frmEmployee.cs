using LibrarySystem324;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStoreDB
{
    public partial class frmEmployee : Form
    {
        private DataTable dt = new DataTable();
        private Employee selectedEmployee;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }



       
        private void showEmployees()
        {
            // DataTable aTable = DBEngin.GetTable("select * from Book");
            DataTable aTable = Employee.EmployeeTables();
            dataGridView1.DataSource = aTable;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void frmEmployee_Load(object sender, EventArgs e)
               {
                DataTable dt = DBEngine.GetTable("Select Position from Employee");
                drpPosition.DataSource = dt;
                drpPosition.DisplayMember = "Position";
                showEmployees();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee.createNew();
            showEmployees();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Employee.search("FirstName like '%" + txtSearch.Text.Trim() + "%'");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete Employee with " +
               "EmpID (" + selectedEmployee.EmpID + ")", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                selectedEmployee.delete();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            showEmployees();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedEmployee.Firstname = txtFirstname.Text;
            selectedEmployee.Lastname = txtLastname.Text;
            selectedEmployee.Email = txtEmail.Text;
            selectedEmployee.Position = drpPosition.Text;

            selectedEmployee.save();
            showEmployees();
        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView Grd = dataGridView1;
            DataTable Tbl = (DataTable)Grd.DataSource;
            DataRow SelRow = Tbl.Rows[e.RowIndex];
            Employee Emp = new Employee(SelRow);

            txtFirstname.Text = Emp.Firstname.ToString();
            txtLastname.Text = Emp.Lastname.ToString();
            txtEmpID.Text = Emp.EmpID.ToString();
            txtEmail.Text = Emp.Email.ToString();
                //MessageBox.Show(Emp.Position.Trim().ToString());
                drpPosition.Text = Emp.Position.Trim();

            selectedEmployee = Emp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
