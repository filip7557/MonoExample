using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample.Console
{
    public class Dog : Animal
    {
        public override string MakeSound()
        {
            return $"{this.Name}: AW AW";
        }
    }
}
