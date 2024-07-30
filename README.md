# Web-API

# UserAPI

UserAPI é uma aplicação de API Web construída usando ASP.NET Core 8 e PostgreSQL. Esta API permite gerenciar usuários com operações CRUD (Create, Read, Update, Delete).

## Recursos

- Criação de usuários
- Leitura de informações de usuários
- Atualização de informações de usuários
- Exclusão de usuários

## Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger para documentação da API

## Instalação

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Passos

### 1. Clone o repositório

```bash
git clone https://github.com/Tiallysson/Web-API.git
cd Web-API
```
### 2. Configure a conexão com o banco de dados PostgreSQL no arquivo `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=seu_database;Username=seu_usuario;Password=sua_senha"
  }
}
```

### 3. Adicione as migrações e atualize o banco de dados
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Execute a aplicação
```bash
dotnet run
```
## Uso
Após iniciar a aplicação, a documentação Swagger estará disponível em:

```bash
http://localhost:5000/swagger
```
## Exemplos de Requisições
#### Criar Usuário

- Endpoint: POST `/api/user`
- Corpo da Requisição:

```json
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "password": "YourSecurePassword"
}
```

- Resposta de Sucesso:

```json
{
    "id": 1,
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "password": "YourSecurePassword"
}
```
## Contribuição
Contribuições são bem-vindas! Por favor, envie um pull request ou abra uma issue para discutir o que você gostaria de mudar.

## Licença
Esta API está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## Versão
### `v1.0.0`
Primeira versão da API com operações CRUD básicas para gerenciamento de usuários.
