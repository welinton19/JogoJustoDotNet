using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTest;

public class EmpresaControllerTest
{
    [Fact]
    public void CriarEmpresa_RetornaCreatedAtAction()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoJustoDotNet.AppData.JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var contexto = new JogoDbContext(options);
        var configMock = new Mock<IConfiguration>();
        var controller = new EmpresaController(contexto, configMock.Object);
        var novaEmpresa = new JogoJustoDotNet.Models.EmpresaModel
        {
            Nome = "Empresa Teste",
            InscricaoEstadual = "Tecnologia",
            Endereco = "Rua Teste, 123",
            Telefone = "(11) 1234-5678"
        };
        // Act
        var resultado = controller.CriarEmpresa(novaEmpresa);
        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(resultado);
        var empresaRetornada = Assert.IsType<JogoJustoDotNet.Models.EmpresaModel>(createdAtActionResult.Value);
        Assert.Equal("Empresa Teste", empresaRetornada.Nome);
    }

    [Fact]
    public void AtualizarEmpresa_EmpresaExistente_RetornaOk()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoJustoDotNet.AppData.JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var contexto = new JogoDbContext(options);
        var configMock = new Mock<IConfiguration>();
        var controller = new EmpresaController(contexto, configMock.Object);
        var empresaExistente = new JogoJustoDotNet.Models.EmpresaModel
        {
            Nome = "Empresa Existente",
            InscricaoEstadual = "123456789",
            Endereco = "Rua Existente, 456",
            Telefone = "(11) 9876-5432"
        };
        contexto.Empresa.Add(empresaExistente);
        contexto.SaveChanges();
        var empresaAtualizada = new JogoJustoDotNet.Models.EmpresaModel
        {
            Nome = "Empresa Atualizada",
            InscricaoEstadual = "987654321",
            Endereco = "Rua Atualizada, 789",
            Telefone = "(11) 1122-3344"
        };
        // Act
        var resultado = controller.AtualizarEmpresa(empresaExistente.EmpresaId, empresaAtualizada);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var empresaRetornada = Assert.IsType<JogoJustoDotNet.Models.EmpresaModel>(okResult.Value);
        Assert.Equal("Empresa Atualizada", empresaRetornada.Nome);
    }

    [Fact]
    public void AtualizarEmpresa_EmpresaNaoExistente_RetornaNotFound()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoJustoDotNet.AppData.JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var contexto = new JogoDbContext(options);
        var configMock = new Mock<IConfiguration>();
        var controller = new EmpresaController(contexto, configMock.Object);
        var empresaAtualizada = new JogoJustoDotNet.Models.EmpresaModel
        {
            Nome = "Empresa Atualizada",
            InscricaoEstadual = "987654321",
            Endereco = "Rua Atualizada, 789",
            Telefone = "(11) 1122-3344"
        };
        // Act
        var resultado = controller.AtualizarEmpresa(999, empresaAtualizada);
        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(resultado);
        Assert.Equal("Empresa não encontrada.", notFoundResult.Value);
    }

    [Fact]
    public void ObterEmpresas_RetornaOkComListaDeEmpresas()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoJustoDotNet.AppData.JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var contexto = new JogoDbContext(options);
        var configMock = new Mock<IConfiguration>();
        var controller = new EmpresaController(contexto, configMock.Object);
        contexto.Empresa.Add(new JogoJustoDotNet.Models.EmpresaModel
        {
            Nome = "Empresa 1",
            InscricaoEstadual = "123456789",
            Endereco = "Rua 1, 123",
            Telefone = "(11) 1111-1111"
        });
        contexto.Empresa.Add(new JogoJustoDotNet.Models.EmpresaModel
        {
            Nome = "Empresa 2",
            InscricaoEstadual = "987654321",
            Endereco = "Rua 2, 456",
            Telefone = "(11) 2222-2222"
        });
        contexto.SaveChanges();
        // Act
        var resultado = controller.ObterEmpresas();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var empresasRetornadas = Assert.IsType<List<JogoJustoDotNet.Models.EmpresaModel>>(okResult.Value);
        Assert.Equal(2, empresasRetornadas.Count);
    }

    

    [Fact]
    public void DeletarEmpresas_SemEmpresas_RetornaOk()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoJustoDotNet.AppData.JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var contexto = new JogoJustoDotNet.AppData.JogoDbContext(options);
        var configMock = new Mock<IConfiguration>();
        var controller = new EmpresaController(contexto, configMock.Object);
        // Act
        var empresasAntesDeletar = contexto.Empresa.ToList();
        contexto.Empresa.RemoveRange(empresasAntesDeletar);
        contexto.SaveChanges();
        var empresasDepoisDeletar = contexto.Empresa.ToList();
        // Assert
        Assert.Empty(empresasDepoisDeletar);
    }
}
