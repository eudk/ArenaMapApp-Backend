using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArenaREST.Models;
using System;

namespace ArenaREST.Models.Tests
{
    [TestClass()]
    public class MenuTests
    {
        [TestMethod()]
        public void ValidateNameTest()
        {
            var validMenu = new Menu { Name = "Pizzaa" };
            var emptyNameMenu = new Menu { Name = "" };
            var nullNameMenu = new Menu { Name = null };
            var longNameMenu = new Menu { Name = new string('A', 101) };

            validMenu.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => emptyNameMenu.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => nullNameMenu.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => longNameMenu.ValidateName());
        }

        [TestMethod()]
        public void ValidateDescriptionTest()
        {
            var validMenu = new Menu { Description = new string('A', 500) };
            var emptyDescriptionMenu = new Menu { Description = null };
            var longDescriptionMenu = new Menu { Description = new string('A', 501) };

            validMenu.ValidateDescription();
            emptyDescriptionMenu.ValidateDescription(); 
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => longDescriptionMenu.ValidateDescription());
        }

        [TestMethod()]
        public void ValidateImageBase64Test()
        {
            var validMenu = new Menu { ImageBase64 = Convert.ToBase64String(new byte[] { 1, 2, 3 }) };
            var invalidBase64Menu = new Menu { ImageBase64 = "not_base64" };
            var emptyImageMenu = new Menu { ImageBase64 = null };

            validMenu.ValidateImageBase64();
            emptyImageMenu.ValidateImageBase64(); 
            Assert.ThrowsException<ArgumentException>(() => invalidBase64Menu.ValidateImageBase64());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            var validMenu = new Menu { Price = 9.99m };
            var zeroPriceMenu = new Menu { Price = 0 };
            var negativePriceMenu = new Menu { Price = -1 };

            validMenu.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => zeroPriceMenu.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negativePriceMenu.ValidatePrice());
        }
    }
}
