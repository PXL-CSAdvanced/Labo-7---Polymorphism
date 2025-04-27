using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    class LaserCutter : Router
    {
        public double Accuracy { get; set; }
        protected override int LifeSpanCostPerMinute => 1500;

        public LaserCutter(string name, double workSpaceWidth, double workSpaceLength, double costPerMinute, double accuracy) : base(name, workSpaceWidth, workSpaceLength, costPerMinute)
        {
            Accuracy = accuracy;
            LifeSpan = 5000;
        }

        public override void Use(int numberOfMinutes)
        {
            LifeSpan -= (100 + (numberOfMinutes * LifeSpanCostPerMinute));
        }

        public override string ToString()
        {
            return $"LASER:\t'{Name}' ({WorkSpaceWidth}x{WorkSpaceLength}) [accuracy: {Accuracy}] {LifeSpanInfo()}";
        }
    }
}
