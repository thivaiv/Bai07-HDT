/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai07
{
    //lỗi trùng mã định danh
    public class DuplicateIdException : Exception
    {
        public string DuplicateId { get; }

        public DuplicateIdException(string duplicateId)
            : base("trùng mã định danh: " + duplicateId)
        {
            DuplicateId = duplicateId;
        }
    }

    //lỗi không tìm thấy ứng viên phù hợp
    public class NoSuitableItemException : Exception
    {
        public NoSuitableItemException(string message = "không có thiết bị phù hợp")
            : base(message)
        {
        }
    }

    //lỗi thiết bị chưa sẵn sàng để mượn
    public class DeviceNotReadyException : Exception
    {
        public string DeviceId { get; }

        public DeviceStatus CurrentStatus { get; }

        public DeviceNotReadyException(string deviceId, DeviceStatus currentStatus)
            : base("thiết bị " + deviceId + " không sẵn sàng, trạng thái: " + currentStatus)
        {
            DeviceId = deviceId;
            CurrentStatus = currentStatus;
        }
    }
}
