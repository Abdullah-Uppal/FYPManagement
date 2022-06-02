using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using FYP_Management.Classes;
using System.Data;

namespace FYP_Management.UserControls {
    public partial class UEvaluations : UserControl {
        DataGridViewCellContextMenuStripNeededEventArgs args;
        SqlConnection con;
        DataGridViewCellEventHandler handler;
        string temp;
        QueriesQueue pendingQueries;
        public UEvaluations() {
            InitializeComponent();
            con = Configuration.getInstance().getConnection();
            FillEvaluations();
            FillGroupEvaluation();
            pendingQueries = new QueriesQueue(con);
            SaveChanges.Enabled = false;
        }
        private void FillEvaluations() {
            this.evaluationTableAdapter.Fill(this.projectADataSet.Evaluation);
        }
        private void FillGroupCombo() {
            this.groupTableAdapter.Fill(this.projectADataSet.Group);
        }
        private void evaluationsGrid_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e) {
            args = e;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            int id = int.Parse(evaluationsGrid[0, args.RowIndex].Value.ToString());

            SqlCommand cmd = new SqlCommand($"DELETE FROM GroupEvaluation WHERE EvaluationId={id}", con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"DELETE FROM Evaluation WHERE Id={id}";
            cmd.ExecuteNonQuery();
            FillEvaluations();
            FillGroupEvaluation();
        }

        private void button1_Click(object sender, EventArgs e) {
            string name = nameField.Text;
            int totalMarks = (int)totalMarksField.Value;
            int totalWeightage = (int)totalWeightageField.Value;
            SqlCommand cmd = new SqlCommand($"INSERT INTO Evaluation VALUES('{name}',{totalMarks}, {totalWeightage})", con);
            cmd.ExecuteNonQuery();
            FillEvaluations();
            // Test Comment
        }
        private void FillGroupEvaluation() {
            this.groupEvaluationTableAdapter.Fill(this.projectADataSet.GroupEvaluation);
            dataGridView1.DataSource = this.projectADataSet.GroupEvaluation;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void groupField_Click(object sender, EventArgs e) {
            FillGroupCombo();
        }

        private void button2_Click(object sender, EventArgs e) {
            int groupid;
            try {
                groupid = int.Parse(groupField.SelectedValue.ToString());
            }
            catch {
                MessageBox.Show("Please select group id");
                return;
            }
            int evaluationid = int.Parse(evaluationCombo.SelectedValue.ToString());
            int obtained = (int)obtainedMarksField.Value;
            string date = dateField.Value.ToString();
            SqlCommand cmd = new SqlCommand($"INSERT INTO GroupEvaluation VALUES({groupid},{evaluationid}, {obtained},'{date}')", con);
            try {
                cmd.ExecuteNonQuery();
            }
            catch {
                MessageBox.Show("Cannot create duplicate composite key");
            }
            FillGroupEvaluation();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e) {
            try {
                this.evaluationTableAdapter.FillBy(this.projectADataSet.Evaluation);
            }
            catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void markEvaluationToolStripMenuItem_Click(object sender, EventArgs e) {
            evaluationCombo.SelectedValue = evaluationsGrid[0, args.RowIndex].Value.ToString();
            tabPages.SelectedIndex = 1;
        }

        private void evaluationsGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (handler == null) {
                handler = new DataGridViewCellEventHandler(ValueChanged);
                evaluationsGrid.CellValueChanged += handler;
            }
            temp = e.Control.Text;
        }
        void ValueChanged(object sender, DataGridViewCellEventArgs e) {
            SaveChanges.Enabled = true;
            int id;
            if (e.ColumnIndex == 0) {
                MessageBox.Show("Can't Update ID");
                evaluationsGrid.CellValueChanged -= handler;
                evaluationsGrid[0, e.RowIndex].Value = temp;
                return;
            }
            id = int.Parse(evaluationsGrid[0, e.RowIndex].Value.ToString());
            this.pendingQueries.Enqueue(
                $"UPDATE Evaluation SET {evaluationsGrid.Columns[e.ColumnIndex].HeaderText}='{evaluationsGrid[e.ColumnIndex, e.RowIndex].Value.ToString()}' WHERE Id={id}");
        }

        private void SaveChanges_Click(object sender, EventArgs e) {
            pendingQueries.ExecuteAll();
            pendingQueries.ClearQueue();
            SaveChanges.Enabled = false;
            this.FillEvaluations();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            int groupid = int.Parse(dataGridView1[0, args.RowIndex].Value.ToString());
            int ev_id = int.Parse(dataGridView1[1, args.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand($"DELETE FROM GroupEvaluation WHERE EvaluationId={ev_id} AND GroupId={groupid}", con);
            cmd.ExecuteNonQuery();
            FillGroupEvaluation();
        }

        
        private void button3_Click(object sender, EventArgs e) {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM GroupEvaluation WHERE GroupId={groupField1.SelectedValue}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e) {
            FillGroupEvaluation();
        }
    }
}
