/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai07
{
    class Program
    {
        static void Main(string[] args)
        {
            //test strategy
            var list = new List<ProjectorRemote>
            {
                new ProjectorRemote("MC01", "Máy chiếu 1", "Kho 1", 50),
                new ProjectorRemote("MC02", "Máy chiếu 2", "Kho 1", 90),
                new ProjectorRemote("MC03", "Máy chiếu 3", "Kho 1", 70)
            };

            var firstStrategy = new FirstAvailableStrategy<ProjectorRemote>();
            var bestStrategy = new HighestPriorityStrategy<ProjectorRemote>(d => d.GetDefaultPriorityScore());

            Console.WriteLine("first: " + firstStrategy.Select(list).Id);
            Console.WriteLine("highest: " + bestStrategy.Select(list).Id);
        }
    }
}
