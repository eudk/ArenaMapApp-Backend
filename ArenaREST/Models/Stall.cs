using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Stall
{
    public int StallId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Coordinates { get; set; }
    public int? EventId { get; set; }
    public string? Floor { get; set; }

    public void ValidateName()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty.");
        }

        if (Name.Length > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(Name), "Name cannot exceed 50 characters.");
        }
    }

    public void ValidateCoordinates()
    {
        if (!string.IsNullOrWhiteSpace(Coordinates) && Coordinates.Length > 500)
        {
            throw new ArgumentOutOfRangeException(nameof(Coordinates), "Coordinates string cannot exceed 500 characters.");
        }
    }

    public void ValidateFloor()
    {
        if (!string.IsNullOrWhiteSpace(Floor))
        {
            if (!int.TryParse(Floor, out int floorNumber) || floorNumber < 1 || floorNumber > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(Floor), "Floor must be 1, 2, or 3.");
            }
        }
    }
}
