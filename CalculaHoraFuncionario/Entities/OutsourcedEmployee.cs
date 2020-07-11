using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaHoraFuncionario.Entities
{
    class OutsourcedEmployee : Employee //herda todas as propriedades e métodos de Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee()
        {
        }

        //Herdando os parâmetros do construtor da superclasse 
        public OutsourcedEmployee(string name, int hour, double valuePerHour, double additionalCharge)
            :base(name, hour, valuePerHour)
        {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment()
        {
            //Adicionando 110 + a despesa adicional
            return base.Payment() + 1.1 * AdditionalCharge;
 
        }
    }    
}
