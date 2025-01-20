using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample.Console
{
    public class Species
    {
        public Species(string name)
        {
            this.Name = name;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
