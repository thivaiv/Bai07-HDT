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
            //test projector remote
            var p1 = new ProjectorRemote("MC01", "Điều khiển máy chiếu 1", "Phòng thiết bị 1", 85);
            var p2 = new ProjectorRemote("MC02", "Điều khiển máy chiếu 2", "Phòng thiết bị 1", 15);

            Console.WriteLine(p1.Id + " | pin: " + p1.BatteryLevel + " | san sang: " + p1.IsReadyForUse() + " | diem: " + p1.GetDefaultPriorityScore());
            Console.WriteLine(p2.Id + " | pin: " + p2.BatteryLevel + " | san sang: " + p2.IsReadyForUse() + " | diem: " + p2.GetDefaultPriorityScore());
        }
    }
}
