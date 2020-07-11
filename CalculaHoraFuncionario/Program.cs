using System;
using System.Collections.Generic;
using CalculaHoraFuncionario.Entities; //importando classes da pasta Entities
using System.Globalization;

namespace CalculaHoraFuncionario
{
    class Program
    {
        /*
         * Uma empresa possui funcionários próprios e terceirizados.        
         * Para cada funcionário, deseja-se registrar nome, horas trabalhadas e valor por hora. Funcionários terceirizados 
         * possuem ainda uma despesa adicional.
         * O pagamento dos funcionários corresponde ao valor da hora multiplicado pelas horas trabalhadas, sendo que os
         * funcionários terceirizados ainda recebem um bônus correspondente a 110% de sua despesa adicional.
         * Fazer um programa para ler os dados de N funcionários (N fornecido pelo usuário) e armazená-los em uma lista. Depois
         * de ler todos os dados, mostrar nome e pagamento de cada funcionário na mesma ordem em que foram digitados.
         */
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>(); //criando uma lista do tipo Employee (funcionario)

            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data:"); //$ é interpolação
                Console.Write("Outsourced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'y')
                {
                    Console.Write("Addicional Charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    
                    //Constatado que é funcionário terceiro
                    //chama a lista e instancia a subclasse passando os parametros do Employee mais o Additional Charge
                    list.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                }
                else
                {
                    //Não sendo um funcionário terceiro, intancia a classe genérica ou superclasse Employee
                    //e passa os parâmetros para o calculo das horas
                    list.Add(new Employee(name, hours, valuePerHour));
                }

                Console.WriteLine();
                Console.WriteLine("PAYMENTS");
                /*Cria cursor para percorrer os dados da lista
                 * Note que o tipo é Employee e o alias é emp.
                 * "Para todos emp na list, imprima os dados."
                 * O emp consegue acessar as funções da list.
                 * Como houve uma derivação do método Payment da classe Employee para OutsourcedEmployee
                 * e foi usado polimorfismo, podemos acessar através do emp o método Payment com características
                 * diferentes.
                 */
                foreach (Employee emp in list)
                {
                    Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2",CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
