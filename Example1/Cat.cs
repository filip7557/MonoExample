using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample.Console
{
    public class Cat : Animal
    {
        public override string MakeSound()
        {
            return $"{this.Name}: MEOW";
        }
    }
}
