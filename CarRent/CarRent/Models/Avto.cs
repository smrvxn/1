using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class Avto
{
    public int AvtoId { get; set; }

    public string? ClassName { get; set; }

    public string? BrandName { get; set; }

    public string? Mark { get; set; }

    public string? Manufacturer { get; set; }

    public string? YearOfProduction { get; set; }

    public string? Drive { get; set; }

    public string? Weel { get; set; }

    public string? Color { get; set; }

    public string? Transmission { get; set; }

    public string? Endgine { get; set; }

    public string? Photo { get; set; }

    public int? Price { get; set; }

    public int? Deposit { get; set; }
}
