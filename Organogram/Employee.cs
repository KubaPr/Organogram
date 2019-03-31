namespace Organogram
{
  public class Employee
  {
    public int Id { get; }
    public int SupervisorId { get; }
    public string Name { get; }
    public string Lastname { get; }
    public string Role { get; }
    public string Company { get; }

    public Employee(
      int id,
      int supervisorId,
      string name,
      string lastname,
      string role,
      string company)
    {
      Id = id;
      SupervisorId = supervisorId;
      Name = name;
      Lastname = lastname;
      Role = role;
      Company = company;
    }
  }
}
