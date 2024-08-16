<div align="center">
  <h1>API-WebSocket</h1>
  <img src="https://img.shields.io/badge/license-MIT-blue.svg" alt="Licença">
  <img src="https://img.shields.io/badge/.NET-5.0-blue.svg" alt=".NET">
  <img src="https://img.shields.io/badge/EntityFramework-5.0.0-green.svg" alt="EntityFramework">
  <img src="https://img.shields.io/badge/CleanArchitecture-Clean-blue.svg" alt="CleanArchitecture">
  <img src="https://img.shields.io/badge/WebSocket-Native-orange.svg" alt="WebSocket">
</div>

## 📚 Descrição

API-WebSocket é uma API desenvolvida em .NET utilizando WebSocket nativo, Entity Framework, Clean Architecture e páginas ASP.NET. Esta API é ideal para aplicações que necessitam de comunicação em tempo real, fornecendo uma estrutura robusta e escalável.

## 🗂 Índice
https://drive.google.com/file/d/1YMUNjr4my83jRKCDZjEFFNyvLmMB9oKZ/view?usp=drivesdk
- [Instalação](#instalação)
- [Uso](#uso)
- [Recursos](#recursos)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

## 🚀 Instalação

Siga os passos abaixo para instalar e configurar o ambiente para rodar o projeto.

### Pré-requisitos

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Passos para Instalação

1. Clone o repositório:

    ```bash
    git clone https://github.com/FlavioMartinsJr/API-WebSocket.git
    ```

2. Navegue até o diretório do projeto:

    ```bash
    cd API-WebSocket
    ```

3. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

4. Configure a string de conexão com o SQL Server no arquivo `appsettings.json`:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;User Id=SEU_USUARIO;Password=SUA_SENHA;"
    }
    ```

5. Atualize o banco de dados:

    ```bash
    dotnet ef database update
    ```

6. Execute o projeto:

    ```bash
    dotnet run
    ```

## 📖 Uso

Para iniciar o servidor, execute o comando `dotnet run` e acesse a aplicação através de `http://localhost:5000`.

### Exemplos de Uso

#### Comunicação WebSocket

1. **Conectar ao WebSocket**

    Conecte-se ao endpoint WebSocket utilizando um cliente WebSocket:

    ```javascript
    const socket = new WebSocket('ws://localhost:5000/ws');

    socket.onopen = function(event) {
        console.log('Conectado ao WebSocket');
        socket.send('Mensagem inicial');
    };

    socket.onmessage = function(event) {
        console.log('Mensagem recebida:', event.data);
    };

    socket.onclose = function(event) {
        console.log('WebSocket desconectado');
    };
    ```

#### Operações com Dados

1. **Adicionar um Item**

    ```http
    POST /api/items
    Content-Type: application/json

    {
      "name": "Nome do Item",
      "description": "Descrição do Item"
    }
    ```

2. **Obter Lista de Itens**

    ```http
    GET /api/items
    ```

## 🛠️ Recursos

- **WebSocket Nativo:** Comunicação em tempo real utilizando WebSocket nativo do .NET.
- **Clean Architecture:** Manutenção e escalabilidade facilitadas.
- **Entity Framework:** ORM para interações eficientes com o banco de dados.
- **ASP.NET Pages:** Páginas dinâmicas utilizando ASP.NET.

## 🤝 Contribuição

Instruções sobre como contribuir para o projeto:

1. Fork o repositório
2. Crie uma branch com a nova feature (`git checkout -b nova-feature`)
3. Commite suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Faça o push para a branch (`git push origin nova-feature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

## 📬 Contato

Link do Projeto: [https://github.com/FlavioMartinsJr/API-WebSocket](https://github.com/FlavioMartinsJr/API-WebSocket)
