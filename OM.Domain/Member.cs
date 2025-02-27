﻿namespace OM.Domain;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Address { get; set; }
}
