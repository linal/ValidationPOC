using System;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Foolproof;

namespace WebApplication1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MultipleRequiredIfAttribute : ModelAwareValidationAttribute
    {
        private readonly string[] dependentProperty;
        private readonly Operator[] @operator;
        private readonly object[] dependentValue;

        public MultipleRequiredIfAttribute(string[] dependentProperty, Operator[] @operator, object[] dependentValue)
        {
            this.dependentProperty = dependentProperty;
            this.@operator = @operator;
            this.dependentValue = dependentValue;

            var counts = new[]
            {
                dependentProperty.Count(),
                @operator.Count(),
                dependentValue.Count()
            };

            if (!Array.TrueForAll(counts, x => (counts[0] == x)))
            {
                throw new ArgumentException("Incorrect Parameters");
            }

            Register.Attribute(typeof(MultipleRequiredIfAttribute));
        }

        public override bool IsValid(object value, object container)
        {
            for (int i = 0; i < dependentProperty.Count(); i++)
            {
                var operatorMetadata = OperatorMetadata.Get(@operator[i]);
                var depVal = GetDependentPropertyValue(container, dependentProperty[i]);
                var isValid = operatorMetadata.IsValid(depVal, dependentValue[i]);

                if (!isValid)
                {
                    return true;
                }
            }

            return value != null && !string.IsNullOrEmpty(value.ToString().Trim());
        }

        private object GetDependentPropertyValue(object container, string dependentProperty)
        {
            var type = container.GetType();
            var obj = container;
            char[] chArray = {'.'};
            foreach (string name in dependentProperty.Split(chArray))
            {
                PropertyInfo property = type.GetProperty(name);
                obj = property.GetValue(obj, null);
                type = property.PropertyType;
            }
            return obj;
        }
    }
}