<h1>DIO | Blindando Código com TDD e Testes Unitários - Modulo 5</h1>

-> Aprender a blindar código com TDD, como usar e quando utilizar em conjunto com testes unitários.
<br>
[Digital Innovation One](https://www.dio.me/en)

## 📚 Documentação 
- [Documentação .NET](https://git-scm.com/doc)
- [Documentação C#](https://docs.github.com/pt)

## 💻 Resumos das Aulas

| Aulas | Resumos |
|-------|---------|
| TDD e testes unitários com .NET | [Resumos]() |

### TDD

-> Test Driven Development

-> Premissa é desenvolvimento liderado por testes, ou seja, ao invés de codar primeiro e testar depois, aqui nós criamos os testes antes.

-> Útil em situações como: Regras de negócios bem especificas e definidas, código e funções já estão definidas, ai facilitam demais para o uso do TDD.

-> Basicamente desenvolvemos com testes, testes falhos, torne eles bem sucedidos e depois refatore.

### O que usar Aqui

-> Microsoft Visual Studio Community 2019

-> DotNet Core 3.1

-> xUnit.

->> É muito comum empresas estarem usando versões antigas do .NET CORE, para criar seus códigos personalizados e usar builds mais estáveis e seguras.

->> Desenvolvi utilizando .NET 6, depois volto e refaço na versão pretendida !!!.

### Refinamento inicial

-> Uma Calculadora que contém Soma, Subtração, Divisão e Multiplicação e histórico de operações.

Regras de negócios:

->> Números inteiros

->> 2 parâmetros por operação

->> Sempre retornar as últimas 3 operações do histórico

## Prática parte 1: Criando um novo projeto

-> Criar pasta NewTalents e nela criar dotnet new console

-> Criar pasta NewTalentsTest e nela criar dotnet new xunit

->> Tudo criado dentro do projeto de testes não pode ser usado dentro do projeto de código.

## Prática parte 2: Criando as funções da Calculadora

-> Criação dos testes falhos.

-> Aplicando as regras de negócio nos teste.

-> Boa prática na criação dos teste.

->> Ao invés de criar métodos da Calculadora, iremos criar testes primeiro.

->> No TDD o máximo que faremos é deixar só a estrutura e deixar o valor nativo do formato.

```
->> Retornos vazios !
String return ""
int return 0
array list return new List<string>();


 public List<string> historico()
        {
            return new List<string>();  -> Teste de retorno de histórico
        }
```

--->>> NÃO CODIFICAR, ANTES DE CODIFICAR OS TESTE, PREMISSA DO TDD !

-> Tratas os testes agora como Theory, vários testes usando apenas o mesmo método de teste.

-> Tiramos ele de fato e passamos para teoria, ou seja, não estamos presos aqueles números exatos, podemos passar vários testes.


### Entendendo o InlineData

-> Pode-se escrever vários InlineData para testes.

->> Cuidado ao utilizar métodos assincronos, pode terminar de executar o segundo antes do primeiro, se tiver dados compartilhados pode gerar problemas (pesquisar mais sobre o tema).
```
[Theory]
[InlineData (1, 2, 2)]   -> o 1 parametro (1), 2 parametro (2) e 3 parametro que é o resultado esperado (2)
[InlineData (4, 5, 20)]  -> o 1 parametro (4), 2 parametro (5) e 3 parametro que é o resultado esperado (20)

public void TestMultipllicar(int num1, int num2, int resultado)  -> baseado nesses parâmetros !!!
    {
       Calculadora calc = new Calculadora();

       int resultadoCalculadora = calc.Multiplicar(num1, num2);

       Assert.Equal(resultado, resultadoCalculadora);
    }
```
-->> Perceber que todos os testes tendo dado falhos, por que este é o objetivo, a construção de dados testado até está correta caso já existisse lógica na calculadora !!!

#### Regra de negócio não especificada pelo cliente

-> O Dividir não pode ter operações de divisão por 0.

```
public void TestarDviisaoPorZero()
    {
        Calculadora calc = new Calculadora();

        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3,0));
    }

->> Tratando exceptions com Assert, poderia usar a classe pai Exception.    

->> Pesquisar sobre lambida, essa expressão () => calc.Dividir(3,0) !!!
```

### Cuidar agora do histórico

-> Ao chamar histórico ele não pode retornar vazio, mas para isso tem que ter sido feita alguma operação antes.

-> Então vamos simular algumas operações

```
public void TestarHistorico()
    {
        Calculadora calc = new Calculadora();

        calc.Somar(1, 2);
        calc.Somar(2, 8);
        calc.Somar(3, 7);
        calc.Somar(4, 1);   
        
        var lista = calc.historico();

        Assert.NotEmpty(calc.historico());   -> Pode-se usar vários Asserts e tambem pode ser utilizado
        Assert.Equal(3,)                        mais acima, principalmente quando usamos um construtor e
    }                                           queremos ver se a classe está não instanciada vazia, podemos
                                                usar Assert.NotNull ou Assert.Null
```

## Prática parte 3: Codificando as regras de negócio

-> Codificando as regras de negócios

-> Executando os teste durante a codificação

->> Vamos agora codificar a classe calculadora

Curiosidades
```
 public int Somar(int num1, int num2)
        {
            int res = num1 + num2;
            listaHistorico.Insert(0, "Res: " + res);
            return res;
        }

listaHistorico.ADD()  --->> ADD sempre insere no final, por isso bom usar no começo da lista, utilizando insert(index, item)        

```

-->  Por ser um código simples podemos repetir, mas se tivesse algumas intruções a mais, cabia fazer um método a parte e mandar o valor para o parametro e lá dentro tratar a inserção do historico.

--> Sempre atentar as boas práticas.

#### Ajustando histórico, objetivo é trazer as 3 últimas chamadas.
```
 lista
    for(0 .. 3)          --> Uma maneira que poderia ser feito (rascunho) para trazer os 3 últimos, não
       [if] add lista        precisa dele completo.


   public List<string> historico()
    {    // precisa retornar os 3 primeiros
        
        listaHistorico.RemoveRange(3, listaHistorico.Count - 3);  -> Remover todo excesso da lista e deixar
                                                                     apenas os 3 primeiros lá dentro
        return new List<string>();
    }       
```
#### Analisando o código do histórico

--> Lembrando que a lista inicia na posição 0, e já que queremos os 3 primeiros (0, 1, 2). 

--> Da posição 3 para frente vamos excluir, até o tamanho da lista (listaHistorico.Count).

--> Lembrando que lá acima criamos as lógicas nas operações para adicionar a partir da posição 0 (listaHistorico.Insert(0, "Res: " + res));

--> Se estamos removendo a partir da posição 3, então os 3 primeiros não serão tirados, se passarmos 2 parametro (listaHistorico.Count) como 5 ele vai tentar tirar o 3 o 4 e o 5, e como ela não existe vai dar erro.

--> ou seja o total seria: quantos itens tem na lista - a quantidade que se quer deixar, no caso 3.


### Refatorando Teste

-> Mexer na instanciação da classe Calculadora.

-> Fazer método a parte para situações que precisa de muita lógica, assim tendo um método que vai sempre retornar já a instancia da classe.

Atualizada classe Calculadora com novo construtor
```
 private List<string> listaHistorico;
        private string data;

        public Calculadora(string data)
        {
            listaHistorico = new List<string>();
            this.data = data;         -->> this.data(de fora) usado para quando se tem nomes iguais, o de 
        }                                  fora é igual o de dentro.
```
