using DomainModels.UserAggregate.Entities;

namespace EShop.Test._01_Core.DomainModels.UserAggregate.Entities;

public sealed class UserTests
{
    [Fact]
    public void Create_WhenEverythingPassedTruthy_ReturnUser()
    {
        //Arrangement
        var email = "fgoodarzi.pr@gmail.com";
        var fullName = "Farshad Goodarzi";

        //Act
        var user = User.Create(fullName, email);

        //Assert
        Assert.IsType<User>(user);
        Assert.NotNull(user);
        Assert.Equal(user.Email, email);
        Assert.Equal(user.FullName, fullName);
    }
}
