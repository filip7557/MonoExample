using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample.Console
{
    internal interface IAnimal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Species? Species { get; set; }
        public int Age { get; set; }
        public bool IsAdopted { get; set; }

        public string MakeSound();

        public string ShowInfo();
    }
}
