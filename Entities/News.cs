using System;
using System.Collections.Generic;

namespace SEM3_API.Entities;

public partial class News
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Thumbnail { get; set; }

    public string? Description { get; set; }

    public int? TopicId { get; set; }

    public int? CountryId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual Country? CountryNavigation { get; set; }

    public virtual Topic? Topic { get; set; }
}
