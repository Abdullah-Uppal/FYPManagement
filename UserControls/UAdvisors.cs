using System;
using FYP_Management.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FYP_Management.UserControls {
    public partial class UAdvisors : UserControl {
        DataGridViewCellContextMenuStripNeededEventArgs args;
        DataGridViewCellEventHandler handler;
        QueriesQueue pendingQueries;

        // To store previous values
        string id;
        string designation;
        string salary;
        string temp;
        public UAdvisors() {
            InitializeComponent();
            FillTable();
            pendingQueries = new QueriesQueue(Configuration.getInstance().getConnection());
            this.lookupTableAdapter.FillBy1(this.projectADataSet.Lookup);
        }
        private void ClearFields() {
            this.idField.Text = "";
            this.designationField.SelectedIndex = 0;
            this.salaryField.Text = "";
        }

        private void FillTable() {
            SqlCommand cmd = new SqlCommand("SELECT Id, CASE" +
                " WHEN Designation=6 THEN 'Professor'" +
                " WHEN Designation=7 THEN 'Associate Professor'" +
                " WHEN Designation=8 THEN 'Assisstant Professor'" +
                " WHEN Designation=9 THEN 'Lecturer'" +
                " WHEN Designation=10 THEN 'Industry Professional' END AS Designation" +
                ", Salary FROM Advisor",
                Configuration.getInstance().getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            advisorsGrid.DataSource = dt;
            //this.advisorTableAdapter.Fill(this.projectADataSet.Advisor);
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e) {
            try {
                this.lookupTableAdapter.FillBy1(this.projectADataSet.Lookup);
            }
            catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click_1(object sender, EventArgs e) {
            try {
                this.lookupTableAdapter.FillBy1(this.projectADataSet.Lookup);
            }
            catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click_2(object sender, EventArgs e) {
            try {
                this.lookupTableAdapter.FillBy1(this.projectADataSet.Lookup);
            }
            catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private async void addButton_Click(object sender, EventArgs e) {
            var con = Configuration.getInstance().getConnection();
            if (addButton.Text == "Add Advisor") {
                string query = $"INSERT INTO Advisor VALUES({this.idField.Text}, {this.designationField.SelectedIndex + 6}, {this.salaryField.Text})";
                SqlCommand cmd = new SqlCommand(query, con);
                await cmd.ExecuteNonQueryAsync();
                this.FillTable();
                ClearFields();
            }
            else {
                string query = "UPDATE Advisor SET";
                if (id != idField.Text) {
                    query += $" Id={idField.Text},";
                }
                if (designation != designationField.SelectedValue.ToString()) {
                    query += $" Designation={(designationField.SelectedIndex+6)},";
                }
                if (salary != salaryField.Text) {
                    query += $" Salary={salary},";
                }
                query = query.Substring(0, query.Length - 1);
                query += $" WHERE Id={id}";
                MessageBox.Show(query);
                new SqlCommand(query, Configuration.getInstance().getConnection()).ExecuteNonQuery();
                this.FillTable();
                this.ClearFields();
                this.addButton.Text = "Add Advisor";
            }
        }

        private void idField_TextChanged(object sender, EventArgs e) {

        }

        private void salaryField_TextChanged(object sender, EventArgs e) {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            int id = int.Parse(advisorsGrid[0, args.RowIndex].Value.ToString());

            new SqlCommand($"DELETE FROM Advisor WHERE Id={id}", Configuration.getInstance().getConnection())
                .ExecuteNonQuery();
            this.FillTable();
        }

        private void advisorsGrid_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e) {
            args = e;
        }

        private void advisorsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void advisorsGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (handler == null) {
                handler = new DataGridViewCellEventHandler(ValueChanged);
                advisorsGrid.CellValueChanged += handler;
            }
            temp = e.Control.Text;
        }
        void ValueChanged(object sender, DataGridViewCellEventArgs e) {
            SaveChanges.Enabled = true;
            int id;
            if (e.ColumnIndex == 0) {
                id = int.Parse(temp);
            }
            else if (e.ColumnIndex == 1) {
                MessageBox.Show("Please update using fields.\n Right click on row for context menu");
                advisorsGrid.CellValueChanged -= handler;
                advisorsGrid[e.ColumnIndex, e.RowIndex].Value = temp;
                return;
            }
            else {
                id = int.Parse(advisorsGrid[0, e.RowIndex].Value.ToString());
            }
            this.pendingQueries.Enqueue(
                $"UPDATE Advisor SET {advisorsGrid.Columns[e.ColumnIndex].HeaderText}={advisorsGrid[e.ColumnIndex, e.RowIndex].Value.ToString()} WHERE Id={id}");
        }

        private void SaveChanges_Click(object sender, EventArgs e) {
            pendingQueries.ExecuteAll();
            pendingQueries.ClearQueue();
            SaveChanges.Enabled = false;
            this.FillTable();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
            id = idField.Text = advisorsGrid[0, args.RowIndex].Value.ToString();
            designation = (designationField.SelectedValue = advisorsGrid[1, args.RowIndex].Value.ToString()).ToString();
            salary = salaryField.Text = advisorsGrid[2, args.RowIndex].Value.ToString();
            addButton.Text = "Update Advisor";
        }
    }
}