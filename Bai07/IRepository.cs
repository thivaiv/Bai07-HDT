/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai07
{
    //interface kho lưu trữ generic
    public interface IRepository<T> where T : IIdentifiable
    {
        void Add(T item);

        bool Remove(string id);

        T FindById(string id);

        IReadOnlyList<T> GetAll();

        IReadOnlyList<T> FindAll(Predicate<T> condition);
    }
}
