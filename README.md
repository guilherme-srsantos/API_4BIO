
# Teste Prático 4BIO
API baseada em C#/.NET 6 para manipulação de um conjunto de clientes.

## Tecnologias utilizadas


- ASP.NET Core; 
- Entity Framework Core;
- FastEndpoints: estruturação de _endpoints_ e modelos de resposta/requisição;
- Swagger: documentação de _endpoints_;
- FluentValidator: validação de requisições;
- Bogus: _mocking_ de dados.


## Uso/Exemplos

Popular a base de dados _in memory_ da aplicação é possível através de uma chamada GET para o _endpoint_
    `/clientes/gerarclientes/X` 
onde X é quantidade de clientes que a biblioteca de _mocking_ irá gerar para popular a aplicação.

Alternativamente, também é possível importar um conjunto de clientes representados em um arquivo `.json` através de uma chamada POST para o _endpoint_ `/clients/importar`.

Para fins de demonstração e teste, esse repositório contém um arquivo `clientes.json` que pode ser utilizado no _endpoint_ de importação de clientes.

A descrição de uso dos _endpoints_ está presente na aplicação em uma página do Swagger, que é automaticamente carregada quando o projeto é executado.


## Autores

- [@guilherme-srsantos](https://www.github.com/guilherme-srsantos)
