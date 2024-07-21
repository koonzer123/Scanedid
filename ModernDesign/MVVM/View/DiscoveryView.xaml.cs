using System.Windows.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Data.OleDb;



using System.Windows.Media;
using System.Xml;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Org.BouncyCastle.Bcpg;

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
            CalculateDays();
        }

        private void SecondDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTextBox13();
            CalculateDays();
        }

        private void UpdateTextBox13()
        {
            // ดึงข้อมูลจาก DatePicker 1
            DateTime? selectedDate1 = myDatePicker.SelectedDate;
            string dateString1 = selectedDate1.HasValue ? selectedDate1.Value.ToString("dd/MM/yyyy") : "";

            // ดึงข้อมูลจาก DatePicker 2
            DateTime? selectedDate2 = secondDatePicker.SelectedDate;
            string dateString2 = selectedDate2.HasValue ? selectedDate2.Value.ToString("dd/MM/yyyy") : "";

            // กำหนดค่าให้กับ TextBox
            YourTextBox13.Text = $"{dateString1} - {dateString2}";
        }

        private void CalculateDays()
        {
            // ดึงข้อมูลจาก DatePicker 1
            DateTime? selectedDate1 = myDatePicker.SelectedDate;

            // ดึงข้อมูลจาก DatePicker 2
            DateTime? selectedDate2 = secondDatePicker.SelectedDate;

            // คำนวณจำนวนวัน
            if (selectedDate1.HasValue && selectedDate2.HasValue)
            {
                double totalDays = (selectedDate2.Value - selectedDate1.Value).TotalDays;

                // ทำอย่างอื่น ๆ กับตัวแปร totalDays ตามต้องการ
                Console.WriteLine($"Total Days: {totalDays}");
            }
            else
            {
                Console.WriteLine("Please select dates from both DatePickers");
            }
        }
      
       










        private void ImageControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // เรียกการเลือกรูปภาพเมื่อคลิกที่ Image
            Button_Click(sender, e);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // เว้นว่างไว้เพื่อการปรับปรุงในภายหลัง
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






        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // สร้าง PrintDialog
            PrintDialog printDialog = new PrintDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (printDialog.ShowDialog() == true)
            {
                // สร้าง Page2 หรือใช้วิธีการสร้าง Page2 ที่ถูกต้อง
                Page2 page2 = new Page2();

                // รับชื่อไฟล์ PDF จาก TextBox ของคุณ (อย่าลืมตรวจสอบความถูกต้องของชื่อไฟล์)
                string FileName = YourTextBox10.Text;  // YourTextBoxForFileName ควรเป็นชื่อ TextBox ที่คุณใช้เพื่อรับชื่อไฟล์ PDF

                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    // สร้างเส้นทางสำหรับไฟล์ PDF โดยรวมชื่อไฟล์
                    string pdfFilePath = @"C:\Users\super\OneDrive\Documents\SIAM-ID\" + FileName + ".pdf";

                    // กำหนดการพิมพ์
                    printDialog.PrintVisual(page2, "พิมพ์จาก WPF");

                    // เมื่อการพิมพ์เสร็จสิ้น ให้เริ่มเปิดไฟล์ PDF ด้วยเบราวเซอร์อัตโนมัติ

                }
                else
                {
                    // ถ้าชื่อไฟล์ไม่ถูกต้องหรือไม่มีให้แจ้งเตือนผู้ใช้
                    MessageBox.Show("กรุณาใส่ชื่อไฟล์ PDF ที่ถูกต้อง");



                }
            }

        }
        private void InsertDataIntoAccessDatabase(string วัน,string เวลา ,string room, string ราคาห้องพัก, string ชื่อ, string นามสกุล, string FullName, string sex, string idNumber,string เบอร์, string ที่อยู่, MessageBoxResult messageBoxResult)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\\hoteldatabase\\Database31.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO 1 (วัน,เวลา,room,ราคาห้องพัก,ชื่อ,นามสกุล,FullName,เพศ,IDNumber,เบอร์,ที่อยู่) " +
                        "VALUES (@วัน,@เวลา,@room,@ราคาห้องพัก,@ชื่อ,@นามสกุล,@FullName,@เพศ,@IDNumber,@เบอร์,@ที่อยู่)";

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
    }
}































