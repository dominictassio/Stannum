using System.Collections.Generic;
using System.Text;

namespace Stannum
{
    public class Environment
    {
        public Environment(Environment enclosing = null)
        {
            Enclosing = enclosing;
            Values = new Dictionary<string, object>();
        }

        public Environment Enclosing { get; }
        
        public Dictionary<string, object> Values { get; }

        public object this[string name]
        {
            get
            {
                if (Values.TryGetValue(name, out var value))
                {
                    return value;
                }

                if (Enclosing != null)
                {
                    return Enclosing[name];
                }
                
                throw new RuntimeException($"Undefined variable '{name}'!");
            }
        }

        public void Define(string name, object value)
        {
            if (Values.ContainsKey(name))
            {
                throw new RuntimeException($"Variable '{name}' is already defined!");
            }

            Values[name] = value;
        }

        public void Assign(string name, object value)
        {
            if (Values.ContainsKey(name))
            {
                Values[name] = value;
            }

            else if (Enclosing != null)
            {
                Enclosing.Assign(name, value);
            }
            else
            {
                throw new RuntimeException($"Variable '{name}' is not defined!");
            }
        }

        public bool ContainsKey(string name)
        {
            return Values.ContainsKey(name);
        }

        public bool TryGetValue(string name, out object value)
        {
            return Values.TryGetValue(name, out value);
        }

        private void WriteTo(StringBuilder builder)
        {
            Enclosing?.WriteTo(builder);

            foreach (var field in Values)
            {
                if (char.IsDigit(field.Key[0]))
                {
                    builder.Append("$");
                }
                
                builder.Append(field.Key).Append(" = ").AppendLine(Interpreter.Stringify(field.Value));
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            WriteTo(builder);
            return builder.ToString();
        }
    }
}