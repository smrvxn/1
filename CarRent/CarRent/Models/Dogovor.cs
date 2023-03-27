using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class Dogovor
{
    public int DogovorId { get; set; }

    public int? KlientId { get; set; }

    public int? ManagerId { get; set; }

    public int? AvtoId { get; set; }

    public DateTime? Date { get; set; }

    public int? Day { get; set; }

    public virtual Avto? Avto { get; set; }

    public virtual Klient? Klient { get; set; }

    public virtual Manager? Manager { get; set; }
}
