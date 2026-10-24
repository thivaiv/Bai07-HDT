/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai07
{
    //lớp trừu tượng thiết bị giảng dạy
    public abstract class TeachingDevice : IIdentifiable
    {
        public string Id { get; }

        public string Name { get; }

        public string StorageLocation { get; }

        public DeviceStatus Status { get; protected set; }

        public TeachingDevice(string id, string name, string storageLocation)
        {
            //kiểm tra hợp lệ
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("mã thiết bị không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("tên thiết bị không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(storageLocation))
            {
                throw new ArgumentException("vị trí lưu trữ không được để trống.");
            }

            Id = id;
            Name = name;
            StorageLocation = storageLocation;
            Status = DeviceStatus.Available; //mặc định ban đầu sẵn sàng
        }

        //kiểm tra khả năng sẵn sàng
        public abstract bool IsReadyForUse();

        //tính điểm ưu tiên cấp phát
        public abstract double GetDefaultPriorityScore();

        //mượn thiết bị
        public void Borrow()
        {
            if (!IsReadyForUse())
            {
                throw new DeviceNotReadyException(Id, Status);
            }
            Status = DeviceStatus.Borrowed;
        }

        //trả thiết bị về kho
        public void Return()
        {
            if (Status != DeviceStatus.Borrowed)
            {
                throw new InvalidOperationException("thiết bị " + Id + " không ở trạng thái đang mượn.");
            }
            Status = DeviceStatus.Available;
        }

        public override string ToString()
        {
            return Id + " - " + Name + " (" + StorageLocation + ") | " + Status;
        }
    }
}
