/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai07
{
    //lớp cài đặt kho lưu trữ tổng quát trong bộ nhớ
    public class InMemoryRepository<T> : IRepository<T> where T : IIdentifiable
    {
        private readonly Dictionary<string, T> items = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);

        //thêm phần tử vào kho
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "phần tử không được null.");
            }
            if (string.IsNullOrWhiteSpace(item.Id))
            {
                throw new ArgumentException("mã định danh không hợp lệ.");
            }
            if (items.ContainsKey(item.Id))
            {
                throw new DuplicateIdException(item.Id);
            }
            items.Add(item.Id, item);
        }

        //xóa phần tử theo mã
        public bool Remove(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            return items.Remove(id);
        }

        //tìm phần tử theo mã
        public T FindById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return default;
            }
            items.TryGetValue(id, out var found);
            return found;
        }

        //lấy toàn bộ danh sách mà không làm lộ collection nội bộ
        public IReadOnlyList<T> GetAll()
        {
            return items.Values.ToList().AsReadOnly();
        }

        //lọc phần tử theo điều kiện
        public IReadOnlyList<T> FindAll(Predicate<T> condition)
        {
            if (condition == null)
            {
                return GetAll();
            }
            return items.Values.Where(x => condition(x)).ToList().AsReadOnly();
        }
    }
}
