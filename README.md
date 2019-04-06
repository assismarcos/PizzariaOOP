# Informações sobre a API

O banco de dados utilizado foi o SQLite afim de facilitar a execução. Um arquivo chamado PizzariaUDS.db está disponível no mesmo diretório do projeto PizzariaUDS.Api.

Todas as requisições realizadas terão seu retorno padronizado, no formato abaixo:
```json
{
    "mensagem": string,
    "dados": object
}
```
Onde:

**mensagem:** uma mensagem retornada pela API.

**dados:** informações retornadas de acordo com cada endpoint.

# Requisição para consulta de tamanhos disponíveis

Endpoint: **[https://localhost:44358/api/pizza/tamanhos](https://localhost:44358/api/pizza/tamanhos)**

Método: **GET**

Retorno:
```json
{
    "mensagem": "",
    "dados": [
        {
            "tamanho": "Pequena",
            "valor": 20,
            "tempoAdicionalPreparoEmMinutos": 15
        },
        {
            "tamanho": "Media",
            "valor": 30,
            "tempoAdicionalPreparoEmMinutos": 20
        },
        {
            "tamanho": "Grande",
            "valor": 40,
            "tempoAdicionalPreparoEmMinutos": 25
        }
    ]
}
```

# Requisição para consulta de sabores disponíveis

Endpoint: **[https://localhost:44358/api/pizza/sabores](https://localhost:44358/api/pizza/sabores)**

Método: **GET**

Retorno:
```json
{
    "mensagem": "",
    "dados": [
        {
            "sabor": "Calabresa",
            "tempoAdicionalPreparoEmMinutos": 0
        },
        {
            "sabor": "Marguerita",
            "tempoAdicionalPreparoEmMinutos": 0
        },
        {
            "sabor": "Portuguesa",
            "tempoAdicionalPreparoEmMinutos": 5
        }
    ]
}
```

# Requisição para consulta das personalizações disponíveis
Endpoint: **[https://localhost:44358/api/pizza/personalizacoes](https://localhost:44358/api/pizza/personalizacoes)**

Método: **GET**

Retorno:
```json
{
    "mensagem": "",
    "dados": [
        {
            "personalizacao": "extra bacon",
            "valor": 3,
            "tempoAdicionalPreparoEmMinutos": 0
        },
        {
            "personalizacao": "sem cebola",
            "valor": 0,
            "tempoAdicionalPreparoEmMinutos": 0
        },
        {
            "personalizacao": "borda recheada",
            "valor": 5,
            "tempoAdicionalPreparoEmMinutos": 5
        }
    ]
}
```

# Requisição para criação do pedido
Endpoint: **[https://localhost:44358/api/pedido](https://localhost:44358/api/pedido)**

Método: **POST**

Parâmetros da requisição:
```json
{
	"tamanho": "Grande",
	"sabor": "Calabresa",
	"personalizacoes": ["extra bacon", "borda recheada", "sem cebola"]
}
```

Onde:

**tamanho (obrigatório)**: Tamanho da pizza. **Tamanhos disponíveis**: **"Grande", "Media" e "Pequena"**.

**sabor (obrigatório)**: Sabor da pizza. **Sabores disponíveis**: *"Calabresa", "Marguerita" e "Portuguesa"*

**personalizacoes (opcional)**: Lista de adicionais e/ou personalizações da pizza. Este parâmetro pode ser informado com uma lista vazia ou simplesmente não ser informado.
**Personalizações disponíveis**: *"extra bacon", "sem cebola", "borda recheada"*.

**Todos os valores são case sensitive, ou seja, devem ser enviados como descritos aqui.**

Retorno:
```json
{
    "mensagem": "Pedido criado",
    "dados": {
        "pedido": 99,
        "tamanho": "Grande",
        "sabor": "Portuguesa",
        "personalizacoes": [
            {
                "personalizacao": "extra bacon",
                "valor": 3
            },
            {
                "personalizacao": "borda recheada",
                "valor": 5
            },
            {
                "personalizacao": "sem cebola",
                "valor": 0
            }
        ],
        "valorPizza": 40,
        "tempoPreparo": 35,
        "valorPedido": 48
    }
}
```

Onde:

**Pedido**: Número do pedido gerado.

**tamanho**: Tamanho da pizza escolhida.

**sabor**: Sabor da pizza escolhido.

**personalizacoes**: Lista de personalizações escolhidas, com seus respectivos valores, caso sema informadas.

**valorPizza**: Valor da pizza sem adicionais de sabor ou personalização

**tempoPreparo**: Tempo de preparo considerando o tempo de preparo da pizza, das personalizações e do sabor escolhido.

**valorPedido**: Valor total do pedido, considerando o valor da pizza e o valor das personalizações.

# Validãções e mensagens de erro
**Tamanho inválido ou não informado**: ocorrerá quando um tamanho de pizza inválido for informado.

**Sabor inválido ou não informado**: ocorrerá quando um sabor de pizza inválido for informado.

**Personalizações inválidas**: ocorrerá quando uma ou mais personalizações inválidas forem informadas.
