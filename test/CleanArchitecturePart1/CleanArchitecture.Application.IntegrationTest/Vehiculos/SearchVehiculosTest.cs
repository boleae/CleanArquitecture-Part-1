using Bogus.DataSets;
using CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace CleanArchitecture.Application.IntegrationTest.Vehiculos;

public class SearchVehiculos : BaseIntegrationTest
{
    public SearchVehiculos(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task SearchVehiculos_ShouldReturnEmptyList_When_DateRangeInvalid()
    {
        //arrange
        var query = new SearchVehiculosQuery(
            new DateOnly(2023,1,1),
            new DateOnly(2022, 1, 1)

        );

        //act

        var resultado = await Sender.Send(query);

        //assert
        resultado.Value.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchVehiculos_ShouldReturnVehiculos_WhenDateRangeIsValid()
    {
        var query = new SearchVehiculosQuery(
            new DateOnly(2023,1,1),
            new DateOnly(2024,1,1)

        );

        var resultado = await Sender.Send(query);
        resultado.IsSuccess.Should().BeTrue();
    }
}