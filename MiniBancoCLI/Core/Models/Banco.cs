using System;
using System.Collections.Generic;

namespace MiniBancoCLI.Core.Models;

public partial class Banco
{
    public int IdBanco { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Conta> Conta { get; set; } = new List<Conta>();
}
