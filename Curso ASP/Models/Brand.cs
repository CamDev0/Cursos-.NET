using System;
using System.Collections.Generic;

namespace Curso_ASP.Models;

public partial class Brand
{
    public int Brandld { get; set; }

    public string NameBrand { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; } = new List<Category>();
}
