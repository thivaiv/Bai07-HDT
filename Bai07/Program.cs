/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai07
{
    class Program
    {
        static void Main(string[] args)
        {
            //test repo
            var repo = new InMemoryRepository<ProjectorRemote>();
            repo.Add(new ProjectorRemote("MC01", "Máy chiếu 1", "Kho 1", 90));
            repo.Add(new ProjectorRemote("MC02", "Máy chiếu 2", "Kho 1", 10));

            Console.WriteLine("so luong: " + repo.GetAll().Count);
            Console.WriteLine("tim MC01: " + (repo.FindById("MC01") != null));
            Console.WriteLine("tim MC99: " + (repo.FindById("MC99") != null));

            try
            {
                repo.Add(new ProjectorRemote("MC01", "Trùng", "Kho 1", 50));
            }
            catch (DuplicateIdException ex)
            {
                Console.WriteLine("loi: " + ex.DuplicateId);
            }
        }
    }
}
