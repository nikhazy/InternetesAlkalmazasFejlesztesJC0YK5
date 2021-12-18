using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetesAlkalmazasFejlesztesJC0YK5.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class WeightAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value.ToString();

            int weight = 0;

            bool valid = false;
            if(int.TryParse(inputValue, out weight))
            {
                valid = weight > 0 ? true : false;
            }

            return valid;
        }
    }
}
