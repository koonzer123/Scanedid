    using PdfSharp.Pdf;
    using PdfSharp.Drawing;
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Data.OleDb;
    using System.Globalization;
    using System.Printing;
    using System.Diagnostics;
    using PdfSharp.Drawing.Layout;
    using PdfSharp;

    namespace ModernDesign.MVVM.View
    {
        public partial class Page2 : Page
        {
            private Grid maingrid;

            public Grid MainGrid
            {
                get { return maingrid; }
            }
            public Page2()
            {
                InitializeComponent();
                LoadDataFromDatabase();
            }
        public void ExportToPdf(string fileName)
        {
            try
            {
                // Create a PdfDocument and add a page
                PdfDocument pdfDocument = new PdfDocument();

                // Set the size of the PDF page to A4
                PdfPage pdfPage = pdfDocument.AddPage();
                pdfPage.Size = PageSize.A4;

                // Create an XGraphics object from the PdfPage
                XGraphics xGraphics = XGraphics.FromPdfPage(pdfPage);

                // Measure and arrange mainGrid to get the desired size
                mainGrid.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                mainGrid.Arrange(new Rect(0, 0, mainGrid.DesiredSize.Width, mainGrid.DesiredSize.Height));

                // Set the size of the PDF page based on the mainGrid size
                pdfPage.Width = XUnit.FromPoint(mainGrid.DesiredSize.Width);
                pdfPage.Height = XUnit.FromPoint(mainGrid.DesiredSize.Height);

                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                    (int)mainGrid.ActualWidth, (int)mainGrid.ActualHeight, 96, 96, PixelFormats.Default);

                renderTargetBitmap.Render(mainGrid);

                // Create an XImage from the RenderTargetBitmap
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    encoder.Save(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    XImage xImage = XImage.FromStream(memoryStream);

                    // Draw the image on the PDF page
                    xGraphics.DrawImage(xImage, 0, 0, pdfPage.Width.Point, pdfPage.Height.Point);

                    // Save the PDF document to the specified file path
                    pdfDocument.Save(fileName);
                }

                MessageBox.Show("PDF file saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }









        private void OpenPdfWithChrome(string pdfFilePath)
            {
                // Start the process to open the PDF file with Chrome
                Process.Start("chrome.exe", pdfFilePath);

                // Shutdown the application
                Application.Current.Shutdown();
            }


        

       


            // การเรียกใช้งาน


            private void ShowIDNumberOnLabels(string IDNumber)
            {
                // ตรวจสอบว่า Id number มีพอสำหรับแสดงผลใน Label หรือไม่
                if (IDNumber.Length >= 7)
                {
                    // แสดงผลลัพธ์ใน Label ตัวแรก
                    เลข1.Content = IDNumber[1].ToString();

                    // แสดงผลลัพธ์ใน Label ตัวที่สอง
                    เลข2.Content = IDNumber[2].ToString();

                    // แสดงผลลัพธ์ใน Label ตัวที่สาม
                    เลข3.Content = IDNumber[3].ToString();
                    เลข4.Content = IDNumber[4].ToString();
                    เลข5.Content = IDNumber[5].ToString();
                    เลข6.Content = IDNumber[6].ToString();
                    เลข7.Content = IDNumber[7].ToString();
                    เลข8.Content = IDNumber[8].ToString();
                    เลข9.Content = IDNumber[9].ToString();
                    เลข10.Content = IDNumber[10].ToString();
                    เลข11.Content = IDNumber[11].ToString();
                    เลข12.Content = IDNumber[12].ToString();
                    เลข13.Content = IDNumber[13].ToString();

                    // ... ทำต่อไปตามลำดับ
                }
            }

      

            private void LoadDataFromDatabase()
            {
                DateTime? วัน2DateTime = null;

                // แทนตัวแปร ConnectionString ด้วย connection string จริงของคุณ
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\super\\Desktop\\Database31.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // แทน SQL query ด้วยคำสั่งที่ต้องการ
                    string query = "SELECT ชื่อ, นามสกุล,IDNumber,เบอร์,ที่อยู่,room,วัน,เวลา FROM [รร3] ORDER BY ID DESC";
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

                                DateTime วันDateTime;
                                if (DateTime.TryParseExact(วันงับ, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out วันDateTime))
                                {
                                    // การแปลงสำเร็จ
                                    วัน2DateTime = วันDateTime.AddDays(1);
                                    // ทำตามที่คุณต้องการ
                                }
                                else
                                {
                                    // การแปลงล้มเหลว
                                    // ปรับปรุงโค้ดเพื่อจัดการกับการแปลงล้มเหลวได้ตามที่คุณต้องการ
                                    Console.WriteLine("การแปลงวันที่ล้มเหลว");
                                }

                                // กำหนดค่าให้กับ Label
                                ชื่อ.Content = ชื่อValue;
                                นามสกุล.Content = นามสกุลValue;
                                โทรศัพท์.Content = เบอร์;
                                ที่อยู่.Content = ที่อบู่งับ;
                                ห้อง.Content = roomงับ;
                                วัน.Content = วันงับ;
                                วัน2.Content = วัน2DateTime.HasValue ? วัน2DateTime.Value.ToString("dd/MM/yyyy") : "";
                                เวลา.Content = เวลางับ + "น.";
                                เวลา2.Content = "12:00 น.";

                                ShowIDNumberOnLabels(IDNumber);

                                // Export to PDF
                            
                            }

                            // ... (โค้ดที่เหลือเหมือนเดิม)
                        }
                    }
                }
            }
        }
    }
