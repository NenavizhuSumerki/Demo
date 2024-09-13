using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Demo.EntityModels;

public partial class Service
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public int Durationinseconds { get; set; }

    public string? Description { get; set; }

    public decimal? Discount { get; set; }

    public string? Mainimagepath { get; set; }

    public Bitmap ImageBitmap 
    { get { return new Bitmap(Environment.CurrentDirectory + "/" + Mainimagepath); } }

    public virtual ICollection<Clientservice> Clientservices { get; set; } = new List<Clientservice>();

    public virtual ICollection<Servicephoto> Servicephotos { get; set; } = new List<Servicephoto>();
}
