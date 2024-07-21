using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace ModernDesign.MVVM.View
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }
        private void ShowIDNumberOnLabels(string IDNumber)
        {
            // ตรวจสอบว่า Id number มีพอสำหรับแสดงผลใน Label หรือไม่
            if (IDNumber.Length >= 7)
            {
                // แสดงผลลัพธ์ใน Label ตัวแรก
                เลข1.Content = IDNumber[0].ToString();

                // แสดงผลลัพธ์ใน Label ตัวที่สอง
                เลข2.Content = IDNumber[1].ToString();

                // แสดงผลลัพธ์ใน Label ตัวที่สาม
                เลข3.Content = IDNumber[2].ToString();
                เลข4.Content = IDNumber[3].ToString();
                เลข5.Content = IDNumber[4].ToString();
                เลข6.Content = IDNumber[5].ToString();
                เลข7.Content = IDNumber[6].ToString();
                เลข8.Content = IDNumber[7].ToString();
                เลข9.Content = IDNumber[8].ToString();
                เลข10.Content = IDNumber[9].ToString();
                เลข11.Content = IDNumber[10].ToString();
                เลข12.Content = IDNumber[11].ToString();
                เลข13.Content = IDNumber[12].ToString();
               

                // ... ทำต่อไปตามลำดับ
            }
        }

        private void LoadDataFromDatabase()
        {
            // แทนตัวแปร ConnectionString ด้วย connection string จริงของคุณ
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\\hoteldatabase\\Database31.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // แทน SQL query ด้วยคำสั่งที่ต้องการ
                string query = "SELECT ชื่อ, นามสกุล,IDNumber,เบอร์,ที่อยู่,room,วัน,เวลา FROM [1] ORDER BY ID DESC";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // ดึงข้อมูลจากฐานข้อมูล
                            string ชื่อValue = reader["ชื่อ"].ToString();
                            string นามสกุลValue = reader["นามสกุล"].ToString();
                            string IDNumber = reader["IDNumber"].ToString();
                            string เบอร์ = reader["เบอร์"].ToString();
                            string ที่อบู่งับ = reader["ที่อยู่"].ToString();
                            string roomงับ = reader["room"].ToString();
                            string วันงับ = reader["วัน"].ToString();
                            string เวลางับ = reader["เวลา"].ToString();

                            DateTime วันDateTime = DateTime.Parse(วันงับ);
                            DateTime วัน2DateTime = วันDateTime.AddDays(1);



                            // กำหนดค่าให้กับ Label
                            ชื่อ.Content = ชื่อValue;
                            นามสกุล.Content = นามสกุลValue;
                            โทรศัพท์.Content = เบอร์;
                            ที่อยู่.Content = ที่อบู่งับ;
                            ห้อง.Content = roomงับ;
                            วัน.Content = วันงับ;
                            วัน2.Content = วัน2DateTime.ToString("dd/MM/yyyy");
                            เวลา.Content = เวลางับ+"น.";
                            เวลา2.Content ="12:00 น.";

                            
                            ShowIDNumberOnLabels(IDNumber);
                        }
                    }

                }


            }

        }
    }

}

