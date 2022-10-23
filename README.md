# BookPublisher

Comandos:
Criar imagem da base de dados sql server:
docker run --name "Ooo" -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=H0ra_de_aventura" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

Build o docker do projeto API
docker build -t bookpublisher_api . -f BookPublisher.API\Dockerfile