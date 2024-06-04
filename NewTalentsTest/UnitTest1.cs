using NewTalents;
namespace NewTalentsTest;

public class UnitTest1
{
     
    public Calculadora ConstruirClasse()
    {
        string data = "02/02/2024";
        Calculadora calc = new Calculadora(data);

        return calc;
    } 

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TestSomar(int num1, int num2, int resultado)
    {
       Calculadora calc = ConstruirClasse();

       int resultadoCalculadora = calc.Somar(num1, num2);

       Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (6, 2, 4)]
    [InlineData (7, 5, 2)]
    public void TestSubtrair(int num1, int num2, int resultado)
    {
       Calculadora calc = ConstruirClasse();

       int resultadoCalculadora = calc.Subtrair(num1, num2);

       Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void TestMultipllicar(int num1, int num2, int resultado)
    {
       Calculadora calc = ConstruirClasse();

       int resultadoCalculadora = calc.Multiplicar(num1, num2);

       Assert.Equal(resultado, resultadoCalculadora);
    } 

    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (5, 5, 1)]
    public void TestDividir(int num1, int num2, int resultado)
    {
       Calculadora calc = ConstruirClasse();

       int resultadoCalculadora = calc.Dividir(num1, num2);

       Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = ConstruirClasse();

        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3,0));
    }
    
    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = ConstruirClasse();
         // ao chamar histórico ele não pode retornar vazio, mas para isso tem que ter sido feita alguma operação antes
        calc.Somar(1, 2);
        calc.Somar(2, 8);
        calc.Somar(3, 7);
        calc.Somar(4, 1);   
        
        var lista = calc.historico();

        Assert.NotEmpty(calc.historico());
        Assert.Equal(3, lista.Count);
    }
}