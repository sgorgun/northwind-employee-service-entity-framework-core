using Microsoft.EntityFrameworkCore;

namespace NorthwindEmployeeEfCoreService;

/// <summary>
/// A service for interacting with the "Employees" table using Entity Framework Core.
/// </summary>
public sealed class EmployeeEfCoreService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeEfCoreService"/> class.
    /// </summary>
    /// <param name="dbContextFactory">The database context factory used to create database context instances.</param>
    /// <exception cref="ArgumentNullException">Thrown when either <paramref name="dbContextFactory"/> is null.</exception>
    public EmployeeEfCoreService(IDbContextFactory<EmployeeContext> dbContextFactory)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves a list of all employees from the Employees table of the database.
    /// </summary>
    /// <returns>A list of Employee objects representing the retrieved employees.</returns>
    public IList<Employee> GetEmployees()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves an employee with the specified employee Id.
    /// </summary>
    /// <param name="id">The id of the employee to retrieve.</param>
    /// <returns>The retrieved an <see cref="Employee"/> instance.</returns>
    /// <exception cref="EmployeeServiceException">Thrown when the employee is not found.</exception>
    public Employee GetEmployee(long id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new employee to Employee table of the database.
    /// </summary>
    /// <param name="employee">The <see cref="Employee"/> object containing the employee's information.</param>
    /// <returns>The id of the newly added employee.</returns>
    /// <exception cref="EmployeeServiceException">Thrown when an error occurs while adding the employee.</exception>
    public long AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes an employee from the the Employee table of the database based on the provided employee Id.
    /// </summary>
    /// <param name="id">The ID of the employee to remove.</param>
    /// <exception cref="EmployeeServiceException"> Thrown when an error occurs while attempting to remove the employee.</exception>
    public void RemoveEmployee(long id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates an employee record in the Employee table of the database.
    /// </summary>
    /// <param name="employee">The employee object containing updated information.</param>
    /// <exception cref="EmployeeServiceException">Thrown when there is an issue updating the employee record.</exception>
    public void UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }
}