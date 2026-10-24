/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai07
{
    class Program
    {
        static void Main(string[] args)
        {
            //test air conditioner remote
            var ac = new AirConditionerRemote("DH01", "Điều khiển điều hòa 1", "Phòng thiết bị 2", new[] { "A203", "A204" });
            Console.WriteLine(ac.Id + " | san sang: " + ac.IsReadyForUse() + " | phong A203: " + ac.IsCompatibleWith("A203") + " | phong B101: " + ac.IsCompatibleWith("B101"));
        }
    }
}
