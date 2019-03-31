using System;

namespace Organogram
{
  class Program
  {
    static void Main(string[] args)
    {
      var employees = new CsvEmployeeDeserializer().Deserialize(@".\companies_data.csv");
      var organisationTree = new OgranisationStructureSorter().CreateTree(employees);
      var treeStringRepresentation = new TreePrinter().Print(organisationTree);

      Console.Write(treeStringRepresentation);
      Console.Read();
    }
  }
}
