# concessionaria-minimal-api
 Neste LAB, vamos criar uma API utilizando a técnica de Minimals APIs para o registro de veículos, ampliando suas funcionalidades ao incorporar administradores. Ao explorarmos o funcionamento da API, nos familiarizaremos com o uso do Swagger, além de trabalharmos com testes, garantindo a robustez e confiabilidade do sistema que estaremos desenvolvendo.

## Requesitos

    C#
    .Net Runtime e SDK
    IDE de sua escolha

## Execução dos testes unitários

    dotnet test --settings .runsettings

## Estrutura do código

        concessionaria-minimal-api/
        └── Test/
            ├── Services/                # Testes unitários relacionados aos serviços
            │   ├── UserServicesTest.cs  # Testes unitários para funcionalidades de usuários
            │   └── CarServicesTest.cs       # Testes unitários para funcionalidades da concessionária
            │
            ├── .runsettings             # Configuração que desabilita execução paralela dos testes
            └── readme.md                # Documentação do projeto de testes

## Contribuições

Luiz Augusto - [Louiexz]
