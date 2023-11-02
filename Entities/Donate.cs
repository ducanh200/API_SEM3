using System;
using System.Collections.Generic;

namespace SEM3_API.Entities;

public partial class Donate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public decimal? Amount { get; set; }
}
