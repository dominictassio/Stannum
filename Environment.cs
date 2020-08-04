using System;
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
                throw new Exception($"Variable '{name}' is already defined!");
            }

            Values[name] = value;
        }

        public void Assign(int distance, string name, object value)
        {
            var ancestor = Ancestor(distance);

            if (!ancestor.Values.ContainsKey(name))
            {
                throw new Exception($"Variable '{name}' is not defined!");
            }

            ancestor.Values[name] = value;
        }

        public object this[int distance, string name] => Ancestor(distance)[name];

        public bool TryGetValue(string name, out object value)
        {
            return Values.TryGetValue(name, out value);
        }

        private Environment Ancestor(int distance)
        {
            var environment = this;

            for (var i = 0; i < distance; i += 1)
            {
                environment = environment.Enclosing ?? throw new Exception("Ancestor depth too deep!");
            }

            return environment;
        }

        private void WriteTo(StringBuilder builder)
        {
            Enclosing?.WriteTo(builder);

            foreach (var field in Values)
            {
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