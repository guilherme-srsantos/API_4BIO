
# Teste Pr�tico 4BIO
API baseada em C#/.NET 6 para manipula��o de um conjunto de clientes.

## Tecnologias utilizadas


- ASP.NET Core; 
- Entity Framework Core;
- FastEndpoints: estrutura��o de _endpoints_ e modelos de resposta/requisi��o;
- Swagger: documenta��o de _endpoints_;
- FluentValidator: valida��o de requisi��es;
- Bogus: _mocking_ de dados.


## Uso/Exemplos

Popular a base de dados _in memory_ da aplica��o � poss�vel atrav�s de uma chamada GET para o _endpoint_
    `/clientes/gerarclientes/X` 
onde X � quantidade de clientes que a biblioteca de _mocking_ ir� gerar para popular a aplica��o.

Alternativamente, tamb�m � poss�vel importar um conjunto de clientes representados em um arquivo `.json` atrav�s de uma chamada POST para o _endpoint_ `/clients/importar`.

Para fins de demonstra��o e teste, esse reposit�rio cont�m um arquivo `clientes.json` que pode ser utilizado no _endpoint_ de importa��o de clientes.

A descri��o de uso dos _endpoints_ est� presente na aplica��o em uma p�gina do Swagger, que � automaticamente carregada quando o projeto � executado.


## Autores

- [@guilherme-srsantos](https://www.github.com/guilherme-srsantos)
