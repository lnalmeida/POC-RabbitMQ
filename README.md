# POC-RabbitMQ
# Projeto de Consumo de Mensagens RabbitMQ

Este é um projeto de exemplo que demonstra como criar um consumidor de mensagens RabbitMQ em C# usando o ASP.NET Core. O consumidor recebe mensagens de um produtor RabbitMQ, processa essas mensagens e atualiza o estoque de produtos com base nas informações recebidas.

## Funcionalidades

- Recebe mensagens RabbitMQ e atualiza o estoque de produtos.
- Exibe as informações do estoque atualizado no console em formato de tabela.

## Requisitos

- .NET Core SDK 3.1 ou superior

## Como Executar

1. Clone este repositório em sua máquina.
2. Abra o terminal na pasta do projeto.

```bash
dotnet run
```
O consumidor será iniciado e começará a receber mensagens do RabbitMQ. As atualizações de estoque serão exibidas no console em formato de tabela.

## Configuração

Altere as configurações do RabbitMQ no arquivo Program.cs para se adequar ao seu ambiente.
```
csharp
Copy code
var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/"
};
```

## Contato

Se você tiver alguma dúvida ou feedback, sinta-se à vontade para entrar em contato conosco em l.n.almeida.ti@gmail.com.
