namespace ArenaREST.Models
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public decimal Price { get; set; }
        public string StallType { get; set; }

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

        public void ValidatePrice()
        {
            if (Price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be greater than zero.");
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


    }
}
