using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace Organogram
{
  class Program
  {
    private enum ColumnNumbers
    {
      Id = 0,
      SupervisorId = 1,
      Name = 2,
      Lastname = 3,
      Role = 6,
      Company = 4
    };

    static void Main(string[] args)
    {
      var employees = SerializeCsvData();

      var organisationTree = new OgranisationStructureSorter().CreateTree(employees);

      var treeStringRepresentation = new TreePrinter().Print(organisationTree);

      Console.Write(treeStringRepresentation);
      Console.Read();
    }

    private static List<Employee> SerializeCsvData()
    {
      var employees = new List<Employee>();

      using (TextFieldParser parser = new TextFieldParser(@"D:\dev\sources\organogram\companies_data.csv"))
      {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
          string[] fields = parser.ReadFields();
          var employee = new Employee(
            id: int.Parse(fields[(int)ColumnNumbers.Id]),
            supervisorId: int.Parse(fields[(int)ColumnNumbers.SupervisorId]),
            name: fields[(int)ColumnNumbers.Name],
            lastname: fields[(int)ColumnNumbers.Lastname],
            role: fields[(int)ColumnNumbers.Role],
            company: fields[(int)ColumnNumbers.Company]);

          employees.Add(employee);
        }
      }

      return employees;
    }
  }
}
