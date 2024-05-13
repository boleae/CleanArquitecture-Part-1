using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using CleanArchitecture.Api.FunctionalTest.Infrastructure;
using CleanArchitecture.Application.Users.GetUserSession;
using CleanArchitecture.Application.Users.LoginUser;
using CleanArchitecture.Application.Users.RegisterUser;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Xunit;

namespace CleanArchitecture.Api.FunctionalTest.Users;

public class GetUserSessionTest : BaseFunctionalTest
{
    public GetUserSessionTest(FunctionalTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Get_ShouldReturnUnauthorized_WhenTokenIsMissing() 
    {
        //act
        var response = await HttpClient.GetAsync("api/users/me");

        //assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);



    }

     [Fact]
    public async Task Get_ShouldReturnUser_WhenTokenIsNotMissing() 
    {
        //arrange
        var token = await GetToken();
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token
        );

        //act
        var user = await HttpClient.GetFromJsonAsync<UserResponse>("api/users/me");

        //assert
        user.Should().NotBeNull();


    }

     [Fact]
    public async Task Login_ShouldReturnOk_WhenUserExists() 
    {
        //arrange 
        var request = new LoginUserRequest(UserData.RegisterUserRequestTest.Email, UserData.RegisterUserRequestTest.Password);

        //act
        var response = await HttpClient.PostAsJsonAsync("api/users/login", request);

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);



    }

     [Fact]
    public async Task Register_ShouldReturnOk_WhenRequestIsValid() 
    {
        //arrange 
        var request = new RegisteruserRequest(
            "test@test.com",
            "test",
            "test",
            "Test12344##"
        );

        //act
        var response = await HttpClient.PostAsJsonAsync("api/users/register", request);

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);



    }
}