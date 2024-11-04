
# IASI Equipamentos API

Este projeto é uma API de gerenciamento de equipamentos e previsões de manutenção, parte do sistema IASI (Inteligência Artificial para Sustentabilidade Industrial). Além de gerenciar dados de equipamentos, a API possui integração com uma API externa de emissões de carbono e funcionalidades de previsão de manutenção utilizando ML.NET.

## Integrantes do Grupo

- Caio Ribeiro Rodrigues - RM: 99759
- Guilherme Riofrio Quaglio - RM: 550137
- Elen Cabral - RM: 98790
- Mary Speranzini - RM: 550242
- Eduardo Jablinski - RM: 550975 

## Arquitetura

A API utiliza a **Onion Architecture**, que promove a separação entre as camadas Domain, Application, Infrastructure e Presentation. Essa arquitetura facilita a injeção de dependências, a manutenibilidade e o teste unitário.

### Padrões de Projeto Utilizados

- **Repository Pattern**: Para abstrair o acesso aos dados.
- **Service Pattern**: Para encapsular a lógica de negócio.
- **Dependency Injection**: Para inversão de controle, facilitando testes e manutenção.

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet) para previsão de manutenção
- [Oracle Database](https://www.oracle.com/database/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- Pacotes NuGet: `Microsoft.Extensions.DependencyInjection`, `ML.NET`, `Newtonsoft.Json`, `Swashbuckle.AspNetCore`

## Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/IASI.Equipamentos.API.git
   cd IASI.Equipamentos.API
   ```

2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

3. Configure a string de conexão com o Oracle em **appsettings.json**.

## Estrutura de Pastas

- **Controllers**: Contém os controladores da API.
- **Data**: Armazena o arquivo CSV para treinar o modelo de manutenção.
- **Services**: Implementa a lógica de negócio e previsão.

## Endpoints

### **Equipamento**

- **GET /api/equipamento**: Retorna todos os equipamentos.
- **GET /api/equipamento/{id}**: Retorna um equipamento específico por ID.
- **POST /api/equipamento**: Cria um novo equipamento.
- **PUT /api/equipamento/{id}**: Atualiza os dados de um equipamento.
- **DELETE /api/equipamento/{id}**: Remove um equipamento.

### **Manutenção**

- **GET /api/manutencao**: Retorna todos os registros de manutenção.
- **POST /api/manutencao**: Adiciona um novo registro de manutenção.

### **Recomendação (ML.NET)**

- **POST /api/recomendacao/treinar-modelo**: Treina o modelo de previsão de manutenção com o CSV.
- **POST /api/recomendacao/prever-manutencao**: Realiza uma previsão de manutenção com base nos dados fornecidos.

  **Exemplo de JSON para previsão**:
  ```json
  {
    "equipmentAge": 5,
    "lastMaintenance": 2,
    "equipmentType": "Pump",
    "maintenanceNeeded": false
  }
  ```

### **API Externa de Emissões de Carbono**

- **POST /api/carbon/calculate-electricity-emissions**: Calcula as emissões de carbono de acordo com o consumo elétrico.

  **Exemplo de JSON**:
  ```json
  {
    "electricityUnit": "kWh",
    "electricityValue": 500,
    "country": "us",
    "state": "ny"
  }
  ```

## Testes

O projeto inclui testes unitários para os principais serviços e controladores, cobrindo cenários como:

- **CarbonServiceTests**: Testa a integração com a API externa de emissões de carbono.
- **EquipamentoControllerTests**: Valida as operações CRUD para equipamentos.
- **RecomendacaoControllerTests**: Testa a funcionalidade de previsão e treinamento com ML.NET.

Para rodar os testes, utilize o seguinte comando:
```bash
dotnet test
```

## Documentação Swagger

A documentação detalhada da API está disponível em `/swagger`.

## Contribuição

1. Faça um Fork.
2. Crie uma branch (`git checkout -b feature/NovaFeature`).
3. Commit suas alterações (`git commit -m 'Adiciona nova feature'`).
4. Push para a branch (`git push origin feature/NovaFeature`).
5. Abra um Pull Request.

## Licença

Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais informações.
