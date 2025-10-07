# Calculadora Binaria - PP2

**Nombre:** Alexandra Ramirez  
**Carné:** 12345678

---

## Comandos utilizados

```bash
mkdir PP2
cd PP2
dotnet new sln -n PP2
dotnet new mvc -n CalculadoraBin -f net8.0
dotnet sln PP2.sln add CalculadoraBin/CalculadoraBin.csproj
cd CalculadoraBin
dotnet restore
dotnet run
```

## Fuentes
https://www.ingmecafenix.com/electronica/general/operaciones-con-numeros-binarios/

##Prompts
[ChatGPT](https://chatgpt.com/c/68e59443-6ff0-8329-84dd-f9327d3f2646)

## Preguntas

1-**¿Cuál es el número que resulta al multiplicar, si se introducen los valores máximos permitidos en a y b? Indíquelo en todas las bases (binaria, octal, decimal y hexadecimal).**

-Si tomamos los valores máximos permitidos para a y b, ambos serían 11111111 en binario, que equivale a 255 en decimal.
Al multiplicarlos: 255 * 255 = 65025.

-Binario: `1111111000000000` 
-Octal: `177001`
-Decimal: `65025`
-Binario: `1111111000000001`
-Hexadecimal:`FE01`

----

2-**¿Es posible hacer las operaciones en otra capa? Si sí, ¿en cuál sería?**
Si es posible. Lo ideal es no poner la lógica directamente en el Controller, sino en una capa de ** servicio o de lógica de negocio. Asi esta capa se va a encargar  de procesar los datos y hacer ** loscálculos necesarios, mientras que el Controller solo recibe las solicitudes del usuario y ** devuelve los resultados. Asi, el proyecto queda más organizado, fácil de mantener. **