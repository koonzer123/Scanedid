using System.Windows.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

using System.Data.OleDb;
using ThaiNationalIDCard;


using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using System.Windows.Markup;










using System.Collections.Generic;
using System.Linq;

using static SupportClass;
using System.Globalization;
using System.Windows.Media;
using System.Printing;
using System.Windows.Xps;

namespace ModernDesign.MVVM.View
{
    public partial class DiscoveryView : UserControl
    {
        public DiscoveryView()
        {
            InitializeComponent();
            // เพิ่มเหตุการณ์ Click ให้กับ Image
            ImageControl.MouseLeftButtonDown += ImageControl_MouseLeftButtonDown;

        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ไฟล์รูปภาพ|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.InitialDirectory = @"C:\Users\super\OneDrive\Documents\SIAM-ID"; // ตั้งค่าโฟลเดอร์เริ่มต้นที่คุณต้องการ
            openFileDialog.FileName = YourTextBox10.Text;

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;

                    // สร้าง BitmapImage เพื่อโหลดรูปภาพ
                    BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));

                    // กำหนดภาพให้กับ Image Control
                    ImageControl.Source = bitmapImage;


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}");
                }
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTextBox13();
            // Add any additional logic you want to execute when the DatePicker's selected date changes.
        }

        private void SecondDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTextBox13();
            CalculateDaysAndUpdatePrice();
            // Add any additional logic you want to execute when the SecondDatePicker's selected date changes.
        }



        private void UpdateTextBox13()
        {
            // Remove the event handler to prevent recursive calls
            YourTextBox13.TextChanged -= TextBox_TextChanged;

            // ดึงข้อมูลจาก DatePicker 1
            DateTime? selectedDate1 = myDatePicker.SelectedDate;

            // ดึงข้อมูลจาก DatePicker 2
            DateTime? selectedDate2 = secondDatePicker.SelectedDate;

            // คำนวณจำนวนวันระหว่างวันที่
            if (selectedDate1.HasValue && selectedDate2.HasValue)
            {
                double totalDays = (selectedDate2.Value - selectedDate1.Value).TotalDays;

                // อัปเดต YourTextBox13 ด้วยวันที่ในรูปแบบที่ต้องการ
                YourTextBox13.Text = $"{selectedDate1:dd/MM/yyyy} - {selectedDate2:dd/MM/yyyy}";

                // อัปเดต YourTextBox13_Copy ด้วยจำนวนวันที่คำนวณได้
                YourTextBox13_Copy.Text = totalDays.ToString();
            }
            else
            {
                YourTextBox13.Text = "กรุณาเลือกวันที่จากทั้งสอง DatePickers";
                YourTextBox13_Copy.Text = "";
            }

            // Re-attach the event handler
            YourTextBox13.TextChanged += TextBox_TextChanged;
        }






        private void CalculateDaysAndUpdatePrice()
        {
            // ดึงข้อมูลจาก DatePicker 1
            DateTime? selectedDate1 = myDatePicker.SelectedDate;

            // ดึงข้อมูลจาก DatePicker 2
            DateTime? selectedDate2 = secondDatePicker.SelectedDate;

            // คำนวณจำนวนวัน
            if (selectedDate1.HasValue && selectedDate2.HasValue)
            {
                double totalDays = (selectedDate2.Value - selectedDate1.Value).TotalDays;

                // รับค่าราคาจาก YourTextBox11
                double roomPrice;
                if (double.TryParse(YourTextBox11.Text, out roomPrice))
                {
                    // คำนวณราคารวม
                    double totalPrice = totalDays * roomPrice;

                    // อัปเดต YourTextBox11_Copy ด้วยผลลัพธ์ที่คำนวณได้
                    YourTextBox11_Copy.Text = totalPrice.ToString("0.00");
                }
                else
                {
                    YourTextBox11_Copy.Text = "กรุณาใส่ราคาห้องให้ถูกต้อง";
                }

                // อัปเดต YourTextBox13 หรืออื่น ๆ ตามที่ต้องการ
            }
            else
            {
                YourTextBox11_Copy.Text = "กรุณาเลือกวันที่จากทั้งสอง DatePickers";
            }
        }


















        private void ImageControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // เรียกการเลือกรูปภาพเมื่อคลิกที่ Image
            Button_Click(sender, e);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // เรียกเมธอดเพื่อคำนวณราคาตามเรทห้องและจำนวนวัน
            CalculateDaysAndUpdatePrice();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void SaveDataToFile_Click(object sender, RoutedEventArgs e)
        {
            // ดึงวันที่ที่ผู้ใช้เลือกจาก DatePicker



            // มีวันที่ที่ถูกเลือก


            // ทำสิ่งที่คุณต้องการกับวันที่, ว่าต้องนำไปใช้ในการบันทึกข้อมูลหรืออะไรก็ตาม
            string วัน = YourTextBox8.Text;
            string เวลา = YourTextBox9.Text;
            string room = YourTextBox12.Text;
            string ราคาห้องพัก = YourTextBox11.Text;
            string ชื่อ = YourTextBox2.Text;
            string นามสกุล = YourTextBox33.Text;
            string FullName = YourTextBox3.Text;//string room = YourTextBox2.Text; // Replace with the appropriate TextBox names
            string sex = YourTextBox5.Text;
            string idNumber = YourTextBox10.Text;
            string เบอร์ = เบอร์งับ.Text;
            string ที่อยู่ = YourTextBox6.Text;
            
            // string roomPrice = YourTextBox2.Text; // Replace with the appropriate TextBox names
            // Replace with the appropriate TextBox names
            // Replace with the appropriate TextBox namesง

            // Replace with the appropriate TextBox names

            // Call the method with all parameters
            string checkInDate = YourTextBox8.Text;
            string bookingDate = YourTextBox9.Text;

            InsertDataIntoAccessDatabase(
                วัน,
                เวลา,
                room,
                ราคาห้องพัก,
                ชื่อ,
                นามสกุล,
                FullName,
                sex,
                idNumber,
                เบอร์,
                ที่อยู่,





            MessageBox.Show("Data saved to the database successfully."));;
        }


        // Change the method signature to match RoutedEventHandle

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have an instance of the Page2 class
            Page2 page2Instance = new Page2();

            // Specify the path and filename to save the PDF file
            string pdfFilePath = @"C:\Users\super\Desktop\YourPage.pdf"; // Update the path and filename

            // Export the content of Page2 to a PDF file
            page2Instance.ExportToPdf(pdfFilePath);

            // Open the PDF file with Chrome
            OpenPdfWithChrome(pdfFilePath);

            MessageBox.Show("PDF file saved and opened successfully.");
        }










        private void OpenPdfWithChrome(string pdfFilePath)
        {
            // เริ่มกระบวนการเปิดไฟล์ PDF ด้วย Chrome
            Process.Start("chrome.exe", pdfFilePath);

            // หยุดการทำงานของแอปพลิเคชัน
            Application.Current.Shutdown();
        }















        private void ExportButton_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                string dateText = YourTextBox8.Text;

                if (string.IsNullOrWhiteSpace(dateText))
                {
                    MessageBox.Show("Please enter a valid date in YourTextBox8");
                    return;
                }

                // Parse the date from YourTextBox8
                if (DateTime.TryParseExact(dateText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    // Extract the month from the date
                    string month = date.ToString("dd");

                    // Construct the filename based on the month
                    string filePath = $@"C:\เดือน1\{month}.xlsx";

                    // Check if the file exists before opening
                    if (File.Exists(filePath))
                    {
                        // Open the existing Excel file
                        Process.Start("excel.exe", $@"""{filePath}"" /p");
                    }
                    else
                    {
                        MessageBox.Show("The specified Excel file does not exist.");
                    }

                    MessageBox.Show("กำลังสั่งปริ้นเอกสาร...");
                }
                else
                {
                    MessageBox.Show("Invalid date format in YourTextBox8. Please use dd/MM/yyyy.");
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"เกิดข้อผิดพลาดในการสั่งปริ้นเอกสาร: {ex.Message}");
            }
        }

        public void ReadCard()
        {
            ThaiIDCard idcard = new ThaiIDCard();
            Personal personal = idcard.readAll();
            if (personal != null)
            {
                YourTextBox10.Text = $" {personal.Citizenid}";
                YourTextBox33.Text = $" {personal.Th_Firstname}";
                YourTextBox2.Text = $" {personal.Th_Lastname}";
                YourTextBox5.Text = (personal.Sex == "1") ? "ชาย" : (personal.Sex == "2") ? "หญิง" : "";
                YourTextBox3.Text = $" {personal.En_Firstname + " " + personal.En_Lastname}";
                YourTextBox4.Text = $"{personal.Birthday.Date.ToString("dd/MM/yyyy")}";
                int age = CalculateAge(personal.Birthday);
                YourTextBox7.Text = $"{age} ปี";
                YourTextBox6.Text = $" {personal.Address}";

                YourTextBox8.Text = $"{DateTime.Now.ToString("dd/MM/yyyy")}";
                YourTextBox9.Text = $"{DateTime.Now.ToString("HH:mm")}";
            }
            else if (idcard.ErrorCode() > 0)
            {
                YourTextBox13.Text = $"Error: {idcard.Error()}";
            }
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthdate.Year;

            // Check if the birthday has occurred this year
            if (currentDate.Month < birthdate.Month || (currentDate.Month == birthdate.Month && currentDate.Day < birthdate.Day))
            {
                age--;
            }

            return age;
        }
       







        private void ButtonReadCard_Click(object sender, RoutedEventArgs e)
        {
            ReadCard();
        }



        private void InsertDataIntoAccessDatabase(string วัน, string เวลา, string room, string ราคาห้องพัก, string ชื่อ, string นามสกุล, string FullName, string sex, string idNumber, string เบอร์, string ที่อยู่, MessageBoxResult messageBoxResult)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\super\\Desktop\\Database31.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO รร3 (วัน,เวลา,room,ราคาห้องพัก,ชื่อ,นามสกุล,FullName,เพศ,IDNumber,เบอร์,ที่อยู่) " +
                        "VALUES (@วัน,@เวลา,@room,@ราคาห้องพัก,@ชื่อ,@นามสกุล,@FullName,@เพศ,@IDNumber,@เบอร์,@ที่อยู่)";

                    string insertQuery2 = "INSERT INTO รร4 (วันที่,ห้องพักเลขที่,ชื่อนามสกุล,สัญชาติ,บัตร,ที่อยู่,อาชีพ,มาจาก,จะไปที่,วันที่ออก,หมายเหตุ) " +
                        "VALUES (@วันที่,@ห้องพักเลขที่,@ชื่อนามสกุล,@สัญชาติ,@บัตร,@ที่อยู่,@อาชีพ,@มาจาก,@จะไปที่,@วันที่ออก,@หมายเหตุ)";


                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@วัน", วัน);
                        command.Parameters.AddWithValue("@เวลา", เวลา);
                        command.Parameters.AddWithValue("@room", room);
                        command.Parameters.AddWithValue("@ราคาห้องพัก", ราคาห้องพัก);
                        command.Parameters.AddWithValue("@นามสกุล", นามสกุล);
                        command.Parameters.AddWithValue("@ชื่อ", ชื่อ);
                        command.Parameters.AddWithValue("@FullName", FullName);
                        command.Parameters.AddWithValue("@เพศ", sex);
                        command.Parameters.AddWithValue("@IDNumber", idNumber);
                        command.Parameters.AddWithValue("@เบอร์", เบอร์);
                        command.Parameters.AddWithValue("@ที่อยู่", ที่อยู่);

                        command.ExecuteNonQuery();
                    }
                    using (OleDbCommand command = new OleDbCommand(insertQuery2, connection))
                    {
                        command.Parameters.AddWithValue("@วันที่", วัน);
                        command.Parameters.AddWithValue("@ห้องพักเลขที่", room);
                        command.Parameters.AddWithValue("@ชื่อนามสกุล", ชื่อ + นามสกุล);
                        command.Parameters.AddWithValue("@สัญชาติ", "");
                        command.Parameters.AddWithValue("@บัตร", idNumber);
                        command.Parameters.AddWithValue("@ที่อยู่", ที่อยู่);
                        command.Parameters.AddWithValue("@อาชีพ", "");
                        command.Parameters.AddWithValue("@มาจาก", "");
                        command.Parameters.AddWithValue("@จะไปที่", "");
                        command.Parameters.AddWithValue("@วันที่ออก", เบอร์);
                        command.Parameters.AddWithValue("@หมายเหตุ", "");
                        command.ExecuteNonQuery();
                    }

                    DateTime dateTimeValue;

                    // ตรวจสอบว่า TextBox มีข้อมูลวันที่ถูกต้องหรือไม่
                    if (DateTime.TryParseExact(YourTextBox8.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeValue))
                    {
                        // สร้างชื่อตารางจากเดือน
                        string tableName = $"{dateTimeValue.ToString("MM")}";

                        // แทนที่ชื่อตารางใน query
                        string insertQuery3 = $"INSERT INTO {tableName} (วันที่, ห้องพักเลขที่, ชื่อนามสกุล, สัญชาติ, บัตร, ที่อยู่, อาชีพ, มาจาก, จะไปที่, วันที่ออก, หมายเหตุ) " +
                            "VALUES (@วันที่,@ห้องพักเลขที่,@ชื่อนามสกุล,@สัญชาติ,@บัตร,@ที่อยู่,@อาชีพ,@มาจาก,@จะไปที่,@วันที่ออก,@หมายเหตุ)";

                        using (OleDbCommand command = new OleDbCommand(insertQuery3, connection))
                        {
                            command.Parameters.AddWithValue("@วันที่", YourTextBox8.Text);
                            command.Parameters.AddWithValue("@ห้องพักเลขที่", room);
                            command.Parameters.AddWithValue("@ชื่อนามสกุล", ชื่อ + นามสกุล);
                            command.Parameters.AddWithValue("@สัญชาติ", "");
                            command.Parameters.AddWithValue("@บัตร", idNumber);
                            command.Parameters.AddWithValue("@ที่อยู่", ที่อยู่);
                            command.Parameters.AddWithValue("@อาชีพ", "");
                            command.Parameters.AddWithValue("@มาจาก", "");
                            command.Parameters.AddWithValue("@จะไปที่", "");
                            command.Parameters.AddWithValue("@วันที่ออก", เบอร์);
                            command.Parameters.AddWithValue("@หมายเหตุ", "");

                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("รูปแบบวันที่ไม่ถูกต้อง");
                    }
                }

                catch (Exception ex)
                {
                    // จัดการข้อผิดพลาด
                    MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มข้อมูล: " + ex.Message);
                }
                finally
                {
                    // ปิดการเชื่อมต่อในทุกกรณี
                    connection.Close();
                }
            }
        }




        private void RemoveDataToFile_Click(object sender, RoutedEventArgs e)
        {
            // Clear the text of all relevant textboxes
            YourTextBox8.Text = "";
            YourTextBox9.Text = "";
            YourTextBox11.Text = "";
            YourTextBox12.Text = "";
            YourTextBox2.Text = "";
            YourTextBox33.Text = "";
            YourTextBox3.Text = "";
            YourTextBox5.Text = "";
            YourTextBox10.Text = "";
            YourTextBox4.Text = "";
                YourTextBox7.Text = "";
            เบอร์งับ.Text = "";
            YourTextBox13.Text = "";
            YourTextBox13_Copy.Text = "";


            YourTextBox6.Text = "";
            // Add more textboxes as needed

            // Optionally, you can also clear the ImageControl
            

            // Add any other logic you want to execute when the button is clicked
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            selectedCheckBoxes.Add(checkBox);
            UpdateComboBoxText();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            selectedCheckBoxes.Remove(checkBox);
            UpdateComboBoxText();

        }


        private void UpdateComboBoxText()
        {
            int sumA = 0;
            int sumB = 0;

            List<string> selectedItemsA = new List<string>();
            List<string> selectedItemsB = new List<string>();

            if (selectedCheckBoxes.Count > 0)
            {
                foreach (CheckBox checkBox in selectedCheckBoxes)
                {
                    string content = checkBox.Content.ToString();
                    if (content.StartsWith("A"))
                    {
                        int number;
                        if (int.TryParse(content.Substring(1), out number))
                        {
                            sumA += 490;
                            selectedItemsA.Add(content);
                        }
                    }
                    else if (content.StartsWith("B") || content.StartsWith("C"))
                    {
                        sumB += 570;
                        selectedItemsB.Add(content);


                    }
                    Total = sumA + sumB;
                }
            }
            else
            {
                Total = 0;
            }

            YourTextBox11.Text = Total.ToString();
            List<string> allSelectedItems = selectedItemsA.Concat(selectedItemsB).OrderBy(item => item).ToList();
            YourTextBox12.Text = string.Join(", ", allSelectedItems);



            comboBox.Text = string.Join(", ", selectedItemsB);
        }









        private List<CheckBox> selectedCheckBoxes = new List<CheckBox>();
        private int Total;
        private double originalRoomPrice;
    }
   


    
}































