
// Tran Thuy Linh
// MSSV 202418935

using System;

public class SoftwareEngineer : Employee
{
    // =========================
    // THUOC TINH
    // =========================

    private string primaryLanguage;
    private double technicalAllowance;


    // =========================
    // CONSTRUCTOR
    // =========================

    // Constructor 1
    public SoftwareEngineer(
        string id,
        string fullName,
        string primaryLanguage)
        : base(id, fullName, 0)
    {
        // Ràng buộc
        if (string.IsNullOrWhiteSpace(primaryLanguage))
        {
            throw new ArgumentException(
                "Ngôn ngữ chính không được để trống"
            );
        }

        this.primaryLanguage = primaryLanguage;
        this.technicalAllowance = 0;
    }


    // Constructor 2
    public SoftwareEngineer(
        string id,
        string fullName,
        double baseSalary,
        string primaryLanguage,
        double technicalAllowance)
        : base(id, fullName, baseSalary)
    {
        // Ràng buộc
        if (string.IsNullOrWhiteSpace(primaryLanguage))
        {
            throw new ArgumentException(
                "Ngôn ngữ chính không được để trống"
            );
        }

        if (technicalAllowance < 0)
        {
            throw new ArgumentException(
                "Phụ cấp không được âm"
            );
        }

        this.primaryLanguage = primaryLanguage;
        this.technicalAllowance = technicalAllowance;
    }


    // =========================
    // GETTER
    // =========================

    public string GetPrimaryLanguage()
    {
        return this.primaryLanguage;
    }


    public double GetTechnicalAllowance()
    {
        return this.technicalAllowance;
    }


    // =========================
    // OVERRIDE CALCULATE MONTHLY COST
    // =========================

    public override double CalculateMonthlyCost()
    {
        return GetBaseSalary() + this.technicalAllowance;
    }


    // =========================
    // OVERRIDE DISPLAY INFO
    // =========================

    public override void DisplayInfo()
    {
        Console.WriteLine("ID: " + GetId());
        Console.WriteLine("Họ tên: " + GetFullName());
        Console.WriteLine("Lương cơ bản: " + GetBaseSalary());
        Console.WriteLine(
            "Ngôn ngữ chính: " + this.primaryLanguage
        );
        Console.WriteLine(
            "Phụ cấp kỹ thuật: " + this.technicalAllowance
        );
        Console.WriteLine(
            "Chi phí tháng: " + CalculateMonthlyCost()
        );
    }


    // =========================
    // DESTRUCTOR
    // =========================

    ~SoftwareEngineer()
    {
        Console.WriteLine("SoftwareEngineer bị hủy");
    }
}