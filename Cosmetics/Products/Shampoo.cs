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

            string str = string.Format("  * Quantity: {0} ml", this.Milliliters);
            builder.AppendLine(str);

            string[] uArr = { "EveryDay", "Medical" };

            str = string.Format("  * Usage: {0}", uArr[(int)this.Usage]);
            builder.AppendLine(str);

            return builder.ToString().Trim();
        }
    }
}
