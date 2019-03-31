using System;
using System.Linq;
using System.Text;

namespace Organogram
{
  public class TreePrinter
  {
    private const string Indent = "-> ";

    public string Print(EmployeeTreeElement organisationTree)
    {
      var result = new StringBuilder();
      var treeDepth = 0;

      foreach (var treeElement in organisationTree.Subordinates)
      {
        BuildResultRecursively(treeElement, treeDepth, result);
      }

      return result.ToString();
    }

    private void BuildResultRecursively(
      EmployeeTreeElement organisationTree,
      int currentTreeDepth,
      StringBuilder builder)
    {
      AppendIndents(currentTreeDepth, builder);
      AppendEmployeeInformation(organisationTree.Employee, builder);

      currentTreeDepth++;

      foreach (var element in organisationTree.Subordinates)
      {
        BuildResultRecursively(element, currentTreeDepth, builder);
      }
    }

    private void AppendIndents(int indentsCount, StringBuilder builder)
    {
      builder.Append(string.Concat(Enumerable.Repeat(Indent, indentsCount)));
    }

    private void AppendEmployeeInformation(Employee employee, StringBuilder builder)
    {
      builder.Append($"{employee.Name} {employee.Lastname}, {employee.Role}, {employee.Company}{Environment.NewLine}");
    }
  }
}