namespace NorthwindEmployeeEfCoreService.Tests;

internal class EmployeeEfCoreServiceReadOperationsTests : IDisposable
{
    private DatabaseService databaseService = default!;
    private EmployeeEfCoreService efCoreService = default!;

    [OneTimeSetUp]
    public void Init()
    {
        this.databaseService = new DatabaseService();
        this.databaseService.CreateTables();
        this.databaseService.InitializeTables();
        this.efCoreService = new EmployeeEfCoreService(new SqliteDbContextFactory());
    }

    [OneTimeTearDown]
    public void Cleanup() => this.Dispose();

    [Test]
    public void GetEmployees_ReturnsEmployeeList()
    {
        var actual = EmployeesDataSource.GetEmployees.ToList();
        IList<Employee> expected = this.efCoreService.GetEmployees();
        Assert.That(actual.Count, Is.EqualTo(expected.Count));
        var comparer = new EmployeeEqualityComparer();
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
        }
    }

    [Test]
    public void GetEmployee_EmployeeIsNotExist_ThrowsRepositoryException()
    {
        _ = Assert.Throws<EmployeeServiceException>(() => this.efCoreService.GetEmployee(id: 0));
    }

    [TestCaseSource(typeof(EmployeesDataSource), nameof(EmployeesDataSource.GetEmployees))]
    public void GetEmployee_EmployeeIsExist_ReturnsEmployee(Employee employee)
    {
        Employee actualEmployee = this.efCoreService.GetEmployee(employee.Id)!;
        Assert.That(actualEmployee, Is.Not.Null);
        Assert.That(employee.Id, Is.EqualTo(actualEmployee.Id));
    }

    public void Dispose()
    {
        this.databaseService.Dispose();
    }
}