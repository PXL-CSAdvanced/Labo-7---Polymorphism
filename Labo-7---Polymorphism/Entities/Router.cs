using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    public class Router : Machine
    {
        public double WorkSpaceWidth { get; protected set; }
        public double WorkSpaceLength { get; protected set; }
        public double CostPerMinute { get; set; }
        protected override int LifeSpanCostPerMinute => 50;

        public Router(string name, double workSpaceWidth, double workSpaceLength, double costPerMinute) : base(name)
        {
            WorkSpaceWidth = workSpaceWidth;
            WorkSpaceLength = workSpaceLength;
            CostPerMinute = costPerMinute;
            LifeSpan = 25000;
        }

        public override void Use(int numberOfMinutes)
        {
            LifeSpan -= (numberOfMinutes * LifeSpanCostPerMinute);
        }

        public override string ToString()
        {
            return $"ROUTER:\t'{Name}' ({WorkSpaceWidth}x{WorkSpaceLength}) {base.ToString()}";
        }
    }
}
