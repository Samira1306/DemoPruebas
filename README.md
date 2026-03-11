# DemoPruebas

Proyecto de pruebas unitarias e integracion para .NET implementando arquitectura hexagonal con enfasis en testabilidad y separacion de responsabilidades.

## Descripcion

**DemoPruebas** es una aplicacion web API desarrollada con .NET 8 que implementa arquitectura hexagonal (Ports & Adapters) con enfoque principal en testing. El proyecto demuestra como estructurar codigo altamente testeable mediante separacion clara de capas, inversion de dependencias y patrones que facilitan el mocking.

### Objetivo principal

**Testing Completo**: Implementacion de estrategias de testing unitario e integracion usando **xUnit** y **Moq**:
- Tests unitarios con mocking de dependencias externas
- Tests de integracion de endpoints HTTP
- Cobertura de casos exitosos y manejo de errores
- Arquitectura que maximiza la testabilidad

### Caracteristicas secundarias

Como soporte para el testing efectivo, el proyecto implementa:
- **Arquitectura Hexagonal** (Ports & Adapters)
- **Patron CQRS** con MediatR
- **Repository Pattern** generico
- **Soporte dual** para Entity Framework Core y ADO.NET
- **Validaciones** con FluentValidation
- **Logging estructurado** con Serilog

## Arquitectura

El proyecto implementa **Arquitectura Hexagonal (Ports & Adapters)**, organizada en capas concentricas donde las dependencias apuntan hacia el centro.

External adapters (Infrastructure):
- EF Core Repository
- ADO .NET Repository
- SQL Server DbContext
- Oracle DataContext

Application Core (Use Cases):
- Command handlers
- Query Handlers
- Validations
- Interfaces
- Services

Domain (Entities):
- ErrorLog
- Value objects
- Resources
- Models

## Estructura del proyecto

DemoPruebas

    DemoPruebas.Domain
    Entidades y modelos del dominio

    DemoPruebas.Application
    Casos de uso, handlers y validaciones

    DemoPruebas.Infraestructure
    Implementaciones de persistencia y adaptadores externos

    DemoPruebas
    API y configuracion de la aplicacion

    DemoPruebas.Test
    Tests de integracion

    DemoPruebas.PuTest
    Tests unitarios

## Tecnologias utilizadas

Framework y lenguaje
- .NET 8.0
- ASP.NET CORE 8.0

Testing
- xUnit 2.x
- Moq 4.x
- Microsoft.AspNetCore.Mvc.Testing 8.x
- Microsoft.EntityFrameworkCore.InMemory 9.x

Persistencia
- Entity Framework Core 9.0.1
- Microsoft.EntityFrameworkCore.SqlServer 9.0.1
- Oracle.ManagedDataAccess.Core 3.x

Patrones y arquitectura
- MediatR 12.x
- FluentValidation 11.x

## Pruebas unitarias

Los tests unitarios verifican el comportamiento de componentes individuales (casos de uso) en **completo aislamiento**, reemplazando todas las dependencias externas con mocks.

Patron AAA (Arrange-Act-Assert):

Todos los tests siguen el patron AAA:

- **Arrange**: Preparar el escenario de prueba (datos de entrada, configuracion de mocks)
- **Act**: Ejecutar el metodo o funcion bajo prueba
- **Assert**: Verificar que el resultado es el esperado

## Pruebas de integracion

Los tests de integracion verifican el **flujo completo end-to-end** del sistema, probando la integracion real entre todos los componentes (adaptadores HTTP, casos de uso, adaptadores de persistencia) con infraestructura real o simulada.

Patron AAA (Arrange-Act-Assert):

Todos los tests de integracion siguen el patron AAA, pero con enfoque en HTTP:

- **Arrange**: Preparar el request HTTP (datos de entrada, payload JSON)
- **Act**: Ejecutar la llamada HTTP real al endpoint
- **Assert**: Verificar la respuesta HTTP

## Ejecucion de pruebas desde consola

Para ejecutar las pruebas del proyecto desde la consola se debe utilizar la herramienta CLI de .NET.

1. Abrir una terminal o consola.

2. Ubicarse en la carpeta raiz del proyecto.

3. Ejecutar el siguiente comando:
**dotnet test**

Este comando compila el proyecto de pruebas y ejecuta todos los tests disponibles.

## Ejecucion de pruebas desde el visor de Visual Studio

Con el proyecto abierto en Visual Studio es posible ejecutar las pruebas utilizando el **Explorador de pruebas**.

Pasos:

1. Ir al menu **Ver** en la barra superior.
2. Seleccionar la opcion **Explorador de pruebas**.
3. Se abrira una ventana donde se listan todos los tests disponibles en el proyecto.

Desde el Explorador de pruebas se pueden ejecutar:

- **Todos los tests** al mismo tiempo.
- **Tests individuales** de forma manual.

Tambien es posible visualizar el resultado de cada prueba (correcta o fallida) directamente desde este visor.

## Debug en pruebas

Para depurar una prueba directamente desde Visual Studio se puede utilizar la opcion de **Debug Test**.

Pasos:

1. Ubicarse sobre el test que se desea ejecutar en modo depuracion.
2. Hacer clic derecho sobre el metodo de prueba.
3. Seleccionar la opcion **Debug Test**.

Esto ejecutara la prueba en modo depuracion, permitiendo utilizar breakpoints, inspeccionar variables y analizar el flujo de ejecucion paso a paso.

## Ejecucion de la aplicacion

1. Clonar el repositorio
2. Abrir la solucion en Visual Studio
3. Seleccionar el proyecto **DemoPruebas** como proyecto de inicio
4. Ejecutar la aplicacion

Tambien puede ejecutarse desde la consola con:

**dotnet run**





