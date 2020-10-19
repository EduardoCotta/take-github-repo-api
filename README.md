# Desafio Técnico Take - Eduardo Cotta

Essa é uma API de demonstração construída com .NET Core utilizando C#. 
Seu objetivo principal é retornar os repositórios mais antigos da Take.net que utilizam C#.
Você pode acessar a documentação da API [por esse link](https://take-github-api.herokuapp.com/swagger/)

# Uso

Esse projeto foi feito utilizando .NET Core 3.1

Após clonar o repositório use o botão 'Build' do Visual Studio ou entre na pasta principal do repositório e execute:

```
dotnet build
```

Você pode executar a aplicação caminhando para a pasta src/ e executando:

```
dotnet run
```

A aplicação irá ser executada em http://localhost:5000
A documentação da API localmente se encontra em: http://localhost:5000/swagger/

### Testes unitários
Para executar os testes unitários deve se entrar na pasta principal do repositório e executar:
```
dotnet test
```
Ou você pode executar o projeto de teste via Visual Studio.

### Docker

Para a implantação do projeto tive que criar um container com o Docker, então também existe a possibilidade de testar
o projeto através do build e execução da imagem.

### Fluxo do BOT do Blip

O arquivo com o fluxo do bot do Blip se encontra na pasta principal do repositório nomeado como desafioeduardocotta.json.
Não realizei nenhuma configuração global com o bot, então apenas importar funciona para testá-lo.

