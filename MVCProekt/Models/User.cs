using System;
using System.Collections.Generic;

namespace MVCProekt.Models;

public partial class User
{
    public int Id { get; set; }

    public string Iin { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Document> DocumentCreatedUsers { get; set; } = new List<Document>();

    public virtual ICollection<Document> DocumentReceiverUsers { get; set; } = new List<Document>();
}
