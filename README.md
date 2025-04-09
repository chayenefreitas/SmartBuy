SmartBuy - Aplicação de e-commerce Simples com MVC e API RESTful
1. Apresentação
Bem-vindo ao repositório do projeto SmartBuy. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo Introdução ao Desenvolvimento ASP.NET Core. O objetivo principal desenvolver uma aplicação de e-commerce que permite aos usuários criar, editar, visualizar e excluir posts e comentários, tanto através de uma interface web utilizando MVC quanto através de uma API RESTful. Descreva livremente mais detalhes do seu projeto aqui.
Autor(es)
•	Chayene Freitas
2. Proposta do Projeto
O projeto consiste em:
•	Aplicação MVC: Interface web para interação com o e-commerce.
•	API RESTful: Exposição dos recursos do e-commerce para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
•	Autenticação e Autorização: Implementação de controle de acesso, diferenciando administradores e usuários comuns.
•	Acesso a Dados: Implementação de acesso ao banco de dados através de ORM.
3. Tecnologias Utilizadas
•	Linguagem de Programação: C#
•	Frameworks:
o	ASP.NET Core MVC
o	ASP.NET Core Web API
o	Entity Framework Core
•	Banco de Dados: SQL Server
•	Autenticação e Autorização:
o	ASP.NET Core Identity
o	JWT (JSON Web Token) para autenticação na API
•	Front-end:
o	Razor Pages/Views
o	HTML/CSS para estilização básica
•	Documentação da API: Swagger
4. Estrutura do Projeto
A estrutura do projeto é organizada da seguinte forma:
•	SmartBuy/
o	SmartBuy.Gestao/ - Projeto Web
o	SmartBuy.Api/ - API RESTful
o	SmartBuy.Controller
o	SmartBuy.Model
•	README.md - Arquivo de Documentação do Projeto
•	FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
•	.gitignore - Arquivo de Ignoração do Git
5. Funcionalidades Implementadas
•	CRUD para Posts e Comentários: Permite criar, editar, visualizar e excluir posts e comentários.
•	Autenticação e Autorização: Diferenciação entre usuários comuns e administradores.
•	API RESTful: Exposição de endpoints para operações CRUD via API.
•	Documentação da API: Documentação automática dos endpoints da API utilizando Swagger.
6. Como Executar o Projeto
Pré-requisitos
•	.NET SDK 8.0 ou superior
•	SQL Server/Sqlite
•	Visual Studio 2022 
•	Git
Passos para Execução
1.	Clone o Repositório:
o	git clone https://github.com/chayenefreitas/SmartBuy.git
o	cd smartbuy
2.	Configuração do Banco de Dados:
o	No arquivo appsettings.json, configure a string de conexão do SQL Server.
o	Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos
3.	Executar a Aplicação MVC:
o	cd SmartBuy/SmartBuy.Gestao/
o	dotnet run
o	Acesse a aplicação em: http://localhost:5000
4.	Executar a API:
o	cd SmartBuy / SmartBuy.Api/
o	dotnet run
o	Acesse a documentação da API em: http://localhost:5001/swagger
7. Instruções de Configuração
•	JWT para API: As chaves de configuração do JWT estão no appsettings.json.
•	Migrações do Banco de Dados: As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.
8. Documentação da API
A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:
http://localhost:5001/swagger
9. Avaliação
•	Este projeto é parte de um curso acadêmico e não aceita contribuições externas.
•	Para feedbacks ou dúvidas utilize o recurso de Issues
•	O arquivo FEEDBACK.md é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
