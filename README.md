# Loja do Seu Manoel

[![Build Status](https://github.com/louresb/LojaSeuManoel/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/louresb/LojaSeuManoel/actions/workflows/build-and-test.yml)
![Status](https://img.shields.io/badge/status-concluded-brightgreen)

Desafio técnico .NET que propõe a criação de uma API para automatizar o empacotamento de pedidos em uma loja online. A aplicação recebe pedidos com produtos e suas dimensões, e retorna quais caixas devem ser utilizadas e como os produtos devem ser distribuídos nelas, buscando otimização de espaço.

---

## 📝 Descrição do Problema

A API recebe, via JSON, uma lista de pedidos. Cada pedido contém produtos com altura, largura e comprimento. A lógica de empacotamento determina, para cada pedido, a melhor combinação de caixas disponíveis, buscando minimizar a quantidade de caixas utilizadas.

### Caixas disponíveis:

- Caixa 1: 30 x 40 x 80 cm  
- Caixa 2: 80 x 50 x 40 cm  
- Caixa 3: 50 x 80 x 60 cm

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- SQL Server
- Entity Framework Core
- AutoMapper
- xUnit
- Docker & Docker Compose
- Swagger

---

## 🐋 Execução via Docker

### Pré-requisitos

- Docker
- Docker Compose

### Passos

```bash
git clone https://github.com/louresb/LojaSeuManoel.git
cd LojaSeuManoel
docker-compose up --build
```

Acesse o Swagger em:

```
http://localhost:5001/swagger
```

> **Nota:** a autenticação está hardcoded apenas para permitir testes rápidos durante a avaliação técnica.

---

## 📌 Exemplos

### Exemplo de entrada (POST /api/pedidos/empacotar)

```json
[
  {
    "produtos": [
      { "nome": "Jogo A", "altura": 20, "largura": 30, "comprimento": 10 },
      { "nome": "Jogo B", "altura": 40, "largura": 20, "comprimento": 10 }
    ]
  }
]
```

### Exemplo de saída

```json
[
  {
    "pedidoId": "guid-do-pedido",
    "caixas": [
      {
        "tipo": "Caixa1",
        "produtos": ["Jogo A", "Jogo B"]
      }
    ]
  }
]
```

### Exemplo de exceção

```json
{
  "title": "Nenhuma caixa disponível comporta o produto Jogo C.",
  "status": 400
}
```

---

## Considerações de Desenvolvimento

- Estrutura separada em camadas (`Api`, `Application`, `Domain`, `Infrastructure`, `Tests`)
- Segurança na autenticação da API com JWT
- Cobertura com testes unitários (xUnit)

---
