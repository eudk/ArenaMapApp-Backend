using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArenaREST.Models;
using System;

namespace ArenaREST.Models.Tests
{
    [TestClass()]
    public class MenuItemTests
    {
        [TestMethod()]
        public void ValidateNameTest()
        {
            var validItem = new MenuItem { Name = "Pizza" };
            var emptyNameItem = new MenuItem { Name = "" };
            var nullNameItem = new MenuItem { Name = null };
            var longNameItem = new MenuItem { Name = new string('A', 51) };

            validItem.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => emptyNameItem.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => nullNameItem.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => longNameItem.ValidateName());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            var validItem = new MenuItem { Price = 9.99m };
            var zeroPriceItem = new MenuItem { Price = 0 };
            var negativePriceItem = new MenuItem { Price = -1 };

            validItem.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => zeroPriceItem.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negativePriceItem.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateImageBase64Test()
        {
            var validItem = new MenuItem { ImageBase64 = Convert.ToBase64String(new byte[] { 1, 2, 3 }) };
            var invalidBase64Item = new MenuItem { ImageBase64 = "invalid_base64" };
            var emptyImageItem = new MenuItem { ImageBase64 = null };

            validItem.ValidateImageBase64();
            emptyImageItem.ValidateImageBase64(); // Should not throw
            Assert.ThrowsException<ArgumentException>(() => invalidBase64Item.ValidateImageBase64());
        }


    }
}
