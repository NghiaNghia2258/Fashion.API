using Fashion.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace Fashion.Domain.Entities;

public partial class ProductCategory : EntityBase<Guid>
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
