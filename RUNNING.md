# Laboratorio3: análisis de texto

Aplicación ASP.NET Core MVC recuperada para ejecutar el ejercicio sin la biblioteca externa `LibraryData`, que no estaba incluida. Su contrato consumido se implementa ahora en `Services/SentenceService.cs`; es una reconstrucción local, no el código original de esa biblioteca.

## Ejecutar y comprobar

Requiere .NET SDK 10.0.404 o compatible con `global.json`. En esta PC, activa primero `D:\GH\_tools\Enable-DotNet10.ps1`. Abre la carpeta en VS Code o Antigravity; Visual Studio 2022 no admite este destino net10.0.

```powershell
. D:\GH\_tools\Enable-DotNet10.ps1
.\build-local.ps1
.\build-local.ps1 -Action run
# Abrir http://localhost:5086
```

Pruebas sin servicios externos:

```powershell
dotnet run --project tests/SmokeLaboratorio3/SmokeLaboratorio3.csproj
```

Se comprueban caracteres Unicode, índices inválidos/ausentes, búsqueda, muestra sin conexión y que el controlador conserve sus tres resultados. La página muestra carácter inicial, palabra encontrada e índice sin sobrescribir resultados ni eliminar los dígitos del índice.

`LABORATORIO_URL` permite leer una página HTTP/HTTPS que elijas; sin ella se usa una muestra local. El modo externo requiere conexión y tiene límite de 10 segundos. No se ha probado contra sitios de terceros. El control de carga de archivo sin implementación fue retirado de la página.

Los cambios quedan en la rama de revisión `codex/build-repairs-20261115`; no se integra la rama principal de UTN. `.gitignore` excluye bin/obj y datos locales.
