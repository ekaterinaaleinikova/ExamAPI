using System;
using System.Collections.Generic;

namespace ExamAPI.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Content { get; set; } = null!;

    public int ReceiverUserId { get; set; }

    public virtual User CreatedUser { get; set; } = null!;

    public virtual User ReceiverUser { get; set; } = null!;
}
