# Troca de Talentos
 Projeto de fabrica de software;
 
## Aplicação Web ASP .Net Core, api da aplicação troca de talentos.
 
### Tecnologias utilizadas:
- .Net Cores 3.1
    > NET Core é um framework livre e de código aberto para os sistemas operacionais Windows, Linux e macOS. É um sucessor de código aberto do .NET Framework. O projeto é desenvolvido principalmente pela Microsoft e lançado com a Licença MIT.
- NUnit (.NET Core)
    > O NUnit é um dos frameworks para realização de testes unitários em .NET.
- Swagger (Swashbuckle.AspNetCore)
    > Swagger é uma linguagem de descrição de interface para descrever APIs RESTful expressas usando JSON. O Swagger é usado junto com um conjunto de ferramentas de software de código aberto para projetar, construir, documentar e usar serviços da Web RESTful.

### Requisitos para a compilação do projeto:
- Instalação .Net Core 3.1 SDK.
    > https://dotnet.microsoft.com/download 
- Instalação IDE visual studio.
    > https://code.visualstudio.com/download

### Instruções para a execução do projeto:
- Abrir a IDE do Visual Studio.
- Executar o projeto através <Vários Projetos de Inicialização>(já configurado).
- Pagina inicial da aplicação será aberta no seu navegador padrão, com a documentação Swagger.

### Instruções para a execução migrations:
- Ter instalado PostgreSQL na máquina;
- Navegar via terminal até a pasta `Utfpr.Troca.De.Talentos.Infrastructure.Migrations`;
- Executar o comando `dotnet ef database update --context DataBaseMigrationsDbContext`;
