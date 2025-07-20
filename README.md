# Person API

## 1. Visão Geral do Projeto

**Nome do Projeto:** Person API

**Descrição:** API RESTful para cadastro, consulta, atualização e remoção de pessoas utilizando C# e SQLite.

**Tecnologias Utilizadas:**

- C# (.NET 9)
- ASP.NET Core
- Entity Framework Core (SQLite)
- OpenAPI (Swagger)

## 2. Configuração e Instalação

**Pré-requisitos:**

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Git

**Instalação:**

```sh
git clone https://github.com/seu-usuario/seu-repo.git
cd Person
dotnet restore
```

## 3. Executando o Projeto

```sh
dotnet run
```

A API estará disponível em: `https://localhost:5212` (ou porta definida pelo .NET).

## 4. Estrutura do Projeto

- `Data/PersonContext.cs`: Contexto do Entity Framework para acesso ao banco SQLite.
- `Models/PersonModel.cs`: Modelo de dados da pessoa.
- `Routes/PersonRoute.cs`: Definição das rotas/endpoints da API.
- `Routes/PersonRequest.cs`: Modelo para requisições de criação/atualização.
- `Migrations/`: Arquivos de migração do banco de dados.

## 5. API Endpoints

### Criar Pessoa

- **URL:** `/person`
- **Método:** POST
- **Descrição:** Cria uma nova pessoa.
- **Body Parameters:**
  ```json
  {
    "name": "João"
  }
  ```
- **Respostas:**
  - `200 OK` - Pessoa criada com sucesso.
- **Exemplo:**
  ```sh
  curl -X POST https://localhost:5001/person -H "Content-Type: application/json" -d '{"name":"João"}'
  ```

---

### Listar Pessoas

- **URL:** `/person`
- **Método:** GET
- **Descrição:** Retorna todas as pessoas cadastradas.
- **Respostas:**
  - `200 OK`
    ```json
    [
      {
        "id": "guid",
        "name": "João"
      }
    ]
    ```
- **Exemplo:**
  ```sh
  curl https://localhost:5001/person
  ```

---

### Atualizar Pessoa

- **URL:** `/person/{id}`
- **Método:** PUT
- **Descrição:** Atualiza o nome de uma pessoa pelo ID.
- **Body Parameters:**
  ```json
  {
    "name": "Maria"
  }
  ```
- **Respostas:**
  - `200 OK` - Usuário atualizado com sucesso.
  - `404 Not Found` - Pessoa não encontrada.
- **Exemplo:**
  ```sh
  curl -X PUT https://localhost:5001/person/{id} -H "Content-Type: application/json" -d '{"name":"Maria"}'
  ```

---

### Remover Pessoa

- **URL:** `/person/{id}`
- **Método:** DELETE
- **Descrição:** Remove uma pessoa pelo ID.
- **Respostas:**
  - `200 OK` - Usuário removido com sucesso.
  - `404 Not Found` - Pessoa não encontrada.
- **Exemplo:**
  ```sh
  curl -X DELETE https://localhost:5001/person/{id}
  ```

---

## Observações

- O banco de dados utilizado é o arquivo `Person.sqlite` na raiz do projeto.
- Para aplicar migrações, utilize: `dotnet ef database`
