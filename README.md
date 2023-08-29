# HETech
# Projeto de Site de Vendas em C#

Este é um projeto de site de vendas desenvolvido em C# que utiliza o ASP.NET Core e o Entity Framework Core. O projeto foi organizado em camadas para melhor modularidade e escalabilidade, consistindo em três principais camadas: HETech.API, HETechDomain e HETech.Infra. O projeto visa criar um sistema de compras online que permite aos usuários se cadastrar, fazer login, pesquisar produtos, efetuar compras e aos administradores gerenciar produtos e vendas.

## Estrutura em Camadas

O projeto foi dividido nas seguintes camadas:

- **HETech.API**: Esta camada é responsável por lidar com a interface de usuário e as solicitações HTTP. Aqui, as rotas, controladores e lógica relacionada à interação com o cliente são implementadas.

- **HETechDomain**: Nesta camada, a lógica de negócios e as entidades do domínio são definidas. Aqui, as regras de negócios do sistema são implementadas, bem como as classes que representam os objetos do mundo real.

- **HETech.Infra**: A camada de infraestrutura lida com os detalhes técnicos do armazenamento de dados e da comunicação com serviços externos. É nesta camada que o Entity Framework Core é configurado para interagir com o banco de dados.

## Funcionalidades Principais

- Cadastro e autenticação de usuários.
- Pesquisa e compra de produtos por usuários.
- Gerenciamento de produtos por administradores (cadastro, atualização e remoção).
- Registro de vendas e visualização de histórico de vendas.
- Autenticação JWT para proteger rotas e operações sensíveis.

## Dependências

O projeto utiliza as seguintes dependências:

- Microsoft.EntityFrameworkCore (7.0.4)
- Microsoft.EntityFrameworkCore.Design (7.0.4)
- Microsoft.EntityFrameworkCore.SqlServer (7.0.4)
- Microsoft.AspNetCore.Authentication.JwtBearer (6.0.15)
- Microsoft.EntityFrameworkCore.Tools (7.0.4)

## Configuração

1. Clone este repositório para o seu ambiente local.
2. Certifique-se de ter o .NET SDK instalado (versão compatível com as dependências acima).
3. No terminal, navegue até o diretório raiz do projeto.
4. Execute `dotnet restore` para restaurar as dependências.
5. Configure sua conexão com o banco de dados no arquivo `appsettings.json`.
6. Execute as migrações do Entity Framework Core com `dotnet ef database update`.
7. Execute o projeto com `dotnet run`.

## Contribuição

Contribuições são bem-vindas! Se você deseja contribuir com melhorias, correções de bugs ou novas funcionalidades, sinta-se à vontade para abrir uma pull request.

---

Para mais detalhes sobre como usar cada uma das dependências, consulte a documentação oficial de cada uma:

- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [JWT Authentication in ASP.NET Core](https://docs.microsoft.com/aspnet/core/security/authentication/jwt)

## Eliane Henriqueta
