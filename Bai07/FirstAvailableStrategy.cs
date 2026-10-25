/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System.Collections.Generic;

namespace Bai07
{
    //chiến lược chọn đối tượng đầu tiên trong danh sách ứng viên
    public class FirstAvailableStrategy<T> : ISelectionStrategy<T>
    {
        public T Select(IReadOnlyList<T> candidates)
        {
            //kiểm tra danh sách ứng viên
            if (candidates == null || candidates.Count == 0)
            {
                throw new NoSuitableItemException("không có ứng viên phù hợp.");
            }

            return candidates[0];
        }
    }
}
