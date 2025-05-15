# Prueba Técnica - Backend .NET Core

Este proyecto fue preparado como **base para la evaluación técnica** solicitada. Contiene la estructura inicial de una Web API desarrollada con ASP.NET Core y Entity Framework Core.

## ✅ Estado actual

- Proyecto creado y configurado correctamente.
- Configuración de Entity Framework Core lista para nuevas entidades.
- Carpetas organizadas (`Controllers`, `Models`, `DTOs`, `Data`).
- Entidades de ejemplo (`Post` y `Comment`) fueron eliminadas para dejar espacio a las nuevas entidades que serán provistas durante la evaluación.

## 🔧 Requisitos

- .NET SDK 8+
- SQL Server (local o remoto)


## 🔧 Cómo ejecutar el proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/TU_USUARIO/TU_REPO.git
   cd TU_REPO

2. Restaurar dependencias:
	```bash
   dotnet restore

3. Crear la base de datos (opcional):
	```bash
   dotnet ef database update

4. Ejecutar el proyecto:
	```bash
   dotnet run

5. Probar los endpoints accediendo a Swagger:
   ```bash
   https://localhost:{puerto}/swagger

##  Estructura del proyecto
css
Copiar
Editar
/Controllers       → Controladores de la API
/Models            → Entidades del dominio
/DTOs              → Modelos para transferencia de datos
/Data              → DbContext y configuración EF Core
/Migrations        → Se generarán al agregar nuevas entidades

##  Notas
Se utilizó dotnet new gitignore para evitar subir archivos innecesarios (bin, obj, .user, etc.).

Se eliminó código de prueba para comenzar con una base limpia.

El proyecto está listo para recibir nuevas entidades, crear migraciones y trabajar sobre endpoints reales.

Hecho con 💻 por Marianela.