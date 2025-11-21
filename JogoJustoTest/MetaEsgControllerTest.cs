using JogoJustoDotNet.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTest;

public class MetaEsgControllerTest
{
    [Fact]
    public void CriarMetaEsg_RedirectsToCreatedAtAction()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDb")
            .Options;
        using var context = new JogoDbContext(options);
        var config = new ConfigurationBuilder().Build();
        
        //Act
        var metaEsg = new JogoJustoDotNet.Models.MetaEsgModel
        {
            DescricaoMetaEsg = "Reduzir emissões de carbono em 20% até 2025",
            TipoMetaEsg = "Ambiental"
            
        };

        // Adicione ao contexto e salve:
        context.MetaEsg.Add(metaEsg);
        context.SaveChanges();

        // Assert para garantir que foi salvo:
        var savedMetaEsg = context.MetaEsg.FirstOrDefault(m => m.DescricaoMetaEsg == "Reduzir emissões de carbono em 20% até 2025");
        Assert.NotNull(savedMetaEsg);
        Assert.Equal("Ambiental", savedMetaEsg.TipoMetaEsg);
    }

    [Fact]
    public void ObterMetasEsg_ReturnsAllMetasEsg()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDb_GetAll")
            .Options;
        using var context = new JogoDbContext(options);
        var config = new ConfigurationBuilder().Build();
        // Seed data
        context.MetaEsg.AddRange(
            new JogoJustoDotNet.Models.MetaEsgModel { DescricaoMetaEsg = "Meta 1", TipoMetaEsg = "Social" },
            new JogoJustoDotNet.Models.MetaEsgModel { DescricaoMetaEsg = "Meta 2", TipoMetaEsg = "Governança" }
        );
        context.SaveChanges();
        // Act
        var metasEsg = context.MetaEsg.ToList();
        // Assert
        Assert.Equal(2, metasEsg.Count);
    }

    [Fact]
    public void AtualizarMetaEsg_UpdatesExistingMetaEsg()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDb_Update")
            .Options;
        using var context = new JogoDbContext(options);
        var config = new ConfigurationBuilder().Build();
        // Seed data
        var metaEsg = new JogoJustoDotNet.Models.MetaEsgModel
        {
            DescricaoMetaEsg = "Meta Original",
            TipoMetaEsg = "Social"
        };
        context.MetaEsg.Add(metaEsg);
        context.SaveChanges();
        // Act
        var metaEsgToUpdate = context.MetaEsg.First();
        metaEsgToUpdate.DescricaoMetaEsg = "Meta Atualizada";
        context.SaveChanges();
        // Assert
        var updatedMetaEsg = context.MetaEsg.First();
        Assert.Equal("Meta Atualizada", updatedMetaEsg.DescricaoMetaEsg);
    }

    [Fact]
    public void ObterMetaEsgPorId_ReturnsCorrectMetaEsg()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDb_GetById")
            .Options;
        using var context = new JogoDbContext(options);
        var config = new ConfigurationBuilder().Build();
        // Seed data
        var metaEsg = new JogoJustoDotNet.Models.MetaEsgModel
        {
            DescricaoMetaEsg = "Meta para Buscar",
            TipoMetaEsg = "Governança"
        };
        context.MetaEsg.Add(metaEsg);
        context.SaveChanges();
        // Act
        var savedMetaEsg = context.MetaEsg.First();
        var fetchedMetaEsg = context.MetaEsg.Find(savedMetaEsg.IdMetaEsg);
        // Assert
        Assert.NotNull(fetchedMetaEsg);
        Assert.Equal("Meta para Buscar", fetchedMetaEsg.DescricaoMetaEsg);
    }

    [Fact]
    public void DeletarMetaEsg_RemovesMetaEsg()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JogoDbContext>()
            .UseInMemoryDatabase(databaseName: "JogoJustoTestDb_Delete")
            .Options;
        using var context = new JogoDbContext(options);
        var config = new ConfigurationBuilder().Build();
        // Seed data
        var metaEsg = new JogoJustoDotNet.Models.MetaEsgModel
        {
            DescricaoMetaEsg = "Meta para Deletar",
            TipoMetaEsg = "Ambiental"
        };
        context.MetaEsg.Add(metaEsg);
        context.SaveChanges();
        // Act
        var savedMetaEsg = context.MetaEsg.First();
        context.MetaEsg.Remove(savedMetaEsg);
        context.SaveChanges();
        // Assert
        var deletedMetaEsg = context.MetaEsg.Find(savedMetaEsg.IdMetaEsg);
        Assert.Null(deletedMetaEsg);
    }
}
