using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass()]
public class StallTests
{
    [TestMethod()]
    public void ValidateNameTest()
    {
        var validStall = new Stall { Name = "Main Stall" };
        var emptyNameStall = new Stall { Name = "" };
        var nullNameStall = new Stall { Name = null };
        var longNameStall = new Stall { Name = new string('A', 51) };

        validStall.ValidateName();
        Assert.ThrowsException<ArgumentNullException>(() => emptyNameStall.ValidateName());
        Assert.ThrowsException<ArgumentNullException>(() => nullNameStall.ValidateName());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => longNameStall.ValidateName());
    }

    [TestMethod()]
    public void ValidateCoordinatesTest()
    {
        var validStall = new Stall { Coordinates = new string('A', 500) };
        var emptyCoordinatesStall = new Stall { Coordinates = null };
        var longCoordinatesStall = new Stall { Coordinates = new string('A', 501) };

        validStall.ValidateCoordinates();
        emptyCoordinatesStall.ValidateCoordinates(); 
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => longCoordinatesStall.ValidateCoordinates());
    }

    [TestMethod()]
    public void ValidateFloorTest()
    {
        var validStall1 = new Stall { Floor = "1" };
        var validStall2 = new Stall { Floor = "2" };
        var validStall3 = new Stall { Floor = "3" };
        var emptyFloorStall = new Stall { Floor = null };
        var invalidFloorStall1 = new Stall { Floor = "0" };
        var invalidFloorStall2 = new Stall { Floor = "4" };
        var invalidFloorStall3 = new Stall { Floor = "invalid" };

        validStall1.ValidateFloor();
        validStall2.ValidateFloor();
        validStall3.ValidateFloor();
        emptyFloorStall.ValidateFloor(); 
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidFloorStall1.ValidateFloor());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidFloorStall2.ValidateFloor());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidFloorStall3.ValidateFloor());
    }
}
