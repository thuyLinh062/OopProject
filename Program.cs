// Tran Thuy Linh
// MSSV 202418935

using System;

public class Program
{
    public static void Main()
    {
        // =====================================================
        // 1. HAI EMPLOYEE BANG HAI CONSTRUCTOR KHAC NHAU
        // =====================================================

        var employee1 = new Employee(
            "E11",
            "Pham Minh Anh"
        );

        var employee2 = new Employee(
            "E12",
            "Doan Thu Ha",
            15000000
        );


        // =====================================================
        // 2. HAI SOFTWARE ENGINEER
        //    BANG HAI CONSTRUCTOR KHAC NHAU
        // =====================================================

        var developer1 = new SoftwareEngineer(
            "S11",
            "Vu Hoang Nam",
            "C#"
        );

        var developer2 = new SoftwareEngineer(
            "S12",
            "Nguyen Ngoc Mai",
            22000000,
            "Java",
            5000000
        );


        // =====================================================
        // 3. TANG LUONG CO DINH
        // =====================================================

        employee2.IncreaseSalary(3000000);

        Console.WriteLine(
            "[3] Sau khi tang luong co dinh +3.000.000:"
        );

        employee2.DisplayInfo();


        // =====================================================
        // 4. TANG LUONG THEO PHAN TRAM
        // =====================================================

        developer2.IncreaseSalary(10, true);

        Console.WriteLine(
            "\n[4] Sau khi tang luong 10%:"
        );

        developer2.DisplayInfo();


        // =====================================================
        // 5. TAO NHOM DU AN KHONG CO TRUONG NHOM
        // =====================================================

        var team1 = new ProjectTeam(
            "PRJ11",
            "He thong quan ly thu vien"
        );


        // =====================================================
        // 6. THEM NHAN SU THUONG
        // =====================================================

        Console.WriteLine(
            "\n[6] Them E11 vao nhom: "
            + team1.AddMember(employee1)
        );


        // =====================================================
        // 7. THEM KY SU VA DAT LAM TRUONG NHOM
        // =====================================================

        Console.WriteLine(
            "[7] Them S11 va dat lam truong nhom: "
            + team1.AddMember(developer1, true)
        );


        // =====================================================
        // 8. THU THEM LAI THANH VIEN DA TON TAI
        // =====================================================

        Console.WriteLine(
            "[8] Them lai E11 (da ton tai): "
            + team1.AddMember(employee1)
        );


        // =====================================================
        // 9. HIEN THI DANH SACH NHOM
        // =====================================================

        Console.WriteLine(
            "\n[9] Danh sach nhom (da hinh):"
        );

        team1.DisplayTeam();


        // =====================================================
        // 10. TONG CHI PHI NHAN SU HANG THANG
        // =====================================================

        Console.WriteLine(
            "\n[10] Tong chi phi nhan su hang thang: "
            + team1.CalculateTotalMonthlyCost().ToString("N0")
            + " VND"
        );


        // =====================================================
        // 11. THU XOA TRUONG NHOM HIEN TAI
        // =====================================================

        Console.WriteLine(
            "[11] Xoa truong nhom S11: "
            + team1.RemoveMember("S11")
            + " (tu choi vi S11 dang la truong nhom)"
        );


        // =====================================================
        // 12. DOI TRUONG NHOM
        // =====================================================

        team1.ChangeLeader(employee2);

        Console.WriteLine(
            "[12a] Doi truong nhom sang E12: "
            + employee2.GetFullName()
        );

        Console.WriteLine(
            "[12b] Xoa S11 (truong nhom cu): "
            + team1.RemoveMember("S11")
        );


        // =====================================================
        // 13 + 14. TAO NHOM THU 3
        // =====================================================

        CreateAndDestroyTeam3(employee1);

        // Ep Garbage Collector thu hoi doi tuong
        GC.Collect();

        // Cho destructor/finalizer chay
        GC.WaitForPendingFinalizers();

        // Chay GC them mot lan nua
        GC.Collect();


        // =====================================================
        // 15. CHUNG MINH NHAN SU VAN TON TAI
        // =====================================================

        Console.WriteLine(
            "\n[15] Sau khi nhom 3 bi huy, E11 van ton tai:"
        );

        employee1.DisplayInfo();

        team1.DisplayTeam();


        // =====================================================
        // KET THUC CHUONG TRINH
        // =====================================================

        Console.WriteLine(
            "\nKET THUC CHUONG TRINH."
        );

        Console.WriteLine(
            "GC se thu hoi cac doi tuong con lai khi thich hop."
        );
    }


    // =========================================================
    // HAM TAO VA HUY NHOM 3
    // =========================================================

    static void CreateAndDestroyTeam3(Employee shared)
    {
        // Tao nhom thu 3
        var team3 = new ProjectTeam(
            "PRJ13",
            "Ung dung dat lich"
        );


        // -----------------------------------------------------
        // 13. Them lai E11 vao nhom 3
        // -----------------------------------------------------

        Console.WriteLine(
            "\n[13] Nhom 3 them lai E11 (da o nhom 1): "
            + team3.AddMember(shared)
        );

        team3.DisplayTeam();


        // -----------------------------------------------------
        // Tao mot SoftwareEngineer tam thoi
        // -----------------------------------------------------

        var temporaryDeveloper = new SoftwareEngineer(
            "S99",
            "Le Thu Phuong",
            "Python"
        );

        temporaryDeveloper.DisplayInfo();


        // -----------------------------------------------------
        // 14. Ket thuc phuong thuc
        // -----------------------------------------------------

        Console.WriteLine(
            "\n[14] Nhom 3 va nhan su tam thoi "
            + "nam trong phuong thuc nay."
        );

        Console.WriteLine(
            "      Phuong thuc CreateAndDestroyTeam3 sap ket thuc..."
        );
    }
}
