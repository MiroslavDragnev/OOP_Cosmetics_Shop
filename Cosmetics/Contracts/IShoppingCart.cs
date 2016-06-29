﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Contracts
{
    public interface IShoppingCart
    {
        void AddProduct(IProduct product);
        void RemoveProduct(IProduct product);
        bool ContainsProduct(IProduct product);
        decimal TotalPrice();
    }
}
