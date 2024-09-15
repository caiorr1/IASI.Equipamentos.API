
# IASI Equipamentos API

Este projeto é uma API de gerenciamento de equipamentos desenvolvida para o sistema IASI (Inteligência Artificial para Sustentabilidade Industrial). A API permite criar, ler, atualizar e deletar informações sobre equipamentos, consumos, manutenções, previsões e resíduos, integrando-os a um banco de dados Oracle.

## Integrantes do Grupo

- Caio Ribeiro Rodrigues - RM: 99759
- Guilherme Riofrio Quaglio - RM: 550137
- Elen Cabral - RM: 98790
- Mary Speranzini - RM: 550242
- Eduardo Jablinski - RM: 550975 

## Sumário

- [Requisitos](#requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Migrações do Banco de Dados](#migrações-do-banco-de-dados)
- [Executando a API](#executando-a-api)
- [Uso da API](#uso-da-api)
  - [Endpoints Disponíveis](#endpoints-disponíveis)
- [Documentação da API](#documentação-da-api)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Oracle Database](https://www.oracle.com/database/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [Oracle Data Provider for .NET (ODP.NET)](https://www.oracle.com/database/technologies/dotnet-odacdeploy-downloads.html)

## Instalação

1. Clone o repositório para sua máquina local:

   ```bash
   git clone https://github.com/seuusuario/IASI.Equipamentos.API.git
   cd IASI.Equipamentos.API
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
   dotnet run --project IASI.Equipamentos.API
   ```

2. A API estará disponível em `https://localhost:{porta}`, onde `{porta}` é o número da porta configurado.

## Uso da API

### Endpoints Disponíveis

#### **Equipamentos**

- **`GET /api/equipamento`**: Lista todos os equipamentos.
- **`GET /api/equipamento/{id}`**: Obtém um equipamento por ID.
- **`POST /api/equipamento`**: Cria um novo equipamento.
- **`PUT /api/equipamento/{id}`**: Atualiza um equipamento existente.
- **`DELETE /api/equipamento/{id}`**: Remove um equipamento.

#### **Consumo**

- **`GET /api/consumo`**: Lista todos os consumos.
- **`GET /api/consumo/{id}`**: Obtém um consumo por ID.
- **`POST /api/consumo`**: Cria um novo consumo.
- **`PUT /api/consumo/{id}`**: Atualiza um consumo existente.
- **`DELETE /api/consumo/{id}`**: Remove um consumo.

#### **Outros Endpoints:**

- **Manutenção**: `/api/manutencao`
- **Previsões**: `/api/previsao`
- **Resíduos**: `/api/residuo`

### Exemplo de Requisição para Criar um Equipamento

```json
POST /api/equipamento
{
  "nomeEquipamento": "Gerador Solar",
  "tipoEquipamento": "Solar",
  "localizacaoEquipamento": "Fábrica A",
  "dataInstalacaoEquipamento": "2024-09-13T00:00:00",
  "estadoEquipamento": "Operacional"
}
```

### Exemplo de Requisição para Criar um Consumo

```json
POST /api/consumo
{
  "idEquipamento": 1,
  "dataConsumo": "2024-09-13T23:51:34.668Z",
  "quantidadeConsumo": 100.5,
  "tipoEnergiaConsumo": "Elétrica",
  "emissaoGasConsumo": 15.2
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
