# 📘 Prueba Técnica Bechsud - API Posts & Comments

Este proyecto es una API RESTful construida en **ASP.NET Core** para gestionar publicaciones (Posts) y sus comentarios (Comments), como parte de una prueba técnica.

## 🚀 Tecnologías utilizadas

- ASP.NET Core 6 o superior
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- Swagger (documentación y testeo)

## 📂 Estructura general

- **Models:** Entidades `Post` y `Comment`
- **DTOs:** `PostDTO` para creación/edición
- **Controllers:** `PostsController` con endpoints CRUD
- **Data:** `AppDbContext` como DbContext principal

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

📮 Endpoints disponibles
GET /api/posts → Lista todos los posts

GET /api/posts/{id} → Obtiene un post por ID

POST /api/posts → Crea un nuevo post

PUT /api/posts/{id} → Actualiza un post

DELETE /api/posts/{id} → Elimina un post

POST /api/posts/test → Endpoint de prueba (no guarda en la base)

📝 Notas
Esta es una versión simplificada pensada para una prueba técnica.

No incluye autenticación ni autorización.

Listo para escalar con otras entidades como User, Category, etc.