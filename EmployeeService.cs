using corewebapitest.Services;
using System;
using System.Collections.Generic;
using System.Linq;

class EmployeeService : IEmployeeService
{

    public ResponseModel DeleteEmployee(int employeeId)
    {
        ResponseModel model = new ResponseModel();
        try
        {
            Employees _temp = GetEmployeeDetailsById(employeeId);
            if (_temp != null)
            {
                _context.Remove<Employees>(_temp);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "Employee Deleted Successfully";
            }
            else
            {
                model.IsSuccess = false;
                model.Messsage = "Employee Not Found";
            }

        }
        catch (Exception ex)
        {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

    public Employees GetEmployeeDetailsById(int empId)
    {
        Employees emp;
        try
        {
            emp = _context.Find<Employees>(empId);
        }
        catch (Exception)
        {
            throw;
        }
        return emp;
    }

    public List<Employees> GetEmployeesList()
    {
        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
     
      
            List<Employees> empList;
            try
            {
                empList = _context.Set<Employees>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
    }

    public ResponseModel SaveorUpdateEmployee(Employees employeeModel)
    {
        ResponseModel model = new ResponseModel();
        try
        {
            Employees _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
            if (_temp != null)
            {
                _temp.Designation = employeeModel.Designation;
                _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                _temp.Salary = employeeModel.Salary;
                _temp.BirthDate = employeeModel.BirthDate;
                _temp.ContactNumber = employeeModel.ContactNumber;
                _temp.Email = employeeModel.Email;
                _temp.Gender = employeeModel.Gender;

                _context.Update<Employees>(_temp);
                model.Messsage = "Employee Update Successfully";
            }
            else
            {
                _context.Add<Employees>(employeeModel);
                model.Messsage = "Employee Inserted Successfully";
            }
            _context.SaveChanges();
            model.IsSuccess = true;
        }
        catch (Exception ex)
        {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

    
    private EmpContext _context;
    public EmployeeService(EmpContext context)
    {
        _context = context;
    }


}