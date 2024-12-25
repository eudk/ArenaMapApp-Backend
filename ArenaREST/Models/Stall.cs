using System.ComponentModel.DataAnnotations.Schema;

public class Stall
{
    public int StallId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Coordinates { get; set; }
    public int EventId { get; set; }

  
    public string Floor { get; set; }
}
