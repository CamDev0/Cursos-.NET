using System;
using System.Collections.Generic;

namespace Curso_ASP.Models;

public partial class Category
{
    public int Categoryld { get; set; }

    public string NameCaty { get; set; } = null!;

    public int Fkbrandld { get; set; }

    public virtual Brand FkbrandldNavigation { get; set; } = null!;
}
