﻿using Fashion.Domain.DTOs.Entities.ProductImage;
using Fashion.Domain.DTOs.Entities.ProductVariant;

namespace Fashion.Domain.DTOs.Entities.Product;

public class CreateProductDto
{
    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string Size { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string? Description { get; set; }

    public double Price { get; set; }

    public int? Inventory { get; set; }

    public string? MainImageUrl { get; set; }

    public Guid? CategoryId { get; set; }

    public IEnumerable<CreateProductVariantDto> ProductVariants {  get; set; }
    public IEnumerable<ProductImageDto> ProductImages { get; set; }


}
