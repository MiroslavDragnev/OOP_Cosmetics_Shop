using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private static readonly string[] UsageArray = { "EveryDay", "Medical" };

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) :
            base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;

        }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override string Print()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.Print());
            builder.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            builder.AppendLine(string.Format("  * Usage: {0}", UsageArray[(int)this.Usage]));

            return builder.ToString().Trim();
        }
    }
}
