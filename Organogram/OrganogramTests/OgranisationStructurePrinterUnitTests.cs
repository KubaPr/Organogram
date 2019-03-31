using FluentAssertions;
using NUnit.Framework;
using Organogram;
using System.Collections.Generic;
using System.Linq;

namespace Ogranogram.Tests
{
  [TestFixture]
  internal class OgranisationStructurePrinterUnitTests
  {
    private OgranisationStructureSorter _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new OgranisationStructureSorter();
    }

    [Test]
    public void ShouldHaveDummyRootElementWithSupervisorId0()
    {
      _subject.CreateTree(new List<Employee>()).Employee.Id.Should().Be(0);
    }

    [Test]
    public void ShouldAddEmployeeAsTreeElement()
    {
      var employee = new Employee(2, supervisorId: 0, "Randy", "Raynolds", "BA", "Acturis");
      var employees = new List<Employee> { employee };

      _subject.CreateTree(employees).Subordinates.First().Employee.Should().Be(employee);
    }

    [Test]
    public void ShouldAddEmployeeSubordinates()
    {
      var supervisor = new Employee(4, 0, "John", "Hancock", "CEO", "Acturis");
      var subordinate = new Employee(5, supervisorId: 4, "Andy", "Adams", "BA", "Acturis");

      var employees = new List<Employee> {
          supervisor,
          subordinate
        };

      var supervisorTreeElement = 
        _subject.CreateTree(employees).Subordinates.First(element => element.Employee.Id == supervisor.Id);

      supervisorTreeElement.Subordinates.Should().ContainEquivalentOf(new EmployeeTreeElement(subordinate));
    }

    [Test]
    public void ShouldAddEmployeeSubordinatesRecursively()
    {
      var ceo = new Employee(4, 0, "John", "Hancock", "CEO", "Acturis");
      var manager = new Employee(71, supervisorId: 4, "Andy", "Adams", "Manager", "Acturis");
      var worker = new Employee(2, supervisorId: 71, "Randy", "Raynolds", "BA", "Acturis");

      var employees = new List<Employee> { worker, manager, ceo };

      _subject.CreateTree(employees)
        .Subordinates.First()
        .Subordinates.First()
        .Subordinates.First().Should().BeEquivalentTo(new EmployeeTreeElement(worker));
    }

    [Test]
    public void WhenEmployeeDoesNotHaveAnySubordinates_ShouldNotAddAny()
    {
      var employees = new List<Employee> { new Employee(2, supervisorId: 71, "Randy", "Raynolds", "BA", "Acturis") };

      _subject.CreateTree(employees).Subordinates.Should().BeEmpty();
    }
  }
}
