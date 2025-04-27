using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Labo_7___Polymorphism.Entities
{
    public abstract class Machine
    {
        protected abstract int LifeSpanCostPerMinute { get; }
        public string Name { get; set; }
        public int LifeSpan { get; set; }
        public float Price { get; set; }

        public bool OutOfUse
        {
            get
            {
                return LifeSpan <= 0;
            }
        }

        protected Machine(string name)
        {
            Name = name;
            LifeSpan = 1000;
        }

        public abstract void Use(int numberOfMinutes);

        public string LifeSpanInfo()
        {
            return OutOfUse ? "<OUT OF USE>" : $"<lifespan: {LifeSpan} h>";
        }

        public override string ToString()
        {
            return LifeSpanInfo();
        }
    }
}
