using NewTalents;
namespace NewTalentsTest;

public class UnitTest1
{
    [Theory]
    [InlineData (1, 2, 3)]
    public void Test1(int num1, int num2, int resultado)
    {
       Calculadora calc = new Calculadora();

       int resultadoCalculadora = calc.Somar(num1, num2);

       Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void Test2()
    {
       Calculadora calc = new Calculadora();

       int resultado = calc.Somar(4, 5);

       Assert.Equal(9, resultado);
    }
}