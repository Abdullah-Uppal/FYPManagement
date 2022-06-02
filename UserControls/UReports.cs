using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace FYP_Management.UserControls {
    public partial class UReports : UserControl {
        SqlConnection con = Configuration.getInstance().getConnection();
        public UReports() {
            InitializeComponent();
            groupLabel.Hide();
            groupCombo.Hide();
        }

        private void LoadEvaluationsOfEachGroup() {
            SqlCommand cmd = new SqlCommand("SELECT G.GroupId, E.Id AS EvaluationId, E.Name, E.TotalMarks, G.ObtainedMarks, E.TotalWeightage, G.EvaluationDate  " +
                "FROM [Group] JOIN GroupEvaluation G ON Id=GroupId JOIN Evaluation E ON E.Id=EvaluationId " +
                "ORDER BY G.GroupId, E.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            reportGrid.DataSource = dt;
        }

        private void SavePdf(string filepath, string head) {
            FileStream file = new FileStream(filepath, FileMode.OpenOrCreate);
            Document d = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(d, file);
            d.Open();
            d.AddAuthor("FYP Management Software.");

            // Font styles
            BaseFont b = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font headfont = new iTextSharp.text.Font(b, 12, iTextSharp.text.Font.BOLD);

            Paragraph detail1 = new Paragraph("FYP Management System", new iTextSharp.text.Font(b, 14, iTextSharp.text.Font.BOLD));
            detail1.Alignment = Element.ALIGN_CENTER;
            d.Add(detail1);

            Paragraph detail = new Paragraph(head, new iTextSharp.text.Font(b, 12));
            detail.Alignment = Element.ALIGN_LEFT;
            d.Add(detail);
            PdfPTable table = new PdfPTable(reportGrid.ColumnCount);
            table.WidthPercentage = 100;
            table.SpacingBefore = 10;
            table.DefaultCell.Padding = 3;
            for (int i = 0; i<reportGrid.ColumnCount; i++) {
                table.AddCell(new Paragraph(reportGrid.Columns[i].HeaderText, headfont));
            }
            for (int i = 0; i<reportGrid.RowCount; i++) {
                for (int j = 0; j<reportGrid.ColumnCount; j++) {
                    Paragraph item = new Paragraph(reportGrid[j, i].Value.ToString(),
                        new iTextSharp.text.Font(b, 10));
                    table.AddCell(item);
                }
            }
            d.Add(table);
            d.Close();
            path.Text = filepath;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex == 0) {
                LoadEvaluationsOfEachGroup();
                groupLabel.Hide();
                groupCombo.Hide();
            }
            else if (comboBox1.SelectedIndex==1) {
                LoadProjectAdvisors();
                groupLabel.Hide();
                groupCombo.Hide();
            }
            else if (comboBox1.SelectedIndex==2) {
                LoadAllGroups();
                groupLabel.Hide();
                groupCombo.Hide();
            }
            else if (comboBox1.SelectedIndex==3) {
                groupLabel.Show();
                groupCombo.Show();
                this.groupTableAdapter.Fill(this.projectADataSet.Group);
                LoadSpecificGroup(groupCombo.SelectedValue.ToString());
            }
            else if (comboBox1.SelectedIndex == 4) {
                groupLabel.Hide();
                groupCombo.Hide();
                LoadHowManyGroups();
            }
        }
        private void LoadProjectAdvisors() {
            SqlCommand cmd = new SqlCommand("SELECT Advisor.Id, CASE " +
                "WHEN Designation=6 THEN 'Professor' " +
                "WHEN Designation=7 THEN 'Associate Professor' " +
                "WHEN Designation=8 THEN 'Assisstant Professor' " +
                "WHEN Designation=9 THEN 'Lecturer' " +
                "WHEN Designation=10 THEN 'Industry Professional' END AS Designation, Title, " +
                "CASE WHEN AdvisorRole=11 THEN 'Main Advisor' " +
                "WHEN AdvisorRole=12 THEN 'Co-Advisor' " +
                "WHEN AdvisorRole=14 THEN 'Industry Advisor' END AS AdvisorRole " +
                "FROM Advisor JOIN ProjectAdvisor ON ProjectAdvisor.AdvisorId=Advisor.Id " +
                "JOIN Project ON Project.Id=ProjectAdvisor.ProjectId", con);
            FillTable(cmd);
        }
        private void LoadHowManyGroups() {
            SqlCommand cmd = new SqlCommand("SELECT Id, Title, MAX(Description) AS Description, " +
                "COUNT(*) AS [Count] " +
                "FROM Project JOIN GroupProject " +
                "ON Id=ProjectId GROUP BY Id, Title", con);
            FillTable(cmd);
        }
        private void LoadAllGroups() {
            SqlCommand cmd = new SqlCommand("SELECT G.GroupId, S.Id AS [Student Id],S.RegistrationNo, " +
                "CONCAT_WS(' ', FirstName, LastName) AS Name, CASE WHEN Status=3 THEN 'Active' WHEN Status=4 THEN 'InActive' END AS Status " +
                "FROM GroupStudent G JOIN Student S ON G.StudentId=S.Id " +
                "JOIN Person ON Person.Id = S.Id", con);
            FillTable(cmd);
        }
        private void LoadSpecificGroup(string id) {
            SqlCommand cmd = new SqlCommand("SELECT G.GroupId, S.Id AS [Student Id],S.RegistrationNo, " +
                "CONCAT_WS(' ', FirstName, LastName) AS Name, CASE WHEN Status=3 THEN 'Active' WHEN Status=4 THEN 'InActive' END AS Status " +
                "FROM GroupStudent G JOIN Student S ON G.StudentId=S.Id " +
                $"JOIN Person ON Person.Id = S.Id WHERE GroupId={id}", con);
            FillTable(cmd);
        }
        private void FillTable(SqlCommand cmd) {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            reportGrid.DataSource = dt;
        }
        private void saveButton_Click(object sender, EventArgs e) {
            DialogResult d = saveFileDialog1.ShowDialog();
            string filepath = saveFileDialog1.FileName;
            string head = comboBox1.SelectedItem.ToString();
            MessageBox.Show(head);
            SavePdf(filepath, head);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {

        }

        private void openButton_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(path.Text);
        }

        private void groupCombo_SelectedValueChanged(object sender, EventArgs e) {
            try {
                LoadSpecificGroup(groupCombo.SelectedValue.ToString());
            }
            catch { }
        }
    }
}
