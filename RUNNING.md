

<!-- local-development:start -->
# Desarrollo local

Puedes abrir este repositorio en VS Code, Antigravity o Sublime Text. El compilador y los servicios necesarios dependen del componente indicado abajo.

## .NET SDK

Instala el SDK correspondiente al destino de la tabla. .NET 8 y 9 finalizaron soporte el 2026-11-10; compilar con ellos no acredita un runtime con soporte para producción. .NET 10 requiere Visual Studio 2026 para trabajar desde ese IDE; la CLI puede usarse desde VS Code.

```powershell
dotnet --list-sdks
dotnet build 'Laboratorio3.csproj'
```

[.NET support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) · [SDK / Visual Studio compatibility](https://learn.microsoft.com/en-us/dotnet/core/porting/versioning-sdk-msbuild-vs)

## Componentes y validación

Inventario y compilaciones locales del 2026-11-15. Una compilación correcta no acredita todavía interacción, compatibilidad de base de datos, instalador ni despliegue.

| Componente | Tipo / destino | Validación |
| --- | --- | --- |
| [Laboratorio3.csproj](<Laboratorio3.csproj>) | dotnet / netcoreapp3.1 | Bloqueado: CS0246 |
| [Laboratorio3.sln](<Laboratorio3.sln>) | solution | Sin ejecutar |

## Archivos ignorados

`.gitignore` excluye credenciales locales, estado del editor y salidas de las herramientas detectadas. No deja de versionar archivos que ya estaban en Git. Los manifiestos, archivos de bloqueo, recursos fuente y scripts de esquema forman parte del código.
<!-- local-development:end -->

<!-- verified-builds-20261115:start -->
## Compilación comprobada

- Compilación satisfactoria registrada para `Laboratorio3.csproj`.

Comandos:

```powershell
msbuild "Laboratorio3.csproj" /restore /t:Build
```

La compilación no acredita todos los flujos gráficos, conexiones a bases de datos ni servicios externos. No se ejecutaron operaciones de administración contra esos servicios.
<!-- verified-builds-20261115:end -->
