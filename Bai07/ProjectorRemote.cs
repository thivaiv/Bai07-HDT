/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai07
{
    //điều khiển máy chiếu
    public class ProjectorRemote : TeachingDevice
    {
        public int BatteryLevel { get; }

        public ProjectorRemote(string id, string name, string storageLocation, int batteryLevel)
            : base(id, name, storageLocation)
        {
            //kiểm tra mức pin
            if (batteryLevel < 0 || batteryLevel > 100)
            {
                throw new ArgumentException("mức pin phải từ 0 đến 100.");
            }
            BatteryLevel = batteryLevel;
        }

        //sẵn sàng khi available và pin >= 20%
        public override bool IsReadyForUse()
        {
            return Status == DeviceStatus.Available && BatteryLevel >= 20;
        }

        //điểm ưu tiên bằng mức pin
        public override double GetDefaultPriorityScore()
        {
            return BatteryLevel;
        }
    }
}
