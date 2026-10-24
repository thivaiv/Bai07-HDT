/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai07
{
    //điều khiển điều hòa
    public class AirConditionerRemote : TeachingDevice
    {
        private readonly HashSet<string> compatibleRooms;

        public IReadOnlySet<string> CompatibleRooms => compatibleRooms;

        public AirConditionerRemote(string id, string name, string storageLocation, IEnumerable<string> compatibleRooms)
            : base(id, name, storageLocation)
        {
            this.compatibleRooms = new HashSet<string>(compatibleRooms ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
        }

        //kiểm tra tương thích với phòng
        public bool IsCompatibleWith(string roomId)
        {
            if (string.IsNullOrWhiteSpace(roomId))
            {
                return false;
            }
            return compatibleRooms.Contains(roomId);
        }

        //chỉ sẵn sàng khi trạng thái là available
        public override bool IsReadyForUse()
        {
            return Status == DeviceStatus.Available;
        }

        //điểm ưu tiên mặc định
        public override double GetDefaultPriorityScore()
        {
            return 100;
        }
    }
}
