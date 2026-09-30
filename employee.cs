
// Tran Thuy Linh
// MSSV 202418935

using System;

public class Employee
{
    // =========================
    // THUOC TINH
    // =========================

    private string id;
    private string fullName;
    private double baseSalary;


    // =========================
    // CONSTRUCTOR
    // =========================

    // Constructor 1: Không tham số
    public Employee()
    {
        this.id = "UNKNOWN";
        this.fullName = "Unnamed employee";
        this.baseSalary = 0;
    }


    // Constructor 2: id + fullName
    public Employee(string id, string fullName)
    {
        // Ràng buộc
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("ID không được để trống");
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("FullName không được để trống");
        }

        this.id = id;
        this.fullName = fullName;
        this.baseSalary = 0;
    }


    // Constructor 3: id + fullName + baseSalary
    public Employee(string id, string fullName, double baseSalary)
    {
        // Ràng buộc
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("ID không được để trống");
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("FullName không được để trống");
        }

        if (baseSalary < 0)
        {
            throw new ArgumentException("Lương không được âm");
        }

        this.id = id;
        this.fullName = fullName;
        this.baseSalary = baseSalary;
    }


    // =========================
    // METHOD - TĂNG LƯƠNG
    // =========================

    // Tăng lương theo số tiền
    public void IncreaseSalary(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Số tiền tăng phải lớn hơn 0"
            );
        }

        this.baseSalary += amount;
    }


    // Tăng lương theo số tiền hoặc phần trăm
    public void IncreaseSalary(double value, bool byPercentage)
    {
        if (value <= 0)
        {
            throw new ArgumentException(
                "Giá trị tăng phải lớn hơn 0"
            );
        }

        if (byPercentage)
        {
            // Tăng theo phần trăm
            this.baseSalary += this.baseSalary * value / 100.0;
        }
        else
        {
            // Tăng trực tiếp một số tiền
            this.baseSalary += value;
        }
    }


    // =========================
    // GETTER
    // =========================

    public string GetId()
    {
        return this.id;
    }


    public string GetFullName()
    {
        return this.fullName;
    }


    public double GetBaseSalary()
    {
        return this.baseSalary;
    }


    // =========================
    // TÍNH CHI PHÍ HÀNG THÁNG
    // =========================

    public virtual double CalculateMonthlyCost()
    {
        return this.baseSalary;
    }


    // =========================
    // HIỂN THỊ THÔNG TIN
    // =========================

    public virtual void DisplayInfo()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Họ tên: " + this.fullName);
        Console.WriteLine("Lương cơ bản: " + this.baseSalary);
        Console.WriteLine(
            "Chi phí hàng tháng: " + this.CalculateMonthlyCost()
        );
    }


    // =========================
    // DESTRUCTOR
    // =========================

    ~Employee()
    {
        Console.WriteLine("Employee bị hủy");
    }
}
