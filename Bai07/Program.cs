/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==========================================================");
            Console.WriteLine("                          TEST                            ");
            Console.WriteLine("==========================================================");

            //1. tạo các repository
            var projectorRepo = new InMemoryRepository<ProjectorRemote>();
            var acRepo = new InMemoryRepository<AirConditionerRemote>();
            var micRepo = new InMemoryRepository<WirelessMicrophone>();

            //tạo tối thiểu 3 máy chiếu, 2 điều hòa, 3 micro
            var mc1 = new ProjectorRemote("MC01", "Điều khiển máy chiếu 1", "Kho 1", 85);
            var mc2 = new ProjectorRemote("MC02", "Điều khiển máy chiếu 2", "Kho 1", 95);
            var mc3 = new ProjectorRemote("MC03", "Điều khiển máy chiếu 3", "Kho 1", 15); //pin < 20

            var dh1 = new AirConditionerRemote("DH01", "Điều khiển điều hòa 1", "Kho 2", new[] { "A203", "A204" });
            var dh2 = new AirConditionerRemote("DH02", "Điều khiển điều hòa 2", "Kho 2", new[] { "B101", "B102" });

            var mic1 = new WirelessMicrophone("MIC01", "Micro không dây 1", "Kho 3", 80, 90);
            var mic2 = new WirelessMicrophone("MIC02", "Micro không dây 2", "Kho 3", 90, 95);
            var mic3 = new WirelessMicrophone("MIC03", "Micro không dây 3", "Kho 3", 20, 80); //pin < 30

            //[1] thêm thiết bị vào repository
            Console.WriteLine("\n[1] Thêm thiết bị vào repository:");
            projectorRepo.Add(mc1);
            projectorRepo.Add(mc2);
            projectorRepo.Add(mc3);

            acRepo.Add(dh1);
            acRepo.Add(dh2);

            micRepo.Add(mic1);
            micRepo.Add(mic2);
            micRepo.Add(mic3);

            Console.WriteLine("Máy chiếu: " + mc1.Id + " (" + mc1.BatteryLevel + "%), " + mc2.Id + " (" + mc2.BatteryLevel + "%), " + mc3.Id + " (" + mc3.BatteryLevel + "%)");
            Console.WriteLine("Điều hòa: " + dh1.Id + " (A203, A204), " + dh2.Id + " (B101, B102)");
            Console.WriteLine("Micro: " + mic1.Id + " (pin: " + mic1.BatteryLevel + "%, sóng: " + mic1.SignalQuality + "%), " + mic2.Id + " (pin: " + mic2.BatteryLevel + "%, sóng: " + mic2.SignalQuality + "%), " + mic3.Id + " (pin: " + mic3.BatteryLevel + "%, sóng: " + mic3.SignalQuality + "%)");

            //[2] thử thêm hai thiết bị trùng mã
            Console.WriteLine("\n[2] Thử thêm thiết bị trùng mã:");
            try
            {
                projectorRepo.Add(new ProjectorRemote("MC01", "Máy chiếu trùng", "Kho 1", 50));
            }
            catch (DuplicateIdException ex)
            {
                Console.WriteLine("Lỗi: " + ex.DuplicateId);
            }

            //[3] tìm thiết bị theo mã
            Console.WriteLine("\n[3] Tìm thiết bị theo mã:");
            var timThay = projectorRepo.FindById("MC01");
            var khongThay = projectorRepo.FindById("MC99");
            Console.WriteLine("MC01: " + (timThay != null ? timThay.Id + " - " + timThay.Name : "null"));
            Console.WriteLine("MC99: " + (khongThay != null ? khongThay.Id : "null"));

            //[4] lọc các thiết bị sẵn sàng
            Console.WriteLine("\n[4] Lọc các thiết bị sẵn sàng:");
            var mcSanSang = projectorRepo.FindAll(d => d.IsReadyForUse());
            var dhSanSang = acRepo.FindAll(d => d.IsReadyForUse());
            var micSanSang = micRepo.FindAll(d => d.IsReadyForUse());

            Console.WriteLine("Máy chiếu: " + string.Join(", ", mcSanSang.Select(d => d.Id)));
            Console.WriteLine("Điều hòa: " + string.Join(", ", dhSanSang.Select(d => d.Id)));
            Console.WriteLine("Micro: " + string.Join(", ", micSanSang.Select(d => d.Id)));

            //[5] chọn điều khiển máy chiếu có điểm cao nhất
            Console.WriteLine("\n[5] Chọn điều khiển máy chiếu có điểm cao nhất:");
            var mcStrategy = new HighestPriorityStrategy<ProjectorRemote>(d => d.GetDefaultPriorityScore());
            var mcService = new AllocationService<ProjectorRemote>(projectorRepo, mcStrategy);
            var mcDuocChon = mcService.Allocate();
            Console.WriteLine(mcDuocChon.Id + " (Điểm: " + mcDuocChon.GetDefaultPriorityScore() + ")");

            //[6] chọn điều khiển điều hòa tương thích với một phòng
            Console.WriteLine("\n[6] Chọn điều khiển điều hòa tương thích với phòng A203:");
            var dhStrategy = new FirstAvailableStrategy<AirConditionerRemote>();
            var dhService = new AllocationService<AirConditionerRemote>(acRepo, dhStrategy);
            var dhDuocChon = dhService.Allocate(d => d.IsCompatibleWith("A203"));
            Console.WriteLine(dhDuocChon.Id + " (Tương thích A203: " + dhDuocChon.IsCompatibleWith("A203") + ")");

            //[7] chọn micro đầu tiên sẵn sàng
            Console.WriteLine("\n[7] Chọn micro đầu tiên sẵn sàng:");
            var micStrategy1 = new FirstAvailableStrategy<WirelessMicrophone>();
            var micService = new AllocationService<WirelessMicrophone>(micRepo, micStrategy1);
            var micDuocChon = micService.Allocate();
            Console.WriteLine(micDuocChon.Id);

            //[8] đổi chiến lược trong thời gian chạy
            Console.WriteLine("\n[8] Đổi chiến lược trong thời gian chạy:");
            var micRepoTest = new InMemoryRepository<WirelessMicrophone>();
            var mTest1 = new WirelessMicrophone("MIC_A", "Micro A", "Kho 3", 80, 80); //điểm 80
            var mTest2 = new WirelessMicrophone("MIC_B", "Micro B", "Kho 3", 95, 95); //điểm 95
            micRepoTest.Add(mTest1);
            micRepoTest.Add(mTest2);

            var micServiceDoi = new AllocationService<WirelessMicrophone>(micRepoTest, new FirstAvailableStrategy<WirelessMicrophone>());
            Console.WriteLine("Chiến lược FirstAvailable: MIC_A (đầu tiên)");

            micServiceDoi.ChangeStrategy(new HighestPriorityStrategy<WirelessMicrophone>(d => d.GetDefaultPriorityScore()));
            var micSauDoi = micServiceDoi.Allocate();
            Console.WriteLine("Sau khi đổi sang HighestPriority: " + micSauDoi.Id + " (Điểm: " + micSauDoi.GetDefaultPriorityScore() + ")");

            //[9] thử cấp phát khi không có ứng viên phù hợp
            Console.WriteLine("\n[9] Thử cấp phát khi không có ứng viên phù hợp:");
            try
            {
                dhService.Allocate(d => d.IsCompatibleWith("C999"));
            }
            catch (NoSuitableItemException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            //[10] chứng minh thiết bị được chọn chuyển sang Borrowed
            Console.WriteLine("\n[10] Chứng minh thiết bị được chọn chuyển sang Borrowed:");
            var testDevice = new ProjectorRemote("MC_TEST", "Test mượn", "Kho 1", 80);
            var testRepo = new InMemoryRepository<ProjectorRemote>();
            testRepo.Add(testDevice);

            var testService = new AllocationService<ProjectorRemote>(testRepo, new FirstAvailableStrategy<ProjectorRemote>());
            Console.WriteLine("Trước cấp phát: " + testDevice.Status);
            var allocatedDevice = testService.Allocate();
            Console.WriteLine("Sau cấp phát: " + allocatedDevice.Status);
            allocatedDevice.Return();
            Console.WriteLine("Sau khi trả: " + allocatedDevice.Status);

            //[11] chứng minh repository tổng quát dùng cho nhiều loại thiết bị
            Console.WriteLine("\n[11] Repository tổng quát dùng cho nhiều loại thiết bị:");
            Console.WriteLine("Kho máy chiếu (ProjectorRemote): " + projectorRepo.GetAll().Count + " thiết bị");
            Console.WriteLine("Kho điều hòa (AirConditionerRemote): " + acRepo.GetAll().Count + " thiết bị");
            Console.WriteLine("Kho micro (WirelessMicrophone): " + micRepo.GetAll().Count + " thiết bị");

            Console.WriteLine("\n==========================================================");
            Console.WriteLine("                          TEST                            ");
            Console.WriteLine("==========================================================");
        }
    }
}
