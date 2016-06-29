using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    NameMaxLength,
                    NameMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    "Product name", NameMinLength, NameMaxLength));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    BrandMaxLength,
                    BrandMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    "Product brand", BrandMinLength, BrandMaxLength));

                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                Shampoo s = this as Shampoo;

                if (s != null)
                {
                    return s.price * s.Milliliters;
                }
                else
                {
                    return this.price;
                }
            }
            set
            {
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public virtual string Print()
        {
            var builder = new StringBuilder();

            var str = string.Format("- {0} - {1}:", this.Brand, this.Name);
            builder.AppendLine(str);

            str = string.Format("  * Price: ${0}", this.Price);
            builder.AppendLine(str);

            string[] gArr = { "Men", "Women", "Unisex" };

            str = string.Format("  * For gender: {0}", gArr[(int)this.Gender]);
            builder.AppendLine(str);

            return builder.ToString().Trim();
        }
    }
}
