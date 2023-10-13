# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased


## 1.1.1 - 2023-10-13
### Boleto
#### Add
- Id: buscar o boleto por id
#### Fix
- Se o Get estiver sendo buscado após a data de vencimento, calcular o Valor do Boleto com o Juros do Banco em questão.
Não precisa calcular por dias, somente o juros total após “vencido”.
- [PostgresException: 42703](https://github.com/sswellington/meuBoleto/tree/8876fd81674284d778ec063a051b832b9e9fa339)
- [PostgresException: 42P01](https://github.com/sswellington/meuBoleto/tree/8876fd81674284d778ec063a051b832b9e9fa339) 


## 1.0.0 - 2023-10-12
### Added
- [Clean architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

### Banco
#### Add
- Todos: Fazer uma busca de TODOS os registros banco/
- Id: Fazer a busca de um único registro passando o Código do Banco como filtro banco/{id}
- Cadastro via POST para a entidade Banco, com as seguintes properties:
    - Id (Obrigatório)
    - Nome do Banco (Obrigatório)
    - Código do Banco (Obrigatório)
    - Percentual de Juros (Obrigatório)

### Boleto
#### Add 
- Se o Get estiver sendo buscado após a data de vencimento, calcular o Valor do Boleto com o Juros do Banco em questão.
Não precisa calcular por dias, somente o juros total após “vencido”.
