# Informa��es sobre a API

O banco de dados utilizado foi o SQLite afim de facilitar a execu��o. Um arquivo chamado PizzariaUDS.db est� dispon�vel no mesmo diret�rio do projeto PizzariaUDS.Api.

Todas as requisi��es realizadas ter�o seu retorno padronizado, no formato abaixo:
```json
{
    "mensagem": string,
    "dados": object
}
```
Onde:

**mensagem:** uma mensagem retornada pela API.

**dados:** informa��es retornadas de acordo com cada endpoint.

# Requisi��o para consulta de tamanhos dispon�veis

Endpoint: **[https://localhost:44358/api/pizza/tamanhos](https://localhost:44358/api/pizza/tamanhos)**

M�todo: **GET**

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

# Requisi��o para consulta de sabores dispon�veis

Endpoint: **[https://localhost:44358/api/pizza/sabores](https://localhost:44358/api/pizza/sabores)**

M�todo: **GET**

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

# Requisi��o para consulta das personaliza��es dispon�veis
Endpoint: **[https://localhost:44358/api/pizza/personalizacoes](https://localhost:44358/api/pizza/personalizacoes)**

M�todo: **GET**

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

# Requisi��o para cria��o do pedido
Endpoint: **[https://localhost:44358/api/pedido](https://localhost:44358/api/pedido)**

M�todo: **POST**

Par�metros da requisi��o:
```json
{
	"tamanho": "Grande",
	"sabor": "Calabresa",
	"personalizacoes": ["extra bacon", "borda recheada", "sem cebola"]
}
```

Onde:

**tamanho (obrigat�rio)**: Tamanho da pizza. **Tamanhos dispon�veis**: **"Grande", "Media" e "Pequena"**.

**sabor (obrigat�rio)**: Sabor da pizza. **Sabores dispon�veis**: *"Calabresa", "Marguerita" e "Portuguesa"*

**personalizacoes (opcional)**: Lista de adicionais e/ou personaliza��es da pizza. Este par�metro pode ser informado com uma lista vazia ou simplesmente n�o ser informado.
**Personaliza��es dispon�veis**: *"extra bacon", "sem cebola", "borda recheada"*.

**Todos os valores s�o case sensitive, ou seja, devem ser enviados como descritos aqui.**

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

**Pedido**: N�mero do pedido gerado.

**tamanho**: Tamanho da pizza escolhida.

**sabor**: Sabor da pizza escolhido.

**personalizacoes**: Lista de personaliza��es escolhidas, com seus respectivos valores, caso sema informadas.

**valorPizza**: Valor da pizza sem adicionais de sabor ou personaliza��o

**tempoPreparo**: Tempo de preparo considerando o tempo de preparo da pizza, das personaliza��es e do sabor escolhido.

**valorPedido**: Valor total do pedido, considerando o valor da pizza e o valor das personaliza��es.

# Valid���es e mensagens de erro
**Tamanho inv�lido ou n�o informado**: ocorrer� quando um tamanho de pizza inv�lido for informado.

**Sabor inv�lido ou n�o informado**: ocorrer� quando um sabor de pizza inv�lido for informado.

**Personaliza��es inv�lidas**: ocorrer� quando uma ou mais personaliza��es inv�lidas forem informadas.
