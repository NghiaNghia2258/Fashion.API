using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Domain.Abstractions.Entities
{
    public interface IUpdateTracking
    {
        DateTime? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
        string? UpdatedName { get; set; }
    }
}
