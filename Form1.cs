using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5212AssignmentB
{
    public partial class Form1 : Form
    {
        int index = -1; // Sets the index for lstDataList
        List<Customer> CustomerDB = new List<Customer>(); // Creates a List object of the Customer class

        public Form1()
        {
            InitializeComponent();
        }

        // Runs on progam start
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDB();
            DisplayCustomer();
            txtSearch.Focus(); // Sets cursor focus to the txtSearch textbox
        }

        private void LoadDB()
        {
            // Creates and add new Customer objects to the CustomerDB
            CustomerDB.Add(new Customer("Drew", "Trumbat", "123-3845"));
            CustomerDB.Add(new Customer("Shelly", "McGowan", "123-2665"));
            CustomerDB.Add(new Customer("Gerald", "Goetz", "123-9874"));
        }

        private void DisplayCustomer()
        {
            // Loops through the objects in the CustomerDB and adds them to the lstDataList
            foreach (Customer customer in CustomerDB)
            {
                lstDataList.Items.Add(customer.GetCustomer());
            }
        }

        private void ClearAll()// .Button
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            txtSearch.Clear();
            lstDataList.Items.Clear();
            txtSearch.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Validates the user would like to clear all
            DialogResult result = MessageBox.Show("Are you sure you want to clear all?\n(including the main list)", "Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ClearAll();
            }
            else
            {
                MessageBox.Show("Operation cancelled");
            }
        }

        private void btnResetList_Click(object sender, EventArgs e)
        {
            // Got tired of having to reload the program durring testing so just added this
            // to re-display the objects in the CustomerDB
            DisplayCustomer();
            txtSearch.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validates all textboxes have been filled out before adding the new customer to the CustomerDB
            if (txtFirstName.Text == String.Empty || txtLastName.Text == String.Empty || txtPhoneNumber.Text == String.Empty)
            {
                MessageBox.Show("All textboxes must be filled to continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("New customer has been added");
                CustomerDB.Add(new Customer(txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text));
                lstDataList.Items.Clear();
                DisplayCustomer();
                txtSearch.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Deletes selected index/customer in the lstDataList listbox
            index = lstDataList.SelectedIndex;

            // Validation
            if (index < 0)
            {
                MessageBox.Show("Please select a customer to delete");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?","Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("The customer has been deleted");
                    CustomerDB.RemoveAt(index);
                    lstDataList.Items.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtPhoneNumber.Clear();
                    txtSearch.Clear();
                    DisplayCustomer();
                    txtSearch.Focus();
                }
                else
                {
                    MessageBox.Show("Operation cancelled");
                }
            }
        }

        // Had a lot of trouble with this one and ended up doing it this way
        // Even though i couldnt figure out how to clear the list and then only show the searched customer
        // Im sure its something super easy that im missing
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                index = lstDataList.FindString(txtSearch.Text);

                if (index != -1)
                {
                    lstDataList.SetSelected(index, true);
                }
                else
                {
                    MessageBox.Show("Customer not found please try again.");
                }
            }
            else
            {
                MessageBox.Show("You must enter a customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Splits the selected list item into an array and displays each part into the respective textboxes
        private void Split_Selected(object sender, EventArgs e)
        {
            string[] selected = lstDataList.SelectedItem.ToString().Split('\t');

            txtFirstName.Text = selected[0];
            txtLastName.Text = selected[1];
            txtPhoneNumber.Text = selected[2];
        }
    }
}
