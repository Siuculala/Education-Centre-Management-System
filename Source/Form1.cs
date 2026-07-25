using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private RecordManager manager = new RecordManager();
        private string filePath = "records.txt";

        public Form1()
        {
            InitializeComponent();
            SetupComboBoxes();
            UpdateRoleFields();
            SetupGrid();

            if (!manager.LoadFromFile(filePath, out string errorMessage))
            {
                MessageBox.Show("Could not load data:\n" + errorMessage);
            }
            else if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show("Some records could not be loaded:\n" + errorMessage);
            }

            RefreshGrid();
        }
        private void SetupGrid()
        {
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecords.MultiSelect = false;
            dgvRecords.ReadOnly = true;
            dgvRecords.AllowUserToAddRows = false;
        }



        private void SetupComboBoxes()
        {
            // Role ComboBox for Add/Update record
            cmbRole.Items.Clear();
            cmbRole.Items.Add(Role.Teacher);
            cmbRole.Items.Add(Role.Admin);
            cmbRole.Items.Add(Role.Student);
            cmbRole.SelectedIndex = 0;

            // Filter ComboBox for DataGridView
            cmbFilterRole.Items.Clear();
            cmbFilterRole.Items.Add("All");
            cmbFilterRole.Items.Add(Role.Teacher);
            cmbFilterRole.Items.Add(Role.Admin);
            cmbFilterRole.Items.Add(Role.Student);
            cmbFilterRole.SelectedIndex = 0;

            // EmploymentType ComboBox for Admin
            cmbExtra3.Items.Clear();
            cmbExtra3.Items.Add(EmploymentType.FullTime);
            cmbExtra3.Items.Add(EmploymentType.PartTime);
            cmbExtra3.SelectedIndex = 0;

            // Hide this first. It will only show when Role = Admin.
            cmbExtra3.Visible = false;
        }

        private void SaveData()
        {
            if (!manager.SaveToFile(filePath, out string errorMessage))
            {
                MessageBox.Show("Could not save data:\n" + errorMessage);
            }
        }

        private bool IsLettersAndSpacesOnly(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return value.All(c => char.IsLetter(c) || c == ' ');
        }

        private bool IsDigitsOnly(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return value.All(c => char.IsDigit(c));
        }

        private bool IsValidSimpleEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                if (!(char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-'))
                {
                    return false;
                }
            }

            return value.Contains("@") && value.Contains(".");
        }

        private bool ValidateTextInput()
        {
            string name = txtName.Text.Trim();
            string telephone = txtTelephone.Text.Trim();
            string email = txtEmail.Text.Trim();

            string extra1 = txtExtra1.Text.Trim();
            string extra2 = txtExtra2.Text.Trim();
            string extra3 = txtExtra3.Text.Trim();

            if (!IsLettersAndSpacesOnly(name))
            {
                MessageBox.Show("Name can contain letters and spaces only.");
                txtName.Focus();
                return false;
            }

            if (!IsDigitsOnly(telephone))
            {
                MessageBox.Show("Telephone can contain numbers only.");
                txtTelephone.Focus();
                return false;
            }

            if (!IsValidSimpleEmail(email))
            {
                MessageBox.Show("Email is invalid. Only letters, numbers, @, ., _ and - are allowed.");
                txtEmail.Focus();
                return false;
            }

            Role selectedRole = (Role)cmbRole.SelectedItem;

            if (selectedRole == Role.Teacher)
            {
                if (!IsLettersAndSpacesOnly(extra2) ||
                    !IsLettersAndSpacesOnly(extra3))
                {
                    MessageBox.Show("Subjects can contain letters and spaces only.");
                    return false;
                }
            }
            else if (selectedRole == Role.Student)
            {
                if (!IsLettersAndSpacesOnly(extra1) ||
                    !IsLettersAndSpacesOnly(extra2) ||
                    !IsLettersAndSpacesOnly(extra3))
                {
                    MessageBox.Show("Subjects can contain letters and spaces only.");
                    return false;
                }
            }

            return true;
        }
        private void cmbFilterRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            string selectedRoleFilter = cmbFilterRole.SelectedItem.ToString();

            List<Person> result = manager.GetAllRecords()
                .Where(p =>
                    (
                        string.IsNullOrWhiteSpace(keyword) ||
                        p.RecordId.ToString().Contains(keyword) ||
                        p.Name.ToLower().Contains(keyword) ||
                        p.Telephone.ToLower().Contains(keyword) ||
                        p.Email.ToLower().Contains(keyword)
                    )
                    &&
                    (
                        selectedRoleFilter == "All" ||
                        p.Role.ToString() == selectedRoleFilter
                    )
                )
                .ToList();

            DisplayRecords(result);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvRecords.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecordId.Text))
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            int recordId = int.Parse(txtRecordId.Text);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool deleted = manager.DeleteRecordById(recordId);

                if (deleted)
                {
                    SaveData();
                    RefreshGrid();
                    ClearForm();
                    MessageBox.Show("Record deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Record not found.");
                }
            }
        }

        private void UpdateRoleFields()
        {
            if (cmbRole.SelectedItem == null)
            {
                return;
            }

            Role selectedRole = (Role)cmbRole.SelectedItem;

            txtExtra1.Visible = true;
            txtExtra2.Visible = true;
            txtExtra3.Visible = true;
            cmbExtra3.Visible = false;

            if (selectedRole == Role.Teacher)
            {
                lblExtra1.Text = "Salary:";
                lblExtra2.Text = "Subject 1:";
                lblExtra3.Text = "Subject 2:";
            }
            else if (selectedRole == Role.Admin)
            {
                lblExtra1.Text = "Salary:";
                lblExtra2.Text = "Working Hours:";
                lblExtra3.Text = "Employment Type:";

                txtExtra3.Visible = false;
                cmbExtra3.Visible = true;
            }
            else if (selectedRole == Role.Student)
            {
                lblExtra1.Text = "Subject 1:";
                lblExtra2.Text = "Subject 2:";
                lblExtra3.Text = "Subject 3:";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateTextInput())
            {
                return;
            }    

            Role selectedRole = (Role)cmbRole.SelectedItem;

            Person newPerson;

            if (selectedRole == Role.Teacher)
            {
                if (!double.TryParse(txtExtra1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double salary))
                {
                    MessageBox.Show("Please enter a valid salary.");
                    return;
                }

                newPerson = new Teacher
                {
                    Role = Role.Teacher,
                    Name = txtName.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Salary = salary,
                    Subject1 = txtExtra2.Text.Trim(),
                    Subject2 = txtExtra3.Text.Trim()
                };
            }
            else if (selectedRole == Role.Admin)
            {
                if (!double.TryParse(txtExtra1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double salary) ||
                !double.TryParse(txtExtra2.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double workingHours))
                {
                    MessageBox.Show("Please enter valid Salary and Working Hours.");
                    return;
                }

                newPerson = new Admin
                {
                    Role = Role.Admin,
                    Name = txtName.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Salary = salary,
                    WorkingHours = workingHours,
                    EmploymentType = (EmploymentType)cmbExtra3.SelectedItem
                };
            }
            else
            {
                newPerson = new Student
                {
                    Role = Role.Student,
                    Name = txtName.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Subject1 = txtExtra1.Text.Trim(),
                    Subject2 = txtExtra2.Text.Trim(),
                    Subject3 = txtExtra3.Text.Trim()
                };
            }

            manager.AddRecord(newPerson);
            SaveData();
            RefreshGrid();

            MessageBox.Show("Record added successfully.");
        }

        private void DisplayPersonInForm(Person person)
        {
            txtRecordId.Text = person.RecordId.ToString();
            txtName.Text = person.Name;
            txtTelephone.Text = person.Telephone;
            txtEmail.Text = person.Email;
            cmbRole.SelectedItem = person.Role;

            UpdateRoleFields();

            if (person is Teacher teacher)
            {
                txtExtra1.Text = teacher.Salary.ToString(CultureInfo.InvariantCulture);
                txtExtra2.Text = teacher.Subject1;
                txtExtra3.Text = teacher.Subject2;
            }
            else if (person is Admin admin)
            {
                txtExtra1.Text = admin.Salary.ToString(CultureInfo.InvariantCulture);
                txtExtra2.Text = admin.WorkingHours.ToString(CultureInfo.InvariantCulture);
                cmbExtra3.SelectedItem = admin.EmploymentType;
            }
            else if (person is Student student)
            {
                txtExtra1.Text = student.Subject1;
                txtExtra2.Text = student.Subject2;
                txtExtra3.Text = student.Subject3;
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int selectedId = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells["ID"].Value);

            Person selectedPerson = manager.GetRecordById(selectedId);

            if (selectedPerson != null)
            {
                DisplayPersonInForm(selectedPerson);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Check if a record is selected first
            if (string.IsNullOrWhiteSpace(txtRecordId.Text))
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            // 2. Convert Record ID safely
            if (!int.TryParse(txtRecordId.Text, out int recordId))
            {
                MessageBox.Show("Invalid Record ID.");
                return;
            }

            // 3. Find the selected record
            Person person = manager.GetRecordById(recordId);

            if (person == null)
            {
                MessageBox.Show("Record not found.");
                return;
            }

            // 4. Check role before validating role-specific fields
            Role selectedRole = (Role)cmbRole.SelectedItem;

            if (selectedRole != person.Role)
            {
                MessageBox.Show("Role cannot be changed when updating an existing record.");

                // Restore the original data to avoid confusing fields
                DisplayPersonInForm(person);

                return;
            }

            // 5. Validate text input
            if (!ValidateTextInput())
            {
                return;
            }

            // 6. Store common fields in temporary variables first
            string newName = txtName.Text.Trim();
            string newTelephone = txtTelephone.Text.Trim();
            string newEmail = txtEmail.Text.Trim();

            // 7. Validate role-specific fields first, then update the real object
            if (person is Teacher teacher)
            {
                if (!double.TryParse(txtExtra1.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double newSalary))
                {
                    MessageBox.Show("Please enter a valid salary.");
                    return;
                }

                string newSubject1 = txtExtra2.Text.Trim();
                string newSubject2 = txtExtra3.Text.Trim();

                // Only assign after all Teacher inputs are valid
                person.Name = newName;
                person.Telephone = newTelephone;
                person.Email = newEmail;

                teacher.Salary = newSalary;
                teacher.Subject1 = newSubject1;
                teacher.Subject2 = newSubject2;
            }
            else if (person is Admin admin)
            {
                if (!double.TryParse(txtExtra1.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double newSalary) ||
                    !double.TryParse(txtExtra2.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double newWorkingHours))
                {
                    MessageBox.Show("Please enter valid Salary and Working Hours.");
                    return;
                }

                EmploymentType newEmploymentType = (EmploymentType)cmbExtra3.SelectedItem;

                // Only assign after all Admin inputs are valid
                person.Name = newName;
                person.Telephone = newTelephone;
                person.Email = newEmail;

                admin.Salary = newSalary;
                admin.WorkingHours = newWorkingHours;
                admin.EmploymentType = newEmploymentType;
            }
            else if (person is Student student)
            {
                string newSubject1 = txtExtra1.Text.Trim();
                string newSubject2 = txtExtra2.Text.Trim();
                string newSubject3 = txtExtra3.Text.Trim();

                // Only assign after all Student inputs are valid
                person.Name = newName;
                person.Telephone = newTelephone;
                person.Email = newEmail;

                student.Subject1 = newSubject1;
                student.Subject2 = newSubject2;
                student.Subject3 = newSubject3;
            }

            SaveData();
            RefreshGrid();

            MessageBox.Show("Record updated successfully.");
        }


        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoleFields();
        }

        private void DisplayRecords(List<Person> recordsToShow)
        {
            dgvRecords.DataSource = null;

            dgvRecords.DataSource = recordsToShow
                .Select(p => new
                {
                    ID = p.RecordId,
                    p.Name,
                    p.Telephone,
                    p.Email,
                    p.Role,

                    Salary = p is Teacher teacher
                        ? teacher.Salary.ToString("0.00", CultureInfo.InvariantCulture)
                        : p is Admin admin
                            ? admin.Salary.ToString("0.00", CultureInfo.InvariantCulture)
                            : "-"
                })
                .ToList();
        }

        private void RefreshGrid()
        {
            DisplayRecords(manager.GetAllRecords());

            int teacherCount = manager.GetAllRecords().Count(p => p.Role == Role.Teacher);
            int adminCount = manager.GetAllRecords().Count(p => p.Role == Role.Admin);
            int studentCount = manager.GetAllRecords().Count(p => p.Role == Role.Student);

            lblStatus.Text = "Status: " + manager.GetAllRecords().Count +
                             " records — " + teacherCount + " Teacher, " +
                             adminCount + " Admin, " +
                             studentCount + " Student";
        }

        private void ClearForm()
        {
            txtRecordId.Clear();
            txtName.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();

            cmbRole.SelectedIndex = 0;

            txtExtra1.Clear();
            txtExtra2.Clear();
            txtExtra3.Clear();

            cmbExtra3.SelectedIndex = 0;

            UpdateRoleFields();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbDetail_Enter(object sender, EventArgs e)
        {

        }
    }
}
