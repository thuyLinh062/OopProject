//Tran Thuy Linh
//MSSV 202418935
using System;
public class ProjectTeam
{
    private string projectCode;
    private string projectName;

    //Khong so huu Employee
    private Employee leader;

    //Danh sach lien ket khong so huu den cac thanh vien
    private List<Employee> members;


    // CONSTRUCTOR 1

    public ProjectTeam(string projectCode, string projectName)
    {
        if (string.IsNullOrWhiteSpace(projectCode))
            throw new ArgumentException(
                "Mã dự án không được rỗng."
            );

        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException(
                "Tên dự án không được rỗng."
            );

        this.projectCode = projectCode;
        this.projectName = projectName;

        leader = null;
        members = new List<Employee>();
    }

    // CONSTRUCTOR 2

    public ProjectTeam(string projectCode, string projectName, Employee leader)
    {
        if (string.IsNullOrWhiteSpace(projectCode))
            throw new ArgumentException(
                "Mã dự án không được rỗng."
            );

        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException(
                "Tên dự án không được rỗng."
            );

        if (leader == null)
            throw new ArgumentNullException(
                nameof(leader)
            );

        this.projectCode = projectCode;
        this.projectName = projectName;

        members = new List<Employee>();

        this.leader = leader;
        members.Add(leader);
    }

    // ADD MEMBER

    public bool AddMember(Employee employee)
    {
        if (employee == null)
            return false;

        if (Contains(employee.GetId()))
            return false;

        members.Add(employee);

        return true;
    }

    // ADD MEMBER + MAKE LEADER

    public bool AddMember(Employee employee, bool makeLeader)
    {
        if (employee == null)
            return false;

        if (!Contains(employee.GetId()))
        {
            members.Add(employee);
        }

        if (makeLeader)
        {
            leader = employee;
        }

        return true;
    }

    // CONTAINS

    public bool Contains(string employeeId)
    {
        foreach (Employee employee in members)
        {
            if (employee.GetId() == employeeId)
            {
                return true;
            }
        }

        return false;
    }

    // REMOVE MEMBER

    public bool RemoveMember(string employeeId)
    {
        for (int i = 0; i < members.Count; i++)
        {
            Employee employee = members[i];

            if (employee.GetId() == employeeId)
            {
                // Không được xóa leader
                if (leader != null &&
                    leader.GetId() == employeeId)
                {
                    return false;
                }

                members.RemoveAt(i);

                return true;
            }
        }

        return false;
    }

    // CHANGE LEADER

    public bool ChangeLeader(Employee employee)
    {
        if (employee == null)
            return false;

        // Nếu chưa là thành viên thì thêm vào
        if (!Contains(employee.GetId()))
        {
            members.Add(employee);
        }

        leader = employee;

        return true;
    }

    // TOTAL MONTHLY COST

    public double CalculateTotalMonthlyCost()
    {
        double total = 0;

        foreach (Employee employee in members)
        {
            total += employee.CalculateMonthlyCost();
        }

        return total;
    }

    // DISPLAY TEAM

    public void DisplayTeam()
    {
        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine("PROJECT TEAM");
        Console.WriteLine("================================");

        Console.WriteLine(
            "Project code: " + projectCode
        );

        Console.WriteLine(
            "Project name: " + projectName
        );

        if (leader == null)
        {
            Console.WriteLine(
                "Leader: None"
            );
        }
        else
        {
            Console.WriteLine(
                "Leader: " +
                leader.GetFullName()
            );
        }

        Console.WriteLine();
        Console.WriteLine("Members:");

        foreach (Employee employee in members)
        {
            employee.DisplayInfo();

            Console.WriteLine(
                "----------------------------"
            );
        }

        Console.WriteLine(
            "Total monthly cost: " +
            CalculateTotalMonthlyCost()
        );
    }

    // DESTRUCTOR
    
    ~ProjectTeam()
    {
        Console.WriteLine(
            "[Destructor] ProjectTeam: " +
            projectCode
        );

        members.Clear();
        leader = null;
    }
}
