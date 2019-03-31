using FluentAssertions;
using NUnit.Framework;
using Organogram;
using System;
using System.Collections.Generic;

namespace OrganogramTests
{
  [TestFixture]
  internal class TreePrinterUnitTests
  {
    private TreePrinter _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new TreePrinter();
    }

    [Test]
    public void ShouldSkipPrintingRootElement()
    {
      _subject.Print(new EmployeeTreeElement(new RootEmployeeElement())).Should().BeEmpty();
    }

    [Test]
    public void ShouldPrintEmployeeNameWithLastnameAndPositionAndCompanyAddingNewLineAtTheEnd()
    {
      var tree = new EmployeeTreeElement(new RootEmployeeElement());

      tree.AddSubordinates(
        new List<EmployeeTreeElement> {
          new EmployeeTreeElement(
            new Employee(
              id: 12,
              supervisorId: 0,
              name: "John",
              lastname: "Hancock",
              role: "CEO",
              company: "Acturis"))
        });

      _subject.Print(tree).Should().Be($"John Hancock, CEO, Acturis{Environment.NewLine}");
    }

    [Test]
    public void ShouldPrintEmployeeInformationRecursivelyAddingArrowAtTheBeggining()
    {
      var tree = new EmployeeTreeElement(new RootEmployeeElement());

      var ceo = new EmployeeTreeElement(
        new Employee(
              id: 12,
              supervisorId: 0,
              name: "John",
              lastname: "Hancock",
              role: "CEO",
              company: "Acturis"));

      var manager = new EmployeeTreeElement(
        new Employee(
              id: 6,
              supervisorId: 12,
              name: "Barney",
              lastname: "Baggins",
              role: "Manager",
              company: "Acturis"));

      var worker = new EmployeeTreeElement(
        new Employee(
              id: 719,
              supervisorId: 6,
              name: "Harvey",
              lastname: "Hardy",
              role: "BA",
              company: "Acturis"));

      manager.AddSubordinates(
        new List<EmployeeTreeElement> { worker });
      ceo.AddSubordinates(
        new List<EmployeeTreeElement> { manager });
      tree.AddSubordinates(
        new List<EmployeeTreeElement> { ceo });

      _subject.Print(tree).Split(Environment.NewLine.ToCharArray()).Should()
        .Contain($"John Hancock, CEO, Acturis")
        .And.Contain($"-> Barney Baggins, Manager, Acturis")
        .And.Contain($"-> -> Harvey Hardy, BA, Acturis");
    }
  }
}
