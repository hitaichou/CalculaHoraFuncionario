
namespace CalculaHoraFuncionario.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public double ValuePerHour { get; set; }

        public Employee()
        {

        }

        public Employee(string name, int hour, double valuePerHour)
        {
            Name = name;
            Hour = hour;
            ValuePerHour = valuePerHour;
        }
        //virtual permite que o método pode ser sobrescrito por uma subclasse
        public virtual double Payment()
        {
            return Hour * ValuePerHour;
        }
    }
}
