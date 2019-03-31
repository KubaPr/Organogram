using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace Organogram
{
  internal class CsvEmployeeDeserializer
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

    public List<Employee> Deserialize(string csvFilePath)
    {
      var employees = new List<Employee>();

      using (TextFieldParser parser = new TextFieldParser(csvFilePath))
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
