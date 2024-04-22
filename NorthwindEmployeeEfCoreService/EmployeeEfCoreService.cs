using Microsoft.EntityFrameworkCore;

namespace NorthwindEmployeeEfCoreService;

/// <summary>
/// A service for interacting with the "Employees" table using Entity Framework Core.
/// </summary>
public sealed class EmployeeEfCoreService
{
    private readonly IDbContextFactory<EmployeeContext> dbContextFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeEfCoreService"/> class.
    /// </summary>
    /// <param name="dbContextFactory">The database context factory used to create database context instances.</param>
    /// <exception cref="ArgumentNullException">Thrown when either <paramref name="dbContextFactory"/> is null.</exception>
    public EmployeeEfCoreService(IDbContextFactory<EmployeeContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
    }

    /// <summary>
    /// Retrieves a list of all employees from the Employees table of the database.
    /// </summary>
    /// <returns>A list of Employee objects representing the retrieved employees.</returns>
    public IList<Employee> GetEmployees()
    {
        using var dbContext = dbContextFactory.CreateDbContext();
        return dbContext.Employees.ToList();
    }

    /// <summary>
    /// Retrieves an employee with the specified employee Id.
    /// </summary>
    /// <param name="id">The id of the employee to retrieve.</param>
    /// <returns>The retrieved an <see cref="Employee"/> instance.</returns>
    /// <exception cref="EmployeeServiceException">Thrown when the employee is not found.</exception>
    public Employee GetEmployee(long id)
    {
        using var dbContext = dbContextFactory.CreateDbContext();
        return dbContext.Employees.FirstOrDefault(e => e.Id == id)
            ?? throw new EmployeeServiceException($"Employee with ID {id} not found.");
    }

    /// <summary>
    /// Adds a new employee to Employee table of the database.
    /// </summary>
    /// <param name="employee">The <see cref="Employee"/> object containing the employee's information.</param>
    /// <returns>The id of the newly added employee.</returns>
    /// <exception cref="EmployeeServiceException">Thrown when an error occurs while adding the employee.</exception>
    public long AddEmployee(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        using var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Employees.Add(employee);
        dbContext.SaveChanges();
        return employee.Id != 0 ? employee.Id : throw new EmployeeServiceException("Employee ID wasn't set after insertion.");
    }

    /// <summary>
    /// Removes an employee from the the Employee table of the database based on the provided employee Id.
    /// </summary>
    /// <param name="id">The ID of the employee to remove.</param>
    /// <exception cref="EmployeeServiceException"> Thrown when an error occurs while attempting to remove the employee.</exception>
    public void RemoveEmployee(long id)
    {
        using var dbContext = dbContextFactory.CreateDbContext();
        var employee = dbContext.Employees.FirstOrDefault(e => e.Id == id)
            ?? throw new EmployeeServiceException($"Employee with ID {id} not found.");
        dbContext.Employees.Remove(employee);
        dbContext.SaveChanges();

        if (dbContext.Employees.Any(e => e.Id == id))
        {
            throw new EmployeeServiceException($"Employee with ID {id} wasn't removed.");
        }
    }

    /// <summary>
    /// Updates an employee record in the Employee table of the database.
    /// </summary>
    /// <param name="employee">The employee object containing updated information.</param>
    /// <exception cref="EmployeeServiceException">Thrown when there is an issue updating the employee record.</exception>
    public void UpdateEmployee(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        using var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Employees.Update(employee);
        try
        {
            dbContext.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new EmployeeServiceException($"Employee with ID {employee.Id} not found after update.");
        }
    }
}
