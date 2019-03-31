using System.Collections.Generic;

namespace Organogram
{
  public class EmployeeTreeElement
  {
    public Employee Employee { get; }
    public List<EmployeeTreeElement> Subordinates { get; }

    public EmployeeTreeElement(Employee employee)
    {
      Employee = employee;
      Subordinates = new List<EmployeeTreeElement>();
    }

    public void AddSubordinates(List<EmployeeTreeElement> subordinates)
    {
      Subordinates.AddRange(subordinates);
    }
  }
}
