/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai07
{
    class Program
    {
        static void Main(string[] args)
        {
            //test wireless microphone
            var m1 = new WirelessMicrophone("MIC01", "Micro 1", "Phòng thiết bị 3", 80, 90);
            var m2 = new WirelessMicrophone("MIC02", "Micro 2", "Phòng thiết bị 3", 20, 80);
            var m3 = new WirelessMicrophone("MIC03", "Micro 3", "Phòng thiết bị 3", 80, 30);

            Console.WriteLine(m1.Id + " | san sang: " + m1.IsReadyForUse() + " | diem: " + m1.GetDefaultPriorityScore());
            Console.WriteLine(m2.Id + " | san sang: " + m2.IsReadyForUse() + " | diem: " + m2.GetDefaultPriorityScore());
            Console.WriteLine(m3.Id + " | san sang: " + m3.IsReadyForUse() + " | diem: " + m3.GetDefaultPriorityScore());
        }
    }
}
