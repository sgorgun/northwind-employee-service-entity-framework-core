namespace NorthwindEmployeeEfCoreService.Tests;

internal class EmployeeEfCoreServiceWriteOperationsTests
{
    [TestCaseSource(typeof(EmployeesDataSource), nameof(EmployeesDataSource.GetEmployeesForInsertAndUpdateOperation))]
    public void AddEmployee_TableIsEmpty_ReturnsRowId(Employee employee)
    {
        const string selectCountSql = "SELECT COUNT(*) FROM Employees";
        // Arrange
        using var databaseService = new DatabaseService();
        databaseService.CreateTables();
        var service = new EmployeeEfCoreService(new SqliteDbContextFactory());

        // Preconditions
        var employeeBefore = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(employeeBefore, Is.EqualTo(0));

        // Act
        long rowId = service.AddEmployee(employee);

        // Assert
        Assert.That(rowId, Is.GreaterThan(0));

        // Postconditions
        var employeeAfter = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(employeeAfter, Is.EqualTo(1));
    }

    [TestCaseSource(typeof(EmployeesDataSource), nameof(EmployeesDataSource.GetEmployeesForInsertAndUpdateOperation))]
    public void AddEmployee_TableIsNotEmpty_ReturnsRowId(Employee employee)
    {
        // Arrange
        using var databaseService = new DatabaseService();
        databaseService.CreateTables();
        databaseService.InitializeTables();
        var service = new EmployeeEfCoreService(new SqliteDbContextFactory());

        // Act
        long rowId = service.AddEmployee(employee);

        // Assert
        long counter = databaseService.ExecuteScalar<long>($"SELECT COUNT(*) FROM Employees WHERE Id = {rowId}");
        Assert.That(counter, Is.EqualTo(1));
    }

    [TestCaseSource(typeof(EmployeesDataSource), nameof(EmployeesDataSource.GetEmployees))]
    public void UpdateEmployee_EmployeeIsExist_UpdatesEmployee(Employee employee)
    {
        // Arrange
        long employeeId = employee.Id;
        string selectCountSql = $"SELECT COUNT(*) FROM Employees WHERE Id = {employeeId}";
        using var databaseService = new DatabaseService();
        databaseService.CreateTables();
        databaseService.InitializeTables();
        var service = new EmployeeEfCoreService(new SqliteDbContextFactory());
        Employee newEmployee = new()
        {
            Id = employeeId,
            LastName = "Dodsworth",
            FirstName = "Anne",
            Title = "Sales Representative",
            TitleOfCourtesy = "Ms.",
            BirthDate = new DateTime(1966, 1, 27),
            HireDate = new DateTime(1994, 11, 15),
            Address = "7 Houndstooth Rd.",
            City = "London",
            Region = null,
            PostalCode = "WG2 7LT",
            Country = "UK",
            HomePhone = "(71) 555-4444",
            Extension = "452",
            Notes = "Anne has a BA degree in English from St. Lawrence College.  She is fluent in French and German.",
            ReportsTo = 5,
            PhotoPath = "http://accweb/emmployees/davolio.bmp"
        };

        // Preconditions
        long employeesBefore = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(employeesBefore, Is.EqualTo(1));

        // Act
        service.UpdateEmployee(newEmployee);

        // Postconditions
        long employeeAfter = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(employeeAfter, Is.EqualTo(1));

        // Assert
        Employee updatedEmployee = service.GetEmployee(employeeId)!;
        var employeeEqualityComparer = new EmployeeEqualityComparer();
        var result = employeeEqualityComparer.Equals(updatedEmployee, newEmployee);
        Assert.That(result, Is.True);
    }

    [TestCaseSource(typeof(EmployeesDataSource), nameof(EmployeesDataSource.GetEmployeesForInsertAndUpdateOperation))]
    public void UpdateEmployee_EmployeeIsNotExist_ThrownException(Employee employee)
    {
        // Arrange
        using var databaseService = new DatabaseService();
        databaseService.CreateTables();
        databaseService.InitializeTables();
        var service = new EmployeeEfCoreService(new SqliteDbContextFactory());

        // Preconditions
        long employeeBefore = databaseService.ExecuteScalar<long>($"SELECT COUNT(*) FROM Employees WHERE Id = {employee.Id}");
        Assert.That(employeeBefore, Is.EqualTo(0));

        // Act
        _ = Assert.Throws<EmployeeServiceException>(() => service.UpdateEmployee(employee));

        // Postconditions
        long employeeAfter = databaseService.ExecuteScalar<long>($"SELECT COUNT(*) FROM Employees WHERE Id = {employee.Id}");
        Assert.That(employeeAfter, Is.EqualTo(0));
    }

    [TestCaseSource(typeof(EmployeesDataSource), nameof(EmployeesDataSource.GetEmployees))]
    public void RemoveEmployee_EmployeeIsExist_RemovesEmployee(Employee employee)
    {
        long employeeId = employee.Id;
        string selectCountSql = $"SELECT COUNT(*) FROM Employees WHERE Id = {employeeId}";
        // Arrange
        using var databaseService = new DatabaseService();
        databaseService.CreateTables();
        databaseService.InitializeTables();
        var service = new EmployeeEfCoreService(new SqliteDbContextFactory());

        // Preconditions
        long employeesBefore = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(employeesBefore, Is.EqualTo(1));

        // Act
        service.RemoveEmployee(employeeId);

        // Postconditions
        long ordersAfter = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(ordersAfter, Is.EqualTo(0));
    }

    [TestCase(100)]
    [TestCase(101)]
    public void RemoveEmployee_EmployeeIsNotExist_Returns(long employeeId)
    {
        string selectCountSql = $"SELECT COUNT(*) FROM Employees WHERE Id = {employeeId}";

        // Arrange
        using var databaseService = new DatabaseService();
        databaseService.CreateTables();
        databaseService.InitializeTables();
        var service = new EmployeeEfCoreService(new SqliteDbContextFactory());

        // Preconditions
        long countBefore = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(countBefore, Is.EqualTo(0));

        // Act
        _ = Assert.Throws<EmployeeServiceException>(() => service.RemoveEmployee(employeeId));

        // Postconditions
        long countAfter = databaseService.ExecuteScalar<long>(selectCountSql);
        Assert.That(countAfter, Is.EqualTo(0));
    }
}