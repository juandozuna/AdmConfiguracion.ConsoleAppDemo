# Administración de la Configuración
## Demo App de Consola

Este es el repositorio que contiene el demo actual de lo que será el video que haremos para la consola.

A Continuación estarán las dependencias que deben de estar instaladas para compilar el código

### **DEPENDENCIAS**
* SDK .net Core 2.2.401
* MSSQL Server 2017
* Entity Framework Core Tools


### A la hora de instalar el projecto debe de seguir estos pasos

1) Por consola ir a la ruta en la que esta el proyecto y 
   ejecutar el comando  `dotnet restore`.
2) Luego ejecutar `dotnet build`.
3) Luego ir al archivo **AppDbContext.cs** y modificar el connection string a la base de datos
4) Ejecutar el siguiente commando `dotnet ef database update`
5) Ya solo tiene que ejecutar la aplicación con ```dotnet run ```


Ya con esto el projecto debe de correr sin problemas
