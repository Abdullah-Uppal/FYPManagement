using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using FYP_Management.Classes;
using System.Windows.Forms;


namespace FYP_Management.UserControls {
    public partial class UStudents : UserControl {
        private DataGridViewCellContextMenuStripNeededEventArgs args;
        private List<string> row;
        private QueriesQueue pendingQueries;
        private string registration;
        DataGridViewCellEventHandler handler;
        public UStudents() {
            InitializeComponent();
            /**
             * Fill the table using customer query edited in
             * DataSet File.
             * Query is the JOIN of Person and Student table.
             */
            this.lookupTableAdapter.FillBy(this.projectADataSet.Lookup);
            pendingQueries = new QueriesQueue(Configuration.getInstance().getConnection());
            SaveChanges.Enabled = false;
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private async void AddStudent_Click(object sender, EventArgs e) {
            String reg = RegistrationField.Text;
            String first = FirstNameField.Text;
            String last = LastNameField.Text;
            int gender = GenderField.SelectedIndex;
            String contact = ContactField.Text;
            String Email = EmailField.Text;
            DateTime dt = DOBField.Value;
            if (AddStudent.Text == "Add Student") {
                if (Validator.Exists("Student", "RegistrationNo", reg) > 0) {
                    MessageBox.Show($"{reg} already exists");
                    return;
                }
                else if (!Validator.All(reg, first, last, gender.ToString(), contact, Email)) {
                    MessageBox.Show("Please fill all the fields");
                    return;
                }

                //Validating all the data.
                string WarningString = "";
                bool IsAnyInvalid = false;
                if (!Validator.ValidateEmail(Email)) {
                    WarningString += "* Invalid Email!\n";
                    IsAnyInvalid = true;
                }
                if (!Validator.AreDigits(contact)) {
                    WarningString += "* Invalid Contact!\n";
                    IsAnyInvalid = true;
                }
                if (!Validator.ValidateRegistrationNumber(reg)) {
                    WarningString += "* Invalid Registration Number!\n";
                    IsAnyInvalid = true;
                }

                if (IsAnyInvalid) {
                    MessageBox.Show(WarningString);
                    return;
                }

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Person VALUES(@first, @last, @contact, @email, @dob, @gender)",
                    con);
                cmd.Parameters.AddWithValue("@first", first);
                cmd.Parameters.AddWithValue("@last", last);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@dob", dt);
                cmd.Parameters.AddWithValue("@gender", gender + 1);
                await cmd.ExecuteNonQueryAsync();

                /**
                 * Finding the id of the last added Person.
                 * We used MAX because the last added Person will have
                 * the highest ID.
                 */
                cmd = new SqlCommand(@"SELECT MAX(Id) FROM Person", con);
                object id = await cmd.ExecuteScalarAsync();
                int i = int.Parse(id.ToString());
                cmd = new SqlCommand(@"INSERT INTO Student VALUES(@id, @reg)", con);
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Parameters.AddWithValue("@reg", reg);
                // Runs asynchornously
                await cmd.ExecuteNonQueryAsync();
                this.AddStudent.Text = "Add Student";
            }
            else if (AddStudent.Text == "Update Student") {
                String WarningString = "";
                var connection = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Student SET RegistrationNo=@reg WHERE RegistrationNo=@r", connection);
                if (RegistrationField.Text != row[0]) {
                    cmd.Parameters.AddWithValue("@reg", RegistrationField.Text);
                    cmd.Parameters.AddWithValue("@r", row[0]);
                    if (!Validator.ValidateRegistrationNumber(RegistrationField.Text)) {
                        WarningString += "* Invalid Registration Number\n";
                    }
                    else {
                        if (Validator.Exists("Student", "RegistrationNo", RegistrationField.Text)==0) {
                            cmd.ExecuteNonQuery();
                        }
                        else {
                            MessageBox.Show($"{RegistrationField.Text} already exists!");
                        }

                    }
                }
                // Now moving on to update the Person Table.
                String QueryString = "UPDATE Person SET";
                if (FirstNameField.Text != row[1]) {
                    QueryString += " FirstName=@first,";
                }
                if (LastNameField.Text != row[2]) {
                    QueryString += " LastName=@last,";
                }
                if (ContactField.Text != row[3]) {
                    QueryString += " Contact=@contact,";
                }
                if (EmailField.Text != row[4]) {
                    QueryString += " Email=@email,";
                }
                if (DOBField.Value.ToString() != row[5]) {
                    QueryString += " DateOfBirth=@dob,";
                }
                if (GenderField.SelectedValue.ToString() != row[6]) {
                    QueryString += " Gender=@gender,";
                }
                if (QueryString[QueryString.Length-1]==',') {
                    QueryString = QueryString.Substring(0, QueryString.Length - 1);
                    QueryString += " WHERE Id=" + GetId(RegistrationField.Text);
                    cmd = new SqlCommand(QueryString,
                        Configuration.getInstance().getConnection());
                    cmd.Parameters.AddWithValue("@first", FirstNameField.Text);
                    cmd.Parameters.AddWithValue("@last", LastNameField.Text);
                    cmd.Parameters.AddWithValue("@contact", ContactField.Text);
                    cmd.Parameters.AddWithValue("@email", EmailField.Text);
                    cmd.Parameters.AddWithValue("@dob", DOBField.Value);
                    cmd.Parameters.AddWithValue("@gender", GenderField.SelectedValue.ToString() == "Male" ? 1 : 2);
                    await cmd.ExecuteNonQueryAsync();
                }
               
                AddStudent.Text = "Add Student";
            }
            // Clear input fields after the student has been added.
            this.ClearFields();

            // Refill the table with the updated contents.
            this.FillTable();

        }
        private int GetId(string registration) {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Student WHERE RegistrationNo=@reg", Configuration.getInstance().getConnection());
            cmd.Parameters.AddWithValue("@reg", registration);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        

        private void ClearFields() {
            this.RegistrationField.Text = "";
            this.FirstNameField.Text = "";
            this.LastNameField.Text = "";
            this.ContactField.Text = "";
            this.EmailField.Text = "";
            this.GenderField.SelectedIndex = 0;
            this.DOBField.Value = DateTime.Today;
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e) {
            args = e;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            String regNo = dataGridView1.Rows[args.RowIndex].Cells[0].Value.ToString();
            DialogResult r = MessageBox.Show($"Are you sure you want to delete {regNo}?", "Delete", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes) {
                SqlCommand command;
                var connection = Configuration.getInstance().getConnection();
                // First find the id of the registration no.
                // because then we'll delete the person
                command = new SqlCommand($"SELECT Id FROM Student WHERE RegistrationNo='{regNo}'", connection);
                int id = int.Parse(command.ExecuteScalar().ToString());
                command = new SqlCommand(
                    "DELETE FROM Student WHERE RegistrationNo=@reg",
                    connection
                );
                command.Parameters.AddWithValue("@reg", regNo);
                command.ExecuteNonQuery();

                // Now delete the person
                command = new SqlCommand("DELETE FROM Person WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                // Refreshing the grid of students
                this.FillTable();
            }
        }

        private void gridMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e) {

            row = new List<string>();
            foreach(DataGridViewCell each in dataGridView1.Rows[args.RowIndex].Cells) {
                row.Add(each.Value.ToString());
            }

            // Filling up the fields of the form.
            RegistrationField.Text = row[0];
            FirstNameField.Text = row[1];
            LastNameField.Text = row[2];
            ContactField.Text = row[3];
            EmailField.Text = row[4];
            DOBField.Value = DateTime.Parse(row[5]);
            GenderField.SelectedIndex = row[6] == "Male" ? 0 : 1;

            this.AddStudent.Text = "Update Student";
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (handler==null) {
                handler = new DataGridViewCellEventHandler(ValueChanged);
                dataGridView1.CellValueChanged += handler;
            }
            registration = e.Control.Text;
        }
        void ValueChanged(object sender, DataGridViewCellEventArgs e) {
            SaveChanges.Enabled = true;
            if (e.ColumnIndex>0 && e.ColumnIndex<5) {
                this.pendingQueries.Enqueue(
                    $"UPDATE Person SET {dataGridView1.Columns[e.ColumnIndex].HeaderText}='{dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()}' WHERE Id={GetId(dataGridView1[0, e.RowIndex].Value.ToString())}");
            }
            else if (e.ColumnIndex == 0) {
                if (Validator.Exists("Student", "RegistrationNo", dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString())>0) {
                    MessageBox.Show("Registration No already exists");
                    this.FillTable();
                    return;
                }
                this.pendingQueries.Enqueue(
                    $"UPDATE Student SET RegistrationNo='{dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()}' WHERE Id={GetId(registration)}");
            }
            else {
                MessageBox.Show("Please update using fields\n 1. Right Click on row\n 2. Click Update\n 3. Update Desired Values");
                this.FillTable();
            }
        }

        private void SaveChanges_Click(object sender, EventArgs e) {
            pendingQueries.ExecuteAll();
            pendingQueries.ClearQueue();
            SaveChanges.Enabled = false;
            this.FillTable();
        }
    }
}
