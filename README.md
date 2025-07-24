# concessionaria-minimal-api
 Neste LAB, vamos criar uma API utilizando a técnica de Minimals APIs para o registro de veículos, ampliando suas funcionalidades ao incorporar administradores. Ao explorarmos o funcionamento da API, nos familiarizaremos com o uso do Swagger, além de trabalharmos com testes, garantindo a robustez e confiabilidade do sistema que estaremos desenvolvendo.

## Requesitos

    C#
    .Net Runtime e SDK
    IDE de sua escolha

## Execução

    dotnet run

## Endpoints

### Auth

    /user/login - POST
    /user/logout - POST

### User

    /user/get/all - GET
    /user/get/:id - GET
    /user/create/:email/:password - POST
    /user/update/:id/:email/:password - PUT
    /user/update/:id - PATCH
    /user/delete/:id - DELETE

### Vehicle

    /vehicle/get/all - GET
    /vehicle/get/:id - GET
    /vehicle/create/:type/:mark/:model/:year - POST
    /vehicle/update/:id/:type/:mark/:model/:year - PUT
    /vehicle/update/:id - PATCH
    /vehicle/delete/:id - DELETE

## Estrutura

        concessionaria-minimal-api/
        └── Test/
            ├── Services/            # Testes unitários relacionados aos serviços
            │   ├── UserServices.cs      # Testes unitários para funcionalidades de usuários
            │   └── CarServices.cs       # Testes unitários para funcionalidades da concessionária
            │
            ├── Controller/
            │   ├── UserController.cs    # Interação entre usuário e serviço para funcionalidades de usuários
            │   └── CarController.cs     # Interação entre usuário e serviço para funcionalidades da concessionária
            │
            ├── Model/
            │   ├── Car.cs               # Modelo de representação de veículo
            │   ├── User.cs              # Modelo de representação de pessoa
            │   └── UserSession.cs       # Modelo de representação de autenticação
            │
            ├── .runsettings         # Configuração que desabilita execução paralela dos testes
            └── readme.md            $ Documentação do projeto de testes


## Contribuições

Luiz Augusto - [Louiexz]
