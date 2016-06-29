using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine
{
    public class Category : ICategory
    {
        private const int CategoryMinLength = 2;
        private const int CategoryMaxLength = 15;
        private string name;
        private ICollection<IProduct> productsList;

        public Category(string name)
        {
            this.Name = name;
            this.ProductsList = new List<IProduct>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    CategoryMaxLength,
                    CategoryMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + " name", CategoryMinLength, CategoryMaxLength));
                this.name = value;
            }
        }

        public ICollection<IProduct> ProductsList
        {
            get { return this.productsList; }
            set { this.productsList = value; }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.ProductsList.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.ProductsList.Remove(cosmetics);
        }

        public string Print()
        {
            var builder = new StringBuilder();

            var str = string.Format("{0} category - {1} {2} in total", this.Name, this.ProductsList.Count, this.ProductsList.Count == 1 ? "product":"products");
            builder.AppendLine(str);

            var newList = this.ProductsList.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);

            foreach(var p in newList)
            {
                builder.AppendLine(p.Print());
            }

            return builder.ToString().Trim();
        }
    }
}
