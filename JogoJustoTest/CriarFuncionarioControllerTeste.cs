using JogoJustoDotNet.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTest
{
    public class CriarFuncionarioControllerTeste
    {
        private class Funcionario
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public string Cargo { get; set; }
        }

        [Fact]
        public void CriarNovoFuncionario()
        {
            // Arrange
            var controller = new CriarFuncionarioControllerTeste();
            var funcionarioNovo = new Funcionario
            {
                Nome = "João Silva",
                Email = "jao@gmail.com",
                Senha = "senha123",
                Cargo = "Gerente"
            };

            // Act
            var resultado = controller.CriarFuncionario(funcionarioNovo.Nome, funcionarioNovo.Email, funcionarioNovo.Senha, funcionarioNovo.Cargo) as Funcionario;
            Assert.NotNull(resultado);
            // Assert
            Assert.Equal(funcionarioNovo.Nome, resultado.Nome);
            Assert.Equal(funcionarioNovo.Email, resultado.Email);
            Assert.Equal(funcionarioNovo.Cargo, resultado.Cargo);
        }

        private object? CriarFuncionario(string nome, string email, string senha, string cargo)
        {
            var novoFuncionario = new Funcionario
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Cargo = cargo
            };
            return novoFuncionario;
        }

        [Fact]
        public void ListarFuncionario()
        {
            // Arrange
            var lstarFuncionario = new List<Funcionario>
            {
                new Funcionario { Nome = "João Silva", Email = "joao@gmai.com", Senha = "senha123", Cargo = "Gerente" },
            };
            var funcionario = new Funcionario
            {
                Nome = "João Silva",
                Email = "joao@gmail.com",
                Senha = "senha123",
            };
            // Act
            lstarFuncionario.Add(funcionario);
        }

        [Fact]
        public void DeletarFuncionario()
        {
            // Arrange
            var listaFuncionarios = new List<Funcionario>
            {
                new Funcionario { Nome = "João Silva", Email = "joao@gmail.com", Senha = "senha123", Cargo = "Gerente" },
            };
            var funcionarioParaDeletar = listaFuncionarios[0];
            // Act
            listaFuncionarios.Remove(funcionarioParaDeletar);
        }

        [Fact]
        public void AtualizarFuncionario()
        {
            // Arrange
            var funcionario = new Funcionario
            {
                Nome = "João Silva",
                Email = "joao@gmai.com",
                Senha = "senha123",
                Cargo = "Gerente"
            };
            // Act
            funcionario.Nome = "João Pereira";
            funcionario.Email = "joao@gmail.com";
            funcionario.Cargo = "Diretor";

            // Assert
            Assert.Equal("João Pereira", funcionario.Nome);
        }
    }
}
