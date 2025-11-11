# LibreriaApp

**Nombre:** Alexandra Chacaltana Ramirez 
**Carné:** FI22026344

## Comandos

```bash
mkdir PP4
cd PP4
dotnet new sln -n LibreriaSolution
dotnet new console -n LibreriaApp --framework net8.0
dotnet sln LibreriaSolution.sln add LibreriaApp/LibreriaApp.csproj
cd LibreriaApp
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package CsvHelper
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

### Prompts y preguntas

## Prompts utilizados
ChatGPT [ChatGPT Share Link](https://chatgpt.com/share/69135e21-d6a4-800c-8837-c4ff34da84ee)

## Preguntas y respuestas

**¿Cómo cree que resultaría el uso de la estrategia de Code First para crear y actualizar una base de datos de tipo NoSQL (como por ejemplo MongoDB)? ¿Y con Database First? ¿Cree que habría complicaciones con las Foreign Keys?** 

### Respuesta


La estrategia de **Code First** sería útil para trabajar con bases NoSQL, ya que permite definir los modelos de manera directa en el código y así generar una estructura flexible, sin depender de un esquema.  

Con **Database First** está más pensado para bases de datos relacionales con tablas y estructuras fijas. Usarlo en NoSQL puede resultar complicado, porque estas bases son dinámicas y no siempre tienen un esquema definido.  

Las **Foreign Keys**, en las bases NoSQL, no existen de manera automática. Si se necesitaran relaciones entre los datos, se pueden manejar con referencias o documentos, a diferencia de las bases SQL, donde las Foreign Keys son directas y se crean de manera automática.



---


**¿Cuál carácter, además de la coma (,) y el Tab (\t), se podría usar para separar valores en un archivo de texto con el objetivo de ser interpretado como una tabla (matriz)? ¿Qué extensión le pondría y por qué?**

### Respuesta
Se puede utilizar el **guion (-) o el guion bajo (_)** para separar los valores.  
Funciona mejor con datos sencillos que no contengan guiones, ya que así se pueden separar las columnas sin confundir los datos.  

Para la extensión del archivo, se podría usar:

- `.dash` si se quiere indicar claramente que los valores están separados por guiones.  
- `.txt` si se prefiere algo más básico y fácil de abrir en cualquier editor de texto.