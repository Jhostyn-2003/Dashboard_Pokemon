
# Dashboard_Pokemon

Este proyecto es una aplicación construida en .NET que consume la API pública de Pokémon para mostrar estadísticas de un Pokémon seleccionado en un diagrama de barras.

## Características

- **Consumo de la API pública de Pokémon**: Conexión a la [PokéAPI](https://pokeapi.co/) para obtener datos sobre un Pokémon específico.
- **Visualización de datos**: Gráficos en barra para mostrar las estadísticas de los Pokémon seleccionados.
- **Interfaz amigable**: Dashboard simple y fácil de usar para interactuar con la API y visualizar los resultados.
  
## Tecnologías Utilizadas

- **.NET**: Framework principal para el desarrollo backend.
- **ASP.NET Core**: Usado para crear la API de backend y servir la aplicación.
- **Entity Framework Core**: Para manejar las consultas y almacenamiento de datos.
- **PokéAPI**: API pública para obtener los datos de los Pokémon.
- **Chart.js**: Librería JavaScript utilizada para generar los gráficos en barra en el frontend.
- **C#**: Lenguaje de programación utilizado para el desarrollo del backend.
  
## Requisitos del Sistema

- **.NET 6.0** o superior.
- **Visual Studio 2022** (opcional para desarrollo y depuración).

## Instalación y Configuración

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/usuario/Dashboard_Pokemon.git
   ```

2. **Navega al directorio del proyecto:**

   ```bash
   cd Dashboard_Pokemon
   ```

3. **Configura las variables de entorno:**

   Si estás utilizando claves API adicionales, asegúrate de configurarlas en el archivo `appsettings.json` o mediante variables de entorno.

   Ejemplo de configuración de `appsettings.json`:
   
   ```json
   {
     "ApiSettings": {
       "PokeApiBaseUrl": "https://pokeapi.co/api/v2/pokemon/"
     }
   }
   ```

4. **Restaura las dependencias:**

   ```bash
   dotnet restore
   ```

5. **Ejecuta el proyecto:**

   ```bash
   dotnet run
   ```

6. **Navega a la aplicación** en tu navegador en la dirección `http://localhost:5000`.

## Uso
1. La aplicación realizará una solicitud a la API pública y mostrará un gráfico en barra con las estadísticas del Pokémon seleccionado.
2. Puedes comparar diferentes Pokémon seleccionándolos desde la interfaz del dashboard.

## Contribuciones

Las contribuciones son bienvenidas. Si tienes alguna idea para mejorar el proyecto o deseas corregir algún error, no dudes en hacer un fork y abrir un pull request.

1. Haz un fork del proyecto.
2. Crea una nueva rama con tu funcionalidad (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -am 'Agregada nueva funcionalidad'`).
4. Haz push a tu rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un pull request.

## Licencia

Este proyecto está bajo la Licencia MIT - consulta el archivo [LICENSE](LICENSE) para más detalles.
