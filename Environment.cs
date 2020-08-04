using System;
using System.Collections.Generic;
using System.Text;

namespace Stannum
{
    public class Environment
    {
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        public Environment(Environment enclosing = null)
        {
            Enclosing = enclosing;
        }

        public Environment Enclosing { get; }

        public object this[string name]
        {
            get
            {
                if (_values.TryGetValue(name, out var value))
                {
                    return value;
                }

                if (Enclosing != null)
                {
                    return Enclosing[name];
                }
                
                throw new RuntimeException($"Undefined variable {name}.");
            }

            set
            {
                if (_values.ContainsKey(name))
                {
                    throw new Exception($"{name} already defined in environment!");
                }

                _values[name] = value;
            }
        }

        public object this[int distance, string name]
        {
            get => Ancestor(distance)[name];
            set => Ancestor(distance)[name] = value;
        }

        public bool TryGetValue(string name, out object value)
        {
            return _values.TryGetValue(name, out value);
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

            foreach (var name in _values.Keys)
            {
                builder.Append(name).Append(" = ").AppendLine(_values[name]?.ToString() ?? "None");
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