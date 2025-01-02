namespace ArenaREST.Models
{
    public class Menu
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; } // FK for Event

        public void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty.");
            }

            if (Name.Length > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Name), "Name cannot exceed 100 characters.");
            }
        }

        public void ValidateDescription()
        {
            if (!string.IsNullOrWhiteSpace(Description) && Description.Length > 500)
            {
                throw new ArgumentOutOfRangeException(nameof(Description), "Description cannot exceed 500 characters.");
            }
        }

        public void ValidateImageBase64()
        {
            if (!string.IsNullOrWhiteSpace(ImageBase64))
            {
                try
                {
                    Convert.FromBase64String(ImageBase64);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("ImageBase64 is not a valid Base64 string.", nameof(ImageBase64));
                }
            }
        }

        public void ValidatePrice()
        {
            if (Price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be greater than zero.");
            }
        }
    }
}
