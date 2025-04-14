# Feedback - Avaliação Geral

## Front End
### Navegação
  * Pontos positivos:
    - Possui views e rotas definidas no projeto SmartBuy.Gestao
    - Implementação com Razor Pages/Views

### Design
    - Será avaliado na entrega final

### Funcionalidade
  * Pontos positivos:
    - Interface web implementada com HTML/CSS

  * Pontos negativos:
    - Inconsistência entre a descrição (posts e comentários) e o propósito (e-commerce)
    - Não é possível verificar a completude das funcionalidades implementadas

## Back End
### Arquitetura
  * Pontos positivos:
    - Estrutura em camadas bem definida:
      * SmartBuy.Gestao (MVC)
      * SmartBuy.API
      * SmartBuy.Controller
      * SmartBuy.Model

  * Pontos negativos:
    - Arquitetura mais complexa que o necessário com 4 camadas distintas
    - Apenas uma camada centralizadora "Core" seria suficiente para atender API e MVC
    - Separação desnecessária entre Controller e Model
    - Recomendação: API e MVC deveriam ter suas próprias Controllers, a camada "Model" não faz papel de modelagem, está mais para uma camada de dados.

### Funcionalidade
  * Pontos positivos:
    - Implementação do ASP.NET Identity mencionada
    - Configuração de Seed de dados mencionada
    - Suporte a SQL Server/SQLite

### Modelagem
  * Pontos positivos:
    - Uso do Entity Framework Core
    - Entidades simples (como deveria ser)

## Projeto
### Organização
  * Pontos positivos:
    - Estrutura organizada com projetos separados
    - Arquivo solution (SmartBuy.sln) na raiz
    - .gitignore e .gitattributes adequados

  * Pontos negativos:
    - Falta da pasta src na raiz
    - Projetos diretamente na raiz do repositório

### Documentação
  * Pontos positivos:
    - README.md muito bem estruturado e detalhado com:
      * Apresentação do projeto
      * Tecnologias utilizadas
      * Estrutura do projeto
      * Instruções de execução
      * Uso de emojis para melhor visualização
    - Documentação da API via Swagger mencionada
    - Instruções claras de configuração

  * Pontos negativos:
    - Arquivo FEEDBACK.md mencionado mas não presente no repositório
    - Inconsistência na documentação entre e-commerce e sistema de posts/comentários

### Instalação
  * Pontos positivos:
    - Instruções detalhadas de instalação no README
    - Migrations automáticas mencionadas

  * Pontos negativos:
    - Seed de dados não implementado (configurado mas sem dados)