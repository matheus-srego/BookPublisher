#!/bin/bash

echo "listando containers.."
docker container -a

echo "parando container.."
docker container stop bookpublisher_api

echo "removendo container.."
docker container rm bookpublisher_api

echo "listando imagens.."
docker image list

echo "removendo imagem.."
docker image rmi bookpublisher/api

ls

cd BookPublisher

echo "criando imagem.."
docker build -f BookPublisher.API/Dockerfile -t bookpublisher/api .

echo "criando container.."
docker run --name "bookpublisher_api" -p 8080:4001 -t bookpublisher/api
