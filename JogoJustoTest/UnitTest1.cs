using Microsoft.AspNetCore.Http.HttpResults;

namespace JogoJustoTest
{
    public class UnitTest1
    {
        [Fact]
        public void VerificarAcessoGerente()
        {
            //Arrange
            var papel = "Gerente";



            //Act
            if ( papel == "Gerente")
            {
                //Assert
                Console.WriteLine("Acesso permitido");
            }
            else
            {
                //Assert
                Console.WriteLine("Acesso negado");
            }

            //Assert
            Assert.Equal("Acesso permitido", "Acesso permitido");
        }

        [Fact]
        public void VerificarAcessoAdmin()
        {
            //Arrange
            var papel = "Admin";



            //Act
            if (papel == "Admin")
            {
                //Assert
                Console.WriteLine("Acesso permitido");
            }
            else
            {
                //Assert
                Console.WriteLine("Acesso negado");
            }

            //Assert
            Assert.Equal("Acesso permitido", "Acesso permitido");
        }

        [Fact]
        public void VerificarAcessoNaoEGerente()
        {
            //Arrange
            var papel = "Admin";



            //Act
            if (papel == "Gerente")
            {
                //Assert
                Console.WriteLine("Acesso permitido");
            }
            else
            {
                //Assert
                Console.WriteLine("Acesso negado");
            }

            //Assert
            Assert.False(false);
        }
    }
}