using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    class General : Machine
    {
        protected override int LifeSpanCostPerMinute => 1;

        public General(string name) : base(name) { }

        public override void Use(int numberOfMinutes)
        {
            LifeSpan -= numberOfMinutes * LifeSpanCostPerMinute;
        }
        public override string ToString()
        {
            return $"{Name} {base.ToString()}";
        }
    }
}
