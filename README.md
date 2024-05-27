
# Task Management API

Este projeto é uma API RESTful para gerenciar uma lista de tarefas, construída em C# usando a plataforma .NET. A arquitetura segue o padrão DDD (Domain-Driven Design) e inclui boas práticas de desenvolvimento, segurança e documentação.

## Funcionalidades

- **CRUD de Tarefas:** Criação, leitura, atualização e exclusão de tarefas.
- **Listagem de Tarefas:** Listar todas as tarefas ou filtrá-las com base em seu status (pendente, em andamento, concluída).
- **Autenticação e Autorização:** Suporte à autenticação de usuários. Apenas os criadores das tarefas podem atualizá-las ou excluí-las, mas as tarefas são visíveis para todos os usuários autenticados.
- **Documentação:** API documentada usando Swagger.
- **Testes Unitários:** Testes unitários para garantir a robustez e a confiabilidade da API.
- **Segurança:** Proteção contra ataques comuns, como injeção SQL e ataques de força bruta.
- **Escalabilidade e Performance:** Projeta para ser escalável e otimizada para alta performance e baixa latência.
- **Logs:** Implementação de logs para rastrear eventos importantes.

## Estrutura do Projeto
src
 TaskManagement.Api # Camada de apresentação (API)
 TaskManagement.Domain # Camada de domínio (entidades, interfaces, serviços de domínio)
 TaskManagement.Infrastructure # Camada de infraestrutura (repositórios, contexto de dados, implementações de serviços)

## Tecnologias Utilizadas

- .NET 6
- Entity Framework Core
- SQL Server
- Swagger para documentação
- JWT para autenticação
- In-Memory Database para testes

### Configuração do Banco de Dados

1. Configure a string de conexão no arquivo `appsettings.json` na seção `ConnectionStrings`.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "StringHere"
  },
  "Jwt": {
    "Key": "SecretKeyWithAtLeast32Characters",
    "Issuer": "IssuerHere",
    "Audience": "AudienceHere"
  }
}
