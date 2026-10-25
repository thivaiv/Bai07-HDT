/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai07
{
    //micro không dây
    public class WirelessMicrophone : TeachingDevice
    {
        public int BatteryLevel { get; }

        public int SignalQuality { get; }

        public WirelessMicrophone(string id, string name, string storageLocation, int batteryLevel, int signalQuality)
            : base(id, name, storageLocation)
        {
            //kiểm tra pin và chất lượng tín hiệu
            if (batteryLevel < 0 || batteryLevel > 100)
            {
                throw new ArgumentException("mức pin phải từ 0 đến 100.");
            }
            if (signalQuality < 0 || signalQuality > 100)
            {
                throw new ArgumentException("chất lượng tín hiệu phải từ 0 đến 100.");
            }

            BatteryLevel = batteryLevel;
            SignalQuality = signalQuality;
        }

        //sẵn sàng khi available, pin >= 30% và tín hiệu >= 40%
        public override bool IsReadyForUse()
        {
            return Status == DeviceStatus.Available && BatteryLevel >= 30 && SignalQuality >= 40;
        }

        //điểm ưu tiên bằng trung bình cộng của pin và tín hiệu
        public override double GetDefaultPriorityScore()
        {
            return (BatteryLevel + SignalQuality) / 2.0;
        }
    }
}
