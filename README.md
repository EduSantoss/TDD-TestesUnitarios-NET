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

### Prática parte 1: Criando um novo projeto

-> Criar pasta NewTalents e nela criar dotnet new console

-> Criar pasta NewTalentsTest e nela criar dotnet new xunit

->> Tudo criado dentro do projeto de testes não pode ser usado dentro do projeto de código.

### Prática parte 2: Criando as funções da Calculadora

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
