using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
