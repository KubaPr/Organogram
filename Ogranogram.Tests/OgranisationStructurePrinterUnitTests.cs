using FluentAssertions;
using NUnit.Framework;
using Organogram;
using System.Collections.Generic;

namespace Ogranogram.Tests
{
  [TestFixture]
  internal class OgranisationStructurePrinterUnitTests
  {
    [Test]
    public void ShouldPrintSuperiorNameLastNameCompanyAndPositionAtTheTopLevel()
    {
      var organisation = new OrganizationalUnit(
        new List<Employee> { new Employee(0, 0, "John", "Hancock", "CEO", "Acturis") },
        new List<OrganizationalUnit>());

      new OgranisationStructurePrinter().Print(organisation).Should().Be("John Hancock, Acturis, CEO");
    }
  }
}
