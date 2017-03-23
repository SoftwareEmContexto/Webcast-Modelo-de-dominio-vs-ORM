# Webcast: Modelo de domínio vs ORM - Como lidar com a complexidade acidental no seu domínio.

O objetivo desta demo é fazer um comparativo de um modelo de domínio puro com modelos de domínio que fazem uso de ORM.

Demo utilizada no webcast realizado no dia 13/03. Disponivel no link: https://www.youtube.com/watch?v=kRaxFb-rS_c

## Preparando o ambiente.

Antes de rodar a demo, execute o script que está na pasta "Scripts" na raiz do projeto.

A connectionString utilizada é: "Server=(LocalDb)\MSSQLLocalDB;Database=SeuCarroNaVitrine;Trusted_Connection=True;". Ela está 
definida nos arquivos:

- MeuCarroNaVitrineContext.cs
- RepositorioBase.cs
- AnuncianteRepositorioSQL.cs
- AnuncioRepositorioSQL.cs


## Sobre a DEMO

Está temo possui a seguinte estrutura:

 - Um Modelo de domínio puro
 - Um Modelo de domínio utilizando o Entity Framework
 - Um Modelo de domínio utilizando o NHibernate
 
 A demo faz uso dos seguintes conceitos:
 - Entidade
 - Objeto de valor
 - Repositorio
 - Agregação
 
