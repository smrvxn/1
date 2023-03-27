using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class Klient
{
    public int KlientId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Passport { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? DriversLicense { get; set; }

}
