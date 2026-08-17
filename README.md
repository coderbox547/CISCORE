# CIS – ASP.NET Core Migration Guide

## What Changed (MVC 5 → ASP.NET Core 8)

### Framework & Project File
| Old | New |
|-----|-----|
| `cis.csproj` (classic .csproj, targets .NET 4.5.2) | `CisCore.csproj` (SDK-style, targets `net8.0`) |
| `Global.asax` / `Global.asax.cs` | `Program.cs` (top-level statements) |
| `App_Start/RouteConfig.cs` | Inline `app.MapControllerRoute(...)` in `Program.cs` |
| `Web.config` appSettings | `appsettings.json` → `MailSettings` section |

### Dependency Injection
`MailExtension` was a static extension method. It is now `MailService` registered with
`builder.Services.AddScoped<IMailService, MailService>()` and injected into every
controller that needs it via constructor injection.

### File Uploads
`HttpPostedFileBase` (System.Web) → `IFormFile` (Microsoft.AspNetCore.Http).  
`model.file.InputStream` → `await model.file.CopyToAsync(memoryStream)`.

### Static Files
| Old path in views | New path |
|-------------------|----------|
| `../Content/css/` | `~/css/` |
| `../Content/js/`  | `~/js/`  |
| `../Content/images/` | `~/images/` |

All static assets must live under `wwwroot/`. See `wwwroot/ASSETS_README.md`.

### Views
- `_ViewImports.cshtml` added – enables Tag Helpers (`asp-controller`, `asp-action`, `asp-route-*`).
- Forms use `asp-controller` / `asp-action` attributes instead of plain `action="..."`.
- `@Html.AntiForgeryToken()` tokens added to all POST forms.
- `@model cis.Models.Mail` → `@model CisCore.Models.Mail` (auto-fixed by `_ViewImports`).

### Async Email
`SmtpClient.Send()` → `await SmtpClient.SendMailAsync()` (non-blocking).

## Configuration – appsettings.json

```json
"MailSettings": {
  "FromAddress": "sales@confianzaitsolutions.com",
  "ToAddress":   "sales@confianzaitsolutions.com",
  "Subject":     "Enquiry",
  "SmtpHost":    "smtp.gmail.com",
  "SmtpPort":    587,
  "SmtpUser":    "your-gmail@gmail.com",
  "SmtpPassword":"your-app-password"
}
```

> ⚠️ Use a **Gmail App Password** (not your account password).  
> Store secrets in `dotnet user-secrets` or environment variables – never commit passwords to source control.

## Running Locally

```bash
cd CisCore
dotnet run
```

The app listens on `https://localhost:5001` by default.
