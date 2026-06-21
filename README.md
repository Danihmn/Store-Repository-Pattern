# Store API

API desenvolvida para praticar **Arquitetura Limpa** e o **padrão Repository** com ASP.NET Core Minimal API.

## Objetivo

Projeto de estudo focado em dois conceitos:

- **Arquitetura Limpa** — separação de responsabilidades em camadas independentes, onde as regras de negócio não dependem de frameworks ou infraestrutura.
- **Padrão Repository** — abstração do acesso a dados via interfaces definidas no domínio e implementadas na infraestrutura.

## Estrutura das Camadas

```
Store.Domain          # Entidades, interfaces de repositório e abstrações
Store.Application     # Casos de uso (handlers MediatR)
Store.Infrastructure  # Implementações de repositório, EF Core, mapeamentos
Store.Api             # Endpoints Minimal API, configuração da aplicação
```

### Domain

Camada central, sem dependências externas.

- **Entidades:** `Cliente`, `Endereco`, `Loja`, `Pedido`, `Produto`, `ProdutoPedido`
- **Classe base:** `Entity` com `Id` (Guid), `CriadoEm` e `AtualizadoEm`
- **Interfaces de repositório:** `IRepository<T>` genérica + interfaces específicas por entidade
- **Result pattern:** `Result` e `Result<T>` para encapsular sucesso/falha sem lançar exceções
- **Error:** representa erros de domínio retornados via `Result`

### Application

Orquestra os casos de uso com **MediatR**.

Cada operação segue a estrutura:

```
UseCases/{Entidade}/{Operação}/
    Command.cs   # IRequest com os dados de entrada
    Response.cs  # DTO de saída
    Handler.cs   # Lógica da operação, depende apenas de IRepository
```

Operações disponíveis: `Create`, `GetAll`, `GetById`, `Update`, `Delete` para todas as entidades.

### Infrastructure

- **EF Core + PostgreSQL** via Npgsql
- **`StoreContext`** com `DbSet` para cada entidade
- **Mappings** com `IEntityTypeConfiguration<T>` para cada entidade
- **Implementações dos repositórios** registradas como `Transient` no container de DI

### Api

- **Minimal API** com endpoints agrupados por entidade (`MapGroup`)
- **OpenAPI** gerado nativamente pelo ASP.NET Core
- **Scalar** como interface para explorar e testar a API em `/scalar`

## Tecnologias

| Tecnologia | Uso |
|---|---|
| .NET 10 | Runtime |
| ASP.NET Core Minimal API | Camada HTTP |
| Entity Framework Core | ORM |
| Npgsql | Driver PostgreSQL |
| MediatR | Mediador para handlers de casos de uso |
| Scalar | Interface OpenAPI |

## Configuração

Requer uma string de conexão PostgreSQL em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=...;Database=...;Username=...;Password=..."
  }
}
```
