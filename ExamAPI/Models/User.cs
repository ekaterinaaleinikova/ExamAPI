using System;
using System.Collections.Generic;

namespace ExamAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Iin { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Document> DocumentCreatedUsers { get; } = new List<Document>();

    public virtual ICollection<Document> DocumentReceiverUsers { get; } = new List<Document>();
}
