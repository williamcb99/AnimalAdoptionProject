using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Identifiers
{
    public readonly record struct AnimalId(Guid Value)
    {
        public static AnimalId New() => new AnimalId(Guid.NewGuid());
        public static AnimalId From(Guid value) => new AnimalId(value);
        public override string ToString() => Value.ToString();
    }
}
