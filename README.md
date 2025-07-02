# TaskManager API (Back-end do Projeto To-Do List)

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

## 📝 Descrição

Esta é a API RESTful construída em C# com ASP.NET Core para servir como back-end para a aplicação [To-Do List Full-Stack](https://github.com/IvanildoPaiva/todolist-csharp-api.git). A API é responsável por todas as operações de **CRUD (Criar, Ler, Atualizar, Deletar)** das tarefas.

Este projeto foi desenvolvido como parte de um estudo aprofundado para solidificar conceitos de desenvolvimento back-end e sua integração com um front-end moderno em React.

## ✨ Funcionalidades

- **Listar** todas as tarefas.
- **Criar** uma nova tarefa.
- **Atualizar** uma tarefa existente (para marcar como completa/incompleta).
- **Deletar** uma tarefa específica.

## 🛠️ Tecnologias Utilizadas

* **.NET 8** (ou a versão do seu SDK)
* **C# 12** (ou a versão correspondente)
* **ASP.NET Core Web API**
* **Swagger (Swashbuckle)** para documentação e teste de endpoints.

## 🚀 Endpoints da API

A URL base da API é `http://localhost:5205`

| Verbo  | Endpoint           | Descrição                                 | Corpo da Requisição (Exemplo)                                |
| :----- | :----------------- | :---------------------------------------- | :----------------------------------------------------------- |
| `GET`  | `/api/tasks`       | Retorna a lista de todas as tarefas.      | (Nenhum)                                                     |
| `POST` | `/api/tasks`       | Cria uma nova tarefa.                     | `{ "text": "Nova tarefa", "completed": false }`              |
| `PUT`  | `/api/tasks/{id}`  | Atualiza uma tarefa existente.            | `{ "id": 1, "text": "Tarefa atualizada", "completed": true }` |
| `DELETE`| `/api/tasks/{id}` | Deleta uma tarefa específica pelo seu ID. | (Nenhum)                                                     |

## ⚙️ Como Rodar o Projeto Localmente

Siga os passos abaixo para executar o back-end em sua máquina.

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 ou superior) instalado.

### Passos

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git](https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git)
    ```

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd TaskManager.API
    ```

3.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

4.  A API estará rodando em `http://localhost:5205`. Para testar os endpoints de forma interativa, acesse a documentação do Swagger em:
    **`http://localhost:5205/swagger`**

## status do projeto

- Projeto Concluído ✔️