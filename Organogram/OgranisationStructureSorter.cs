using System.Collections.Generic;
using System.Linq;

namespace Organogram
{
  public class OgranisationStructureSorter
  {
    public EmployeeTreeElement CreateTree(List<Employee> employees)
    {
      var rootElement = new EmployeeTreeElement(new RootEmployeeElement());

      AddSubordinatesRecursively(rootElement, employees);

      return rootElement;
    }

    private void AddSubordinatesRecursively(EmployeeTreeElement treeElement, List<Employee> employees)
    {
      var subordinates = employees.Where(employee => employee.SupervisorId == treeElement.Employee.Id);

      if(subordinates.Any())
      {
        treeElement.AddSubordinates(
          subordinates.Select(element => new EmployeeTreeElement(element))
          .ToList());

        foreach (var element in treeElement.Subordinates)
        {
          AddSubordinatesRecursively(element, employees);
        }
      }
    }
  }
}
