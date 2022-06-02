using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using FYP_Management.Classes;
using System.Collections.Generic;

namespace FYP_Management.UserControls {
    public partial class UGroups : UserControl {
        SqlConnection con = Configuration.getInstance().getConnection();
        QueriesQueue q;
        DataGridViewCellContextMenuStripNeededEventArgs args;
        public UGroups() {
            InitializeComponent();
            q = new QueriesQueue(con);

            FillGroups();
            // Adding the checkboxes
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Add?";
            checkBoxColumn.FlatStyle = FlatStyle.Standard;
            checkBoxColumn.ThreeState = false;

            assignStudentGrid.Columns.Add(checkBoxColumn);
            FillAssignStudent();
            FillActualStudents();
            FillGroupProjects();
            FillCombo();
        }
        public void FillCombo() {
            this.projectTableAdapter.FillBy1(this.projectADataSet.Project);
        }
        private void FillAssignStudent() {
            SqlCommand cmd = new SqlCommand("SELECT Student.*, FirstName FROM Student JOIN Person ON Student.Id=Person.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            assignStudentGrid.DataSource = dt;
        }
        private void CheckMarks() {
            // First clear the checkmarks
            for (int i = 0; i < assignStudentGrid.RowCount; i++) {
                    assignStudentGrid[0, i].Value = false;
            }
            SqlCommand cmd = new SqlCommand($"SELECT StudentId FROM GroupStudent WHERE GroupId={groupCombo.SelectedValue}", con);
            SqlDataReader r =cmd.ExecuteReader();
            while(r.Read()) {
                string s = r.GetInt32(0).ToString();
                for (int i = 0; i < assignStudentGrid.RowCount; i++) {
                    if (assignStudentGrid[1, i].Value.ToString() == s) {
                        assignStudentGrid[0, i].Value = true;
                    }
                }
            }
            r.Close();
        }
        private void FillGroups() {
            this.groupTableAdapter.Fill(this.projectADataSet.Group);
        }

        private void FillGroupProjects() {
            SqlCommand cmd = new SqlCommand("SELECT GroupId, ProjectId, Title, AssignmentDate FROM Project JOIN GroupProject ON Project.Id=GroupProject.ProjectId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            groupProjectsGrid.DataSource = dt;
        }

        private void FillActualStudents() {
            SqlCommand cmd = new SqlCommand("SELECT GroupId, Student.Id, RegistrationNo, CASE WHEN Status=3 THEN 'Active' WHEN Status=4 THEN 'Inactive' END AS Status, AssignmentDate FROM Student JOIN GroupStudent ON StudentId=Student.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            actualStudents.DataSource = dt;
        }

        private void FillActualStudents(int groupid) {
            SqlCommand cmd = new SqlCommand($"SELECT GroupId, Student.Id, RegistrationNo, CASE WHEN Status=3 THEN 'Active' WHEN Status=4 THEN 'Inactive' END AS Status, AssignmentDate FROM Student JOIN GroupStudent ON StudentId=Student.Id WHERE GroupId={groupid}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            actualStudents.DataSource = dt;
            CheckMarks();
        }

        private void createGroupButton_Click(object sender, EventArgs e) {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [Group] VALUES('{DateTime.UtcNow}')", con);
            cmd.ExecuteNonQuery();
            FillGroups();
        }

        private void savebutton_Click(object sender, EventArgs e) {
            int groupid = int.Parse(groupCombo.SelectedValue.ToString());
            for (int i = 0; i < assignStudentGrid.RowCount; i++) {
                bool t;
                int studentid = int.Parse(assignStudentGrid[1, i].Value.ToString());
                try {
                    t = assignStudentGrid[0, i].Value.ToString() == "True" ? true : false;
                    if (!t) {
                        q.Enqueue($"DELETE FROM GroupStudent WHERE StudentId={studentid} AND GroupId={groupid}");
                        continue;
                    }
                }
                catch {
                    continue;
                }
                q.Enqueue($"INSERT INTO GroupStudent VALUES({groupid},{studentid},3,'{DateTime.UtcNow}')");
            }
            bool all = q.ExecuteAll();
            q.ClearQueue();
            FillAssignStudent();
            FillActualStudents(groupid);
        }

        private void groupsGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            FillActualStudents(int.Parse(groupsGrid[0, e.RowIndex].Value.ToString()));
        }

        private void groupsGrid_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e) {
            args = e;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            int groupid = int.Parse(groupsGrid[0, args.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand($"DELETE FROM GroupStudent WHERE GroupId={groupid}", con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"DELETE FROM [Group] WHERE Id={groupid}";
            cmd.ExecuteNonQuery();
            FillGroups();
            FillActualStudents();
        }
        private void tabs_TabIndexChanged(object sender, EventArgs e) {
            FillCombo();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e) {
            try {
                this.projectTableAdapter.FillBy(this.projectADataSet.Project);
            }
            catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e) {
            try {
                this.projectTableAdapter.FillBy1(this.projectADataSet.Project);
            }
            catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void panel4_DragEnter(object sender, DragEventArgs e) {
            FillCombo();
        }

        private void projectIdField_Click(object sender, EventArgs e) {
            FillCombo();
        }

        private void addButton_Click(object sender, EventArgs e) {
            int groupid = int.Parse(groupCombo.SelectedValue.ToString());
            int projectid = int.Parse(projectIdField.SelectedValue.ToString()
                .Split('-')[0]);

            SqlCommand cmd = new SqlCommand($"INSERT INTO GroupProject VALUES({projectid},{groupid},'{DateTime.UtcNow}')", con);
            cmd.ExecuteNonQuery();
            FillGroupProjects();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            int groupid = int.Parse(groupProjectsGrid[0, args.RowIndex].Value.ToString());
            int projectid = int.Parse(groupProjectsGrid[1, args.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand($"DELETE FROM GroupProject WHERE GroupId={groupid} AND ProjectId={projectid}", con);
            cmd.ExecuteNonQuery();
            FillGroupProjects();
        }
    }
}
