using CleanArchitecture.Application.Users.RegisterUser;

namespace CleanArchitecture.Api.FunctionalTest.Users;

internal static class UserData
{
    public static RegisteruserRequest RegisterUserRequestTest 
        = new("felipe.rosas@test.com", "Felipe", "Rosas", "Test123$");
}

