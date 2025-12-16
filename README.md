# 🧾 Controle de Estoque

Projeto **em andamento** de uma **API RESTful** desenvolvida em **.NET Core**, com foco em boas práticas de arquitetura, organização de código e manutenibilidade.

O objetivo do projeto é realizar o **gerenciamento de estoque**, permitindo o cadastro, atualização, consulta e controle de produtos e categorias, servindo como base para aplicações maiores e escaláveis.

---

## 🚀 Visão Geral

Esta API foi construída seguindo princípios de **Domain-Driven Design (DDD)**, separando responsabilidades entre camadas e facilitando a evolução do sistema.

A aplicação utiliza o **Entity Framework Core** como ORM para persistência de dados e o **SQLite** como banco de dados, tornando o projeto leve, simples de executar e ideal para estudos, testes e portfólio.

---

## 🛠️ Tecnologias Utilizadas

* **.NET Core** – Framework principal da aplicação
* **ASP.NET Core Web API** – Construção da API RESTful
* **Entity Framework Core** – Mapeamento objeto-relacional (ORM)
* **SQLite** – Banco de dados leve, local e embarcado
* **DDD (Domain-Driven Design)** – Organização e modelagem do domínio
* **Repository Pattern** – Abstração do acesso a dados
* **DTOs** – Transferência segura e controlada de dados

---

## 📂 Estrutura do Projeto

A estrutura do projeto foi pensada para manter clareza, organização e escalabilidade:

* **Domain** – Entidades, regras de negócio e contratos
* **Application** – DTOs, serviços e casos de uso
* **Infrastructure** – Contexto do banco de dados e repositórios
* **API** – Controllers e endpoints

---

## 🔧 Funcionalidades

* Cadastro de produtos
* Atualização de produtos
* Listagem de produtos
* Gerenciamento de categorias
* Persistência de dados com Entity Framework

> ⚠️ Novas funcionalidades estão sendo adicionadas continuamente.

---

## ▶️ Como Executar o Projeto

### 📦 Banco de Dados

Este projeto utiliza **SQLite**, com o arquivo de banco de dados armazenado localmente no projeto:

```
ControleDeEstoque.API/estoque.db
```

1. Clone o repositório:

   ```bash
   git clone https://github.com/GiovannaRb/ControleDeEstoque.git
   ```

2. Acesse a pasta do projeto:

3. Restaure os pacotes:

   ```bash
   dotnet restore
   ```

4. Execute a aplicação:

   ```bash
   dotnet run
   ```
   ```bash
   Obs: O Swagger já está devidamente configurado para abrir logo após o projeto ser iniciado no navegador! 
   ```
---

## 📌 Status do Projeto

🚧 **Em desenvolvimento**

---
