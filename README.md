# POC-RabbitMQ
# Projeto de Consumo de Mensagens RabbitMQ

Este é um projeto de exemplo que demonstra como criar um consumidor de mensagens RabbitMQ em C# usando o ASP.NET Core. O consumidor recebe mensagens de um produtor RabbitMQ, processa essas mensagens e atualiza o estoque de produtos com base nas informações recebidas. Como foi feito somente para fins didáticos e testar como seria o consumo de muma mensagem, não me atentei a padrões de código ou testes. 

## Funcionalidades

- Recebe mensagens RabbitMQ e atualiza o estoque de produtos.
- Exibe as informações do estoque atualizado no console em formato de tabela.

## Requisitos

- .NET Core 6 ou superior
- Docker version 20.10.25, build 20.10.25-0ubuntu1~20.04.1
- Imagem RabbitMQ 3.12.2
- RabbitMQ Client
- Newtonsoft JSON

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

Se você tiver alguma dúvida ou feedback, sinta-se à vontade para entrar em contato comigo em l.n.almeida.ti@gmail.com.
