using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private string ingredients;

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ing) :
            base(name, brand, price, gender)
        {
            this.ingredients = string.Join(", ", ing);
        }

        public override string Print()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.Print());
            builder.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));

            return builder.ToString().Trim();
        }
    }
}
