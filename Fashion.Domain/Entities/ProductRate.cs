using Fashion.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace Fashion.Domain.Entities;

public partial class ProductRate : EntityBase<Guid>
{

    public Guid? ProductId { get; set; }

    public Guid? CustomerId { get; set; }

    public int? Rating { get; set; }

    public string? Review { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
