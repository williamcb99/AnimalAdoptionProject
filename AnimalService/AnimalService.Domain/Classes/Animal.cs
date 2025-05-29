using AnimalService.Domain.Enums;
using SharedKernel.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalService.Domain.Classes
{
    public class Animal
    {
        public AnimalId Id { get;  set; }
        public AnimalType Type { get; set; }
        public string Name { get; set; }
        public int AgeInYears { get; set; }
    }
}
