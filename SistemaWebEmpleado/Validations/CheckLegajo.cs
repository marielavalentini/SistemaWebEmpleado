using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validations
{
    public class CheckLegajo : ValidationAttribute
    {
        public CheckLegajo()
        {
            ErrorMessage = "El legajo debe comenzar con AA y contener 5 numeros";
        }
        public override bool IsValid(object value)
        {
            string legajo = value.ToString();
            if (legajo.StartsWith("AA") && (legajo.Length == 7))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
