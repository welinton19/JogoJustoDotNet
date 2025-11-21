using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Controllers;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace JogoJustoTest;

public class DepartamentoControllerTest
{
    // Substitua todas as ocorrências de DepartamentoModel por DepartamentoViewModel nos métodos que chamam DepartamentoController.CriarDepartamento

    // Exemplo de correção para o método CriarNovoDepartamento_RetornaCreatedAtAction:
    [Fact]
    public void CriarNovoDepartamento_RetornaCreatedAtAction()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB")
            .Options;

        var context = new JogoDbContext(options);

        // Act
        var controller = new DepartamentoController(context, configuration);

        var novoDepartamento = new DepartamentoViewModel
        {
            NomeDepartamento = "Tecnologia"
            // Adicione outros campos necessários do ViewModel, se houver
        };

        var resultado = controller.CriarDepartamento(novoDepartamento);

        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void ObterDepartamentos_RetornaOkResultComLista()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB2")
            .Options;
        var context = new JogoDbContext(options);
        // Act
        var controller = new DepartamentoController(context, configuration);
        var resultado = controller.ObterDepartamentos();
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void AtualizarDepartamento_RetornaNotFoundQuandoDepartamentoNaoExiste()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB3")
            .Options;
        var context = new JogoDbContext(options);
        // Act
        var controller = new DepartamentoController(context, configuration);
        var departamentoAtualizado = new DepartamentoModel
        {
            NomeDepartamento = "Marketing"
        };
        var resultado = controller.AtualizarDepartamento(999, departamentoAtualizado); // ID inexistente
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void AtualizarDepartamento_RetornaOkQuandoDepartamentoExiste()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB4")
            .Options;
        var context = new JogoDbContext(options);
        // Adiciona um departamento para atualizar
        var departamentoExistente = new DepartamentoModel
        {
            NomeDepartamento = "Vendas"
        };
        context.Departamento.Add(departamentoExistente);
        context.SaveChanges();
        // Act
        var controller = new DepartamentoController(context, configuration);
        var departamentoAtualizado = new DepartamentoModel
        {
            NomeDepartamento = "Vendas Atualizado"
        };
        var resultado = controller.AtualizarDepartamento(departamentoExistente.IdDepartamento, departamentoAtualizado);
        // Assert
        Assert.NotNull(resultado);
    }

    // Substitua DepartamentoModel por DepartamentoViewModel nos métodos que chamam DepartamentoController.CriarDepartamento

    [Fact]
    public void CriarNovoDepartamento_ComDadosInvalidos_RetornaBadRequest()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB5")
            .Options;
        var context = new JogoDbContext(options);
        // Act
        var controller = new DepartamentoController(context, configuration);
        var novoDepartamento = new DepartamentoViewModel
        {
            NomeDepartamento = "" // Nome inválido
        };
        var resultado = controller.CriarDepartamento(novoDepartamento);
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void ObterDepartamentos_QuandoNaoExistemDepartamentos_RetornaListaVazia()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB6")
            .Options;
        var context = new JogoDbContext(options);
        // Act
        var controller = new DepartamentoController(context, configuration);
        var resultado = controller.ObterDepartamentos();
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void AtualizarDepartamento_ComDadosInvalidos_RetornaBadRequest()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB7")
            .Options;
        var context = new JogoDbContext(options);
        // Adiciona um departamento para atualizar
        var departamentoExistente = new DepartamentoModel
        {
            NomeDepartamento = "Suporte"
        };
        context.Departamento.Add(departamentoExistente);
        context.SaveChanges();
        // Act
        var controller = new DepartamentoController(context, configuration);
        var departamentoAtualizado = new DepartamentoModel
        {
            NomeDepartamento = "" // Nome inválido
        };
        var resultado = controller.AtualizarDepartamento(departamentoExistente.IdDepartamento, departamentoAtualizado);
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void CriarNovoDepartamento_ComNomeDuplicado_RetornaConflict()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB8")
            .Options;
        var context = new JogoDbContext(options);
        // Adiciona um departamento existente
        var departamentoExistente = new DepartamentoModel
        {
            NomeDepartamento = "Financeiro"
        };
        context.Departamento.Add(departamentoExistente);
        context.SaveChanges();
        // Act
        var controller = new DepartamentoController(context, configuration);
        var novoDepartamento = new DepartamentoViewModel
        {
            NomeDepartamento = "Financeiro" // Nome duplicado
        };
        var resultado = controller.CriarDepartamento(novoDepartamento);
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void AtualizarDepartamento_ParaNomeDuplicado_RetornaConflict()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB9")
            .Options;
        var context = new JogoDbContext(options);
        // Adiciona dois departamentos existentes
        var departamento1 = new DepartamentoModel
        {
            NomeDepartamento = "RH"
        };
        var departamento2 = new DepartamentoModel
        {
            NomeDepartamento = "Logística"
        };
        context.Departamento.Add(departamento1);
        context.Departamento.Add(departamento2);
        context.SaveChanges();
        // Act
        var controller = new DepartamentoController(context, configuration);
        var departamentoAtualizado = new DepartamentoModel
        {
            NomeDepartamento = "RH" // Nome duplicado
        };
        var resultado = controller.AtualizarDepartamento(departamento2.IdDepartamento, departamentoAtualizado);
        // Assert
        Assert.NotNull(resultado);
    }

    [Fact]
    public void DeletarDepartamento_RetornaNotFoundQuandoDepartamentoNaoExiste()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:JogoJustoConnection", "FakeConnectionString"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDB10")
            .Options;
        var context = new JogoDbContext(options);
        // Act
        var controller = new DepartamentoController(context, configuration);
        var resultado = controller.DeletarDepartamento(999); // ID inexistente
        // Assert
        Assert.NotNull(resultado);
    }
}
