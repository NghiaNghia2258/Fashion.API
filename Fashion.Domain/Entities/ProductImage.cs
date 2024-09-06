using Fashion.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace Fashion.Domain.Entities;

public partial class ProductImage : EntityBase<Guid>
{

    public string ImageUrl { get; set; } = null!;

    public Guid? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
