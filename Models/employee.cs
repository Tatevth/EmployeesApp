using System.ComponentModel.DataAnnotations;

public enum Gender
{
    M,
    F
}
public class Employees
{
    [Key]
    public int EmployeeId { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public decimal Salary { get; set; }
    public string Designation { get; set; }
    public string BirthDate { get; set; }
    public Gender Gender { get; set; }
    public int ContactNumber { get; set; }
    public string Email { get; set; }

}

//public class HRData
//{
//    [Key]
//    public int EmployeeId { get; set; }
//    public decimal Salary { get; set; }
//}