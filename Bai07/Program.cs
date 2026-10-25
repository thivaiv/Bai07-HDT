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
            //test allocation service
            var repo = new InMemoryRepository<ProjectorRemote>();
            repo.Add(new ProjectorRemote("MC01", "Máy chiếu 1", "Kho 1", 50));
            repo.Add(new ProjectorRemote("MC02", "Máy chiếu 2", "Kho 1", 90));

            var strategy = new HighestPriorityStrategy<ProjectorRemote>(d => d.GetDefaultPriorityScore());
            var service = new AllocationService<ProjectorRemote>(repo, strategy);

            var allocated = service.Allocate();
            Console.WriteLine("cap phat: " + allocated.Id + " | trang thai: " + allocated.Status);
        }
    }
}
