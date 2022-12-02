# BookPublisher

Comandos:
Criar imagem da base de dados sql server:
docker run --name "Ooo" -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=H0ra_de_aventura" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

Build o docker do projeto API
docker build -f BookPublisher.API/Dockerfile -t bookpublisher/api .

docker run --name "bookpublisher_api" -p 8080:4001 -t bookpublisher/api
