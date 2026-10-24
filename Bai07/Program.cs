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
            //test ngoai le
            var ex1 = new DuplicateIdException("DEV01");
            Console.WriteLine(ex1.DuplicateId);

            var ex2 = new NoSuitableItemException();
            Console.WriteLine(ex2.Message);

            var ex3 = new DeviceNotReadyException("DEV02", DeviceStatus.UnderMaintenance);
            Console.WriteLine(ex3.DeviceId + " - " + ex3.CurrentStatus);
        }
    }
}
