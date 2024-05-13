using System.Net.Http.Json;
using CleanArchitecture.Api.FunctionalTest;
using CleanArchitecture.Api.FunctionalTest.Users;
using CleanArchitecture.Application.Users.LoginUser;
using Xunit;

namespace CleanArchitecture.Api.FunctionalTest.Infrastructure;

public abstract class BaseFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>
{
    protected readonly HttpClient HttpClient;

    protected BaseFunctionalTest(FunctionalTestWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
    }

    protected async Task<string> GetToken() 
    {
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync(
            "api/users/login",
            new LoginUserRequest(
                UserData.RegisterUserRequestTest.Email,
                UserData.RegisterUserRequestTest.Password
            )
        );

        return await response.Content.ReadAsStringAsync();
    }


}