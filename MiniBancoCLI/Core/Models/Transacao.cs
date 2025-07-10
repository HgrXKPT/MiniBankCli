using System;
using System.Collections.Generic;

namespace MiniBancoCLI.Core.Models;

public partial class Transacao
{
    public int IdTransacao { get; set; }

    public DateTime Data { get; set; }

    public decimal Quantia { get; set; }

    public string? TipoTransacao { get; set; }

    public int? IdConta { get; set; }

    public virtual Conta? IdContaNavigation { get; set; }
}
