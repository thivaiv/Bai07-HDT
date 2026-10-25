/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai07
{
    //dịch vụ cấp phát thiết bị tổng quát
    public class AllocationService<T> where T : TeachingDevice
    {
        private readonly IRepository<T> repository;
        private ISelectionStrategy<T> strategy;

        public AllocationService(IRepository<T> repository, ISelectionStrategy<T> strategy)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        //thay đổi chiến lược lựa chọn lúc đang chạy
        public void ChangeStrategy(ISelectionStrategy<T> newStrategy)
        {
            strategy = newStrategy ?? throw new ArgumentNullException(nameof(newStrategy));
        }

        //cấp phát thiết bị
        public T Allocate(Predicate<T> additionalCondition = null)
        {
            //1. lấy toàn bộ thiết bị từ kho
            var allDevices = repository.GetAll();

            //2 và 3. lọc thiết bị sẵn sàng và thỏa mãn điều kiện bổ sung
            var candidates = new List<T>();
            foreach (var device in allDevices)
            {
                if (device != null && device.IsReadyForUse())
                {
                    if (additionalCondition == null || additionalCondition(device))
                    {
                        candidates.Add(device);
                    }
                }
            }

            //4. dùng chiến lược hiện tại để chọn thiết bị
            T selected = strategy.Select(candidates.AsReadOnly());

            //5. chuyển trạng thái thiết bị sang borrowed
            selected.Borrow();

            //6. trả về thiết bị đã cấp phát
            return selected;
        }
    }
}
