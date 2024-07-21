using System;
using System.IO;

class Program
{
    static void Main2(string[] args)
    {
        // ระบุเส้นทางของไฟล์ที่คุณต้องการอ่าน
        string filePath = "C:\\Users\\super\\OneDrive\\Documents\\SIAM-ID\\data.txt";

        try
        {
            // ใช้ StreamReader เพื่ออ่านไฟล์ข้อความ
            using (StreamReader reader = new StreamReader(filePath))
            {
                // อ่านเนื้อหาของไฟล์และแสดงผลบรรทัดละบรรทัด
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"เกิดข้อผิดพลาดในการอ่านไฟล์: {ex.Message}");
        }
    }
}
