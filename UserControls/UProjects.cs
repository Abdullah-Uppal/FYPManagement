using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FYP_Management.Classes;

namespace FYP_Management.UserControls {
    public partial class UProjects : UserControl {
        QueriesQueue q;
        DataGridViewCellContextMenuStripNeededEventArgs args;
        public UProjects() {
            InitializeComponent();
            q = new QueriesQueue(Configuration.getInstance().getConnection());
            this.projectTableAdapter.Fill(this.projectADataSet.Project);
            // Adding the checkboxes
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Assign?";
            checkBoxColumn.FlatStyle = FlatStyle.Standard;
            checkBoxColumn.ThreeState = false;
            
            assignGrid.Columns.Add(checkBoxColumn);
            
            DataGridViewComboBoxColumn gridComboBox = new DataGridViewComboBoxColumn();
            SqlCommand cmd = new SqlCommand("SELECT Value FROM Lookup WHERE Category='ADVISOR_ROLE'",
                Configuration.getInstance().getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            gridComboBox.HeaderText = "Advisor Role";
            gridComboBox.DataSource = dt.Tables[0];
            gridComboBox.DisplayMember = "Value";
            assignGrid.Columns.Add(gridComboBox);
            FillAssignTable();


        }

        private void FillAssignTable() {
            SqlDataAdapter da = new SqlDataAdapter(
                new SqlCommand("SELECT Id, CASE WHEN Designation=6 THEN 'Professor'" +
                " WHEN Designation=7 THEN 'Associate Professor'" +
                " WHEN Designation=8 THEN 'Assisstant Professor'" +
                " WHEN Designation=9 THEN 'Lecturer'" +
                " WHEN Designation=10 THEN 'Industry Professional' END AS Designation FROM Advisor",
                Configuration.getInstance().getConnection()));
            DataTable dt = new DataTable();
            da.Fill(dt);
            assignGrid.DataSource = dt;
        }

        private void UProjects_Load(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void addButton_Click(object sender, EventArgs e) {
            int id;
            if (addButton.Text == "Add Project") {
                string title = titleField.Text;
                string description = descriptionField.Text;
                if (title.Trim() == "" || description.Trim() == "") {
                    MessageBox.Show("Please fill all the fields.");
                    return;
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Project VALUES(@desc, @title)",
                    Configuration.getInstance().getConnection());
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                
                cmd.ExecuteNonQuery();
                LoadProjectsTable();
            }
            SqlCommand c= new SqlCommand("SELECT MAX(Id) FROM Project",
                Configuration.getInstance().getConnection());
            id = int.Parse(c.ExecuteScalar().ToString());
            for (int i = 0; i<assignGrid.RowCount; i++) {
                bool t;
                int advisorid = int.Parse(assignGrid[2, i].Value.ToString());
                string role;
                try {
                    t = assignGrid[0, i].Value.ToString() == "True" ? true : false;
                }
                catch {
                    continue;
                }
                try {
                    role = assignGrid[1, i].Value.ToString();
                }
                catch {
                    continue;
                }
                int advisorrole;
                if (role == "Main Advisor") {
                    advisorrole = 11;
                }
                else if (role == "Co-Advisor") {
                    advisorrole = 12;
                }
                else {
                    advisorrole = 14;
                }
                q.Enqueue($"INSERT INTO ProjectAdvisor VALUES({advisorid},{id},{advisorrole}, '{DateTime.Now}')");
            }
            bool all = q.ExecuteAll();
            if (!all) { MessageBox.Show("Failed to assign advisors"); }
            q.ClearQueue();
            this.LoadProjectsTable();
            ClearFields();
        }
        private void LoadProjectAdvisorsTable() {
            this.projectAdvisorTableAdapter.Fill(this.projectADataSet.ProjectAdvisor);
        }
        private void ClearFields() {
            this.titleField.Text = "";
            this.descriptionField.Text = "";
        }
        private void LoadProjectsTable() {
            this.projectTableAdapter.Fill(this.projectADataSet.Project);
        }

        private void projectGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                int id = int.Parse(projectGrid[0, e.RowIndex].Value.ToString());
                SqlCommand command = new SqlCommand($"SELECT * FROM ProjectAdvisor WHERE ProjectId={id}");
                command.Connection = Configuration.getInstance().getConnection();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.advisorsGrid.DataSource = dt;
            }
            catch { }
        }

        private void projectGrid_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e) {
            args = e;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            var con = Configuration.getInstance().getConnection();
            int id = int.Parse(projectGrid[0, args.RowIndex].Value.ToString());
            DialogResult r = MessageBox.Show($"Are you sure you want to delete GROUP: {id}?(It will do cascade deleting on GroupProjects and Project Advisor)", "Delete", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes) {
                SqlCommand cmd = new SqlCommand($"DELETE FROM ProjectAdvisor WHERE ProjectId={id}", con);
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"DELETE FROM GroupProject WHERE ProjectId={id}";
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"DELETE FROM Project WHERE Id={id}";
                cmd.ExecuteNonQuery();

                LoadProjectsTable();
                LoadProjectAdvisorsTable();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            int advisorid = int.Parse(advisorsGrid[0, args.RowIndex].Value.ToString());
            int projectid = int.Parse(advisorsGrid[1, args.RowIndex].Value.ToString());
            DialogResult r = MessageBox.Show($"Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes) {
                SqlCommand cmd = new SqlCommand($"DELETE FROM ProjectAdvisor WHERE AdvisorId={advisorid} AND ProjectId={projectid}",
                    Configuration.getInstance().getConnection());
                cmd.ExecuteNonQuery();
                LoadProjectAdvisorsTable();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
            this.titleField.Text = projectGrid[2, args.RowIndex].Value.ToString();
            this.descriptionField.Text = projectGrid[1, args.RowIndex].Value.ToString();
            CheckMarks();
        }
        private void CheckMarks() {
            // First clear the checkmarks
            for (int i = 0; i < assignGrid.RowCount; i++) {
                assignGrid[0, i].Value = false;
            }
            SqlCommand cmd = new SqlCommand($"SELECT Id FROM Advisor JOIN ProjectAdvisor ON AdvisorId=Id WHERE ProjectId={projectGrid[0, args.RowIndex].Value.ToString()}", 
                Configuration.getInstance().getConnection());
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) {
                string s = r.GetInt32(0).ToString();
                for (int i = 0; i < assignGrid.RowCount; i++) {
                    if (assignGrid[2, i].Value.ToString() == s) {
                        assignGrid[0, i].Value = true;
                    }
                }
            }
            r.Close();
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {

        }
    }
}
