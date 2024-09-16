
# IASI Empresas API

Este projeto é uma API de gerenciamento de empresas e relatórios desenvolvida para o sistema IASI (Inteligência Artificial para Sustentabilidade Industrial). A API permite criar, ler, atualizar e deletar informações sobre empresas, contatos, documentos, relatórios, tipos de relatórios, setores e usuários, integrando-os a um banco de dados Oracle.

## Integrantes do Grupo

- Caio Ribeiro Rodrigues - RM: 99759
- Guilherme Riofrio Quaglio - RM: 550137
- Elen Cabral - RM: 98790
- Mary Speranzini - RM: 550242
- Eduardo Jablinski - RM: 550975 

## Arquitetura

A API utiliza a **Onion Architecture**, que promove uma separação clara entre as diferentes camadas da aplicação: Domain, Application, Infrastructure e Presentation. Essa arquitetura facilita a manutenção e evolução do software, bem como a injeção de dependências e o teste de unidades.

### Design Patterns Utilizados

- **Repository Pattern**: Para abstrair o acesso aos dados, facilitando a manutenção e testes.
- **Service Pattern**: Para encapsular a lógica de negócio e permitir reutilização de código.
- **Dependency Injection**: Para promover a inversão de controle e facilitar o teste e a manutenção.

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Oracle Database](https://www.oracle.com/database/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [Oracle Data Provider for .NET (ODP.NET)](https://www.oracle.com/database/technologies/dotnet-odacdeploy-downloads.html)

## Instalação

1. Clone o repositório para sua máquina local:
   ```bash
   git clone https://github.com/seuusuario/IASI.Empresas.API.git
   cd IASI.Empresas.API
   ```

2. Abra o projeto no **Visual Studio** ou **Visual Studio Code**.

3. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

## Configuração

1. No arquivo **`appsettings.json`**, configure a string de conexão com o banco de dados Oracle:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)))"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```
   Substitua `seu_usuario` e `sua_senha` pelas credenciais do seu banco de dados.

## Migrações do Banco de Dados

1. Abra o **Package Manager Console** no Visual Studio (**Tools > NuGet Package Manager > Package Manager Console**).

2. Crie as migrações:
   ```powershell
   Add-Migration InitialMigration
   ```

3. Aplique as migrações ao banco de dados:
   ```powershell
   Update-Database
   ```

## Executando a API

1. Compile e execute o projeto:
   - No **Visual Studio**, pressione **F5**.
   - No **Visual Studio Code**, use o comando:
   ```bash
   dotnet run --project IASI.Empresas.API
   ```

2. A API estará disponível em `https://localhost:{porta}`, onde `{porta}` é o número da porta configurado.

## Uso da API

### Endpoints Disponíveis

#### **Empresas**
- **`GET /api/empresa`**: Lista todas as empresas.
- **`GET /api/empresa/{id}`**: Obtém uma empresa por ID.
- **`POST /api/empresa`**: Cria uma nova empresa.
- **`PUT /api/empresa/{id}`**: Atualiza uma empresa existente.
- **`DELETE /api/empresa/{id}`**: Remove uma empresa.

#### **Contatos**
- **`GET /api/contato`**: Lista todos os contatos.
- **`GET /api/contato/{id}`**: Obtém um contato por ID.
- **`POST /api/contato`**: Cria um novo contato.
- **`PUT /api/contato/{id}`**: Atualiza um contato existente.
- **`DELETE /api/contato/{id}`**: Remove um contato.

#### **Documentos**
- **`GET /api/documento`**: Lista todos os documentos.
- **`GET /api/documento/{id}`**: Obtém um documento por ID.
- **`POST /api/documento`**: Cria um novo documento.
- **`PUT /api/documento/{id}`**: Atualiza um documento existente.
- **`DELETE /api/documento/{id}`**: Remove um documento.

#### **Relatórios**
- **`GET /api/relatorio`**: Lista todos os relatórios.
- **`GET /api/relatorio/{id}`**: Obtém um relatório por ID.
- **`POST /api/relatorio`**: Cria um novo relatório.
- **`PUT /api/relatorio/{id}`**: Atualiza um relatório existente.
- **`DELETE /api/relatorio/{id}`**: Remove um relatório.

#### **Outros Endpoints:**
- **Tipos de Relatório**: `/api/relatoriotipo`
- **Setores**: `/api/setor`
- **Usuários**: `/api/usuario`

### Exemplo de Requisição para Criar uma Empresa
```json
POST /api/empresa
{
  "nomeEmpresa": "Empresa XYZ",
  "setorIndustrialEmpresa": "Tecnologia",
  "localizacaoEmpresa": "São Paulo, SP",
  "tipoEmpresa": "Privada",
  "conformidadeRegulamentar": "S"
}
```

## Documentação da API

A documentação da API está disponível via Swagger em:

```
https://localhost:{porta}/swagger
```

## Contribuição

1. Faça um Fork do projeto.
2. Crie uma branch para a sua feature (`git checkout -b feature/NovaFeature`).
3. Faça o Commit das suas alterações (`git commit -m 'Adiciona nova feature'`).
4. Faça um Push para a branch (`git push origin feature/NovaFeature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob os termos da licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
