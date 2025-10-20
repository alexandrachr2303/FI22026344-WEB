# PP3 - Minimal API

**Nombre:** Alexandra Chacaltana Ramirez  
**Carné:** FI22026344  

## Comandos utilizados

```bash
mkdir PP3
cd PP3
dotnet new sln -n PP3
dotnet new webapi -f net8.0 -o MinimalApi
dotnet sln add MinimalApi
cd MinimalApi
dotnet restore
dotnet run 
```

### Prompts y preguntas

## Prompts utilizados
ChatGPT [ChatGPT Share Link](https://chatgpt.com/share/68f68d94-81e4-800c-ad24-bbf12c728797)

## Preguntas y respuestas

### 1. ¿Es posible enviar valores en el Body (por ejemplo, en el Form) del Request de tipo GET?
Creo que no, ya que el método **GET** se utiliza para **recuperar información** y los parámetros deben enviarse mediante la **URL**.  
En mi caso, no lo intentaría, ya que siento que es menos confiable; si necesito enviar datos más complejos, preferiría no usar GET.

### 2. ¿Qué ventajas y desventajas observa con el Minimal API si se compara con la opción de utilizar Controllers?
Mi punto de vista es que **Minimal API** es ideal para proyectos pequeños, ya que es muy ligero, se aprende rápido, tiene menos configuraciones y todo se define en el `Program.cs`.  
Como desventaja, puede verse muy desordenado cuando hay muchas rutas.

En cuanto a **Controllers**, requieren más archivos y estructura. Los usaría para proyectos más grandes, porque son más formales y escalables.  
Como desventaja, requieren comprender mejor el tema y tener un control más definido sobre las rutas y configuraciones.