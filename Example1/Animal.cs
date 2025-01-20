using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoExample.Console
{
    public abstract class Animal : IAnimal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Species? Species { get; set; }
        public int Age { get; set; }
        public bool IsAdopted { get; set; }

        public abstract string MakeSound();

        public string ShowInfo()
        {
            return $"[{this.ToString()?.Split('.').Last()} - ID: {this.Id}] - Name: {this.Name} - Species: {this.Species?.Name} - Age: {this.Age} - {(this.IsAdopted ? "Adopted" : "Not adopted")}\n{this.MakeSound()}";
        }
    }
}
