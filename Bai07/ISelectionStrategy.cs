/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System.Collections.Generic;

namespace Bai07
{
    //interface chiến lược lựa chọn ứng viên generic
    public interface ISelectionStrategy<T>
    {
        T Select(IReadOnlyList<T> candidates);
    }
}
