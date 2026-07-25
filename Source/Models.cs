
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;

namespace WinFormsApp
{
        enum Role // lưu trữ nhóm người
        {
            Teacher,
            Admin,
            Student
        }

        enum EmploymentType // lưu trữ loại hình làm vc
        {
            FullTime,
            PartTime
        }

        // Person
        abstract class Person //nếu viết theo kiểu bthg thì mỗi mục phải có field riêng, muốn có sp thì tạo lớp con
        {
            // tạo các field để lưu dữ liệu (thường gọi là thuộc tính)
            private static int nextId = 1; // static field dùng để tự động cấp ID cho mỗi record, một bản ai cũng dùng chung đc


            // tạo constructor (chạy để gán dữ liệu ban đầu)
            public Person()
            {
                RecordId = nextId; // person nhận số từ máy đếm 
                nextId++;// tăng cho person kế tiếp 
            }


            public Person(int recordId)
            {
                RecordId = recordId;
            }



            public int RecordId { get; private set; }// chỉ get(bên ngoài không set được chỉ constructor bên trong set)

            internal static void SetNextId(int nextValue)
            {
                nextId = nextValue < 1 ? 1 : nextValue;
            }
            // name
            public string Name { get; set; }

            //telephone
            public string Telephone { get; set; }

            //email
            public string Email { get; set; }

            //Role
            public Role Role { get; set; }


            // virtual
            public virtual void DisplayInfo()
            {
                Console.WriteLine($"ID: {RecordId} | Name: {Name} | Tel: {Telephone} " +
                    $"| Email: {Email} | Role: {Role}");
            }

            public virtual void UpdateInfo()
            {
                Name = InputHelper.ReadString("Enter new Name: ");
                Telephone = InputHelper.ReadString("Enter new Telephone: ");
                Email = InputHelper.ReadString("Enter new Email: ");
            }


        }

        // class con Teacher kế thừa từ Person=(salary, subject1, subject2)                                               
        class Teacher : Person
        {

            public Teacher()
            {
            }

            public Teacher(int recordId) : base(recordId)
            {
            }
        //get, set cho salary(double)       
        public double Salary { get; set; }

            //get, set cho sub1
            public string Subject1 { get; set; }

            //get, set cho sub2
            public string Subject2 { get; set; }

            public override void DisplayInfo()
            {
                // in phần chung (ID, name, tel, email, role)
                base.DisplayInfo();
                Console.WriteLine($"   Salary: {Salary} | Subject1: {Subject1} | Subject2: {Subject2}");
            }

            public override void UpdateInfo()
            {
                // in phần chung (ID, name, tel, email)
                base.UpdateInfo();
                Salary = InputHelper.ReadDouble("Enter new Salary: ");
                Subject1 = InputHelper.ReadString("Enter new Subject1: ");
                Subject2 = InputHelper.ReadString("Enter new Subject2: ");


            }
        }

        class Admin : Person
        {
            public Admin()
            {
            }

            public Admin(int recordId) : base(recordId)
            {
            }
        public double Salary { get; set; }

            public double WorkingHours { get; set; }

            public EmploymentType EmploymentType { get; set; }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"   Salary: {Salary} | WorkingHours: {WorkingHours} | EmploymentType: {EmploymentType}");
            }

            public override void UpdateInfo()
            {
                base.UpdateInfo();
                Salary = InputHelper.ReadDouble("Enter new Salary: ");
                WorkingHours = InputHelper.ReadDouble("Enter new WorkingHours: ");
                EmploymentType = InputHelper.ReadEmploymentType("Enter FullTime or PartTime: ");
            }
        }

        class Student : Person
        {
            public Student()
            {
            }

            public Student(int recordId) : base(recordId)
            {
            }
        public string Subject1 { get; set; }
            public string Subject2 { get; set; }
            public string Subject3 { get; set; }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($" Subject1: {Subject1} | Subject2: {Subject2} | Subject3: {Subject3}");
            }

            public override void UpdateInfo()
            {
                base.UpdateInfo();

                Subject1 = InputHelper.ReadString("Enter new Subject1: ");
                Subject2 = InputHelper.ReadString("Enter new Subject2: ");
                Subject3 = InputHelper.ReadString("Enter new Subject3: ");

            }
        }

        class RecordManager
        {
            // GUI dùng: trả về danh sách để đổ vào DataGridView (không in console)
            public List<Person> GetAllRecords()
            {
                return records;
            }
            // danh sách chứa tất cả — số lượng không biết trước
            private List<Person> records = new List<Person>(); // records cái tủ đựng 

            

        //AddRecord (thêm person cho vào list)
            public void AddRecord(Person person)
            {
                records.Add(person);
                Console.WriteLine("Record added successfully.");
            }

            public void ViewAllRecords()
            {
                if (records.Count == 0)
                {
                    Console.WriteLine("No records found.");
                    return;
                }

                foreach (Person p in records)
                {
                    p.DisplayInfo();
                    Console.WriteLine();
                }
            }

            public void ViewRecordsByRole(Role role)//cần biết LỌC ROLE NÀO → tham số role
            {
                int found = 0;
                foreach (Person p in records)
                {
                    if (p.Role == role)
                    {
                        p.DisplayInfo();
                        Console.WriteLine();
                        found++;
                    }

                }

                if (found == 0)   // duyệt HẾT tủ mới kết luận
                {
                    Console.WriteLine("No records found for this role.");
                }
            }

            public Person GetRecordById(int recordId)
            {
                return records.FirstOrDefault(p => p.RecordId == recordId);
            }

        public bool DeleteRecordById(int recordId)
        {
            Person person = GetRecordById(recordId);

            if (person == null)
            {
                return false;
            }

            records.Remove(person);
            return true;
        }

        public bool SaveToFile(string filePath, out string errorMessage)
        {
            errorMessage = "";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Person person in records)
                    {
                        if (person is Teacher teacher)
                        {
                            writer.WriteLine(
                                teacher.RecordId + "|" +
                                "Teacher|" +
                                teacher.Name + "|" +
                                teacher.Telephone + "|" +
                                teacher.Email + "|" +
                                teacher.Salary.ToString(CultureInfo.InvariantCulture) + "|" +
                                teacher.Subject1 + "|" +
                                teacher.Subject2
                            );
                        }
                        else if (person is Admin admin)
                        {
                            writer.WriteLine(
                                admin.RecordId + "|" +
                                "Admin|" +
                                admin.Name + "|" +
                                admin.Telephone + "|" +
                                admin.Email + "|" +
                                admin.Salary.ToString(CultureInfo.InvariantCulture) + "|" +
                                admin.WorkingHours.ToString(CultureInfo.InvariantCulture) + "|" +
                                admin.EmploymentType
                            );
                        }
                        else if (person is Student student)
                        {
                            writer.WriteLine(
                                student.RecordId + "|" +
                                "Student|" +
                                student.Name + "|" +
                                student.Telephone + "|" +
                                student.Email + "|" +
                                student.Subject1 + "|" +
                                student.Subject2 + "|" +
                                student.Subject3
                            );
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool LoadFromFile(string filePath, out string errorMessage)
        {
            errorMessage = "";

            try
            {
                records.Clear();

                if (!File.Exists(filePath))
                {
                    Person.SetNextId(1);
                    return true;
                }

                int maxId = 0;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    int lineNumber = 0;

                    while (!reader.EndOfStream)
                    {
                        lineNumber++;

                        string line = reader.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        string[] parts = line.Split('|');

                        if (parts.Length != 8)
                        {
                            errorMessage +=
                                "Line " + lineNumber + ": invalid data format.\n";
                            continue;
                        }

                        if (!int.TryParse(parts[0], out int recordId) || recordId < 1)
                        {
                            errorMessage +=
                                "Line " + lineNumber + ": invalid Record ID.\n";
                            continue;
                        }

                        string roleText = parts[1];

                        if (roleText == "Teacher")
                        {
                            if (!double.TryParse(
                                parts[5],
                                NumberStyles.Float,
                                CultureInfo.InvariantCulture,
                                out double salary))
                            {
                                errorMessage +=
                                    "Line " + lineNumber + ": invalid Teacher salary.\n";
                                continue;
                            }

                            Teacher teacher = new Teacher(recordId)
                            {
                                Role = Role.Teacher,
                                Name = parts[2],
                                Telephone = parts[3],
                                Email = parts[4],
                                Salary = salary,
                                Subject1 = parts[6],
                                Subject2 = parts[7]
                            };

                            records.Add(teacher);
                        }
                        else if (roleText == "Admin")
                        {
                            if (!double.TryParse(
                                    parts[5],
                                    NumberStyles.Float,
                                    CultureInfo.InvariantCulture,
                                    out double salary) ||
                                !double.TryParse(
                                    parts[6],
                                    NumberStyles.Float,
                                    CultureInfo.InvariantCulture,
                                    out double workingHours))
                            {
                                errorMessage +=
                                    "Line " + lineNumber +
                                    ": invalid Admin salary or working hours.\n";
                                continue;
                            }

                            if (!Enum.TryParse(
                                parts[7],
                                true,
                                out EmploymentType employmentType))
                            {
                                errorMessage +=
                                    "Line " + lineNumber +
                                    ": invalid Employment Type.\n";
                                continue;
                            }

                            Admin admin = new Admin(recordId)
                            {
                                Role = Role.Admin,
                                Name = parts[2],
                                Telephone = parts[3],
                                Email = parts[4],
                                Salary = salary,
                                WorkingHours = workingHours,
                                EmploymentType = employmentType
                            };

                            records.Add(admin);
                        }
                        else if (roleText == "Student")
                        {
                            Student student = new Student(recordId)
                            {
                                Role = Role.Student,
                                Name = parts[2],
                                Telephone = parts[3],
                                Email = parts[4],
                                Subject1 = parts[5],
                                Subject2 = parts[6],
                                Subject3 = parts[7]
                            };

                            records.Add(student);
                        }
                        else
                        {
                            errorMessage +=
                                "Line " + lineNumber + ": invalid role.\n";
                            continue;
                        }

                        if (recordId > maxId)
                        {
                            maxId = recordId;
                        }
                    }
                }

                Person.SetNextId(maxId + 1);

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }


        // private: chỉ trong class RecordManager, chỉ Edit/Delete dùng — người ngoài không gọi
        private Person FindById(int recordId)
            {
                return records.FirstOrDefault(p => p.RecordId == recordId);
            }


            public void EditRecord(int recordId)
            {
                Person person = FindById(recordId);   // nhờ helper tìm

                if (person == null)
                {
                    Console.WriteLine("The ID does not exist.");
                    return;
                }

                person.UpdateInfo();   // đa hình: Teacher/Admin/Student tự chạy đúng bản
                Console.WriteLine("Record updated successfully.");
            }

            public void DeleteRecord(int recordId)
            {
                Person person = FindById(recordId);

                if (person == null)
                {
                    Console.WriteLine("The ID does not exist.");
                    return;
                }

                person.DisplayInfo();   // cho xem sắp xóa ai
                Console.Write("Are you sure? (yes/no): ");
                string confirm = Console.ReadLine();

                if (confirm == "yes")
                {
                    records.Remove(person);
                    Console.WriteLine("Record deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Delete cancelled.");
                }
            }

        }

        static class InputHelper
        {
            public static string ReadString(string prompt)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Input cannot be empty. Please enter again: ");
                    input = Console.ReadLine();
                }
                return input;
            }

            public static double ReadDouble(string prompt)
            {
                Console.Write(prompt);
                double result;
                while (!double.TryParse(Console.ReadLine(), out result) || result < 0)
                {
                    Console.Write("Invalid number (must not be negative). Please enter again: ");
                }
                return result;
            }

            public static int ReadInt(string prompt)
            {
                Console.Write(prompt);
                int result;
                while (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.Write("Invalid number. Please enter again: ");
                }
                return result;
            }

            public static Role ReadRole(string prompt)
            {
                Console.Write(prompt);
                while (true)
                {
                    string input = Console.ReadLine();
                    // hợp lệ khi: parse được TÊN enum, VÀ không phải số thuần
                    if (Enum.TryParse(input, true, out Role result) && !int.TryParse(input, out _))
                    {
                        return result;
                    }
                    Console.Write("Invalid role. Enter Teacher/Admin/Student: ");
                }
            }

            public static EmploymentType ReadEmploymentType(string prompt)
            {
                Console.Write(prompt);
                EmploymentType result;
                while (!Enum.TryParse(Console.ReadLine(), true, out result))
                {
                    Console.Write("Invalid input. Enter FullTime or PartTime: ");
                }
                return result;
            }
        

        }
}
