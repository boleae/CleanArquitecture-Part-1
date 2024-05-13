using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.ArchitectureTest.Infrastructure;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace CleanArchitecture.ArchitectureTest.Application;

public class ApplicationTest : BaseTest
{
    //Evaluamos que los CommandHandlers son intenals 
    [Fact]
    public void CommandHandler_Should_NotBePublic()
    {
        var resultados = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .NotBePublic()
            .GetResult();
        
        resultados.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QueryHandler_Should_NotBePublic()
    {
        var resultados = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .NotBePublic()
            .GetResult();
        
        resultados.IsSuccessful.Should().BeTrue();
    }


    
}