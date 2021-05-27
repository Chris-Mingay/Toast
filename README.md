# Blazor Tailwind Toast
This is a JavaScript free toast implementation for [Blazor](https://blazor.net) and Razor Components applications using [tailwindcss](https://tailwindcss.com/) for styling.

This project is a fork of [Blazored.Toast](https://github.com/Blazored/Toast) with some minor differences.

## Differences from Blazored Toast

- Uses tailwind for styling rules
- Removed icons
- Removed progress bar
- Ability to select which position a toast instance appears on screen.
- Hover pauses the timeout
- Toast content has to be a string (for now), whereas Blazored Toast lets you send a RenderFragment


## Getting Setup

~~You can install the package via the NuGet package manager just search for *Blazored.Toast*. You can also install via powershell using the following command.~~

```powershell
Install-Package NotYet.Toast
```

~~Or via the dotnet CLI~~

```bash
dotnet add package NotYet.Toast
```

### 1. Register Services
You will need to register the Blazored Toast service in your application

#### Blazor Server
Add the following line to your applications `Startup.ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddBlazoredToast();
}
```

#### Blazor WebAssembly
Add the following line to your applications `Program.Main` method.

```csharp
builder.Services.AddBlazoredToast();
```

### 2. Add Imports
Add the following to your *_Imports.razor*

```csharp
@using Blazored.Toast
@using Blazored.Toast.Services
@using Blazored.Toast.Enums
```

### 3. Register Toasts Component
Add the `<BlazoredToasts />` tag into your applications *MainLayout.razor*.


### 4. Add reference to style sheet
Add the following line to the `head` tag of your `_Host.cshtml` (Blazor Server app) or `index.html` (Blazor WebAssembly).

For minifed use:

```
<link href="_content/Blazored.Toast/css/app.min.css" rel="stylesheet" />
```

The stylesheet `app.min.css` contains only the tailwind styles defined in the build process. It is not required that you reference tailwind in your host project, all styles are self contained.

## Usage

Toast instances are configured with the `ToastOptions` class:

```csharp
public class ToastOptions
{
    // The theme to use for this instance
    public ToastLevel Level { get; set; } = ToastLevel.Info;

    // The position of this instance
    public ToastPosition Position { get; set; } = ToastPosition.TopRight;

    // An optional heading
    public string Heading { get; set; }

    // The message body
    public string Message { get; set; }

    // How long the instance stays on screen in millisends
    public int Timeout { get; set; } = 5000; // i.e. 5 secods

    // An option on click event can be run
    public Action? OnClick { get; set; }

    // When an action is provided this is used for the button text.
    public string ButtonLabel { get; set; }

}
```

## Code Example

```html
@page "/toastdemo"
@inject IToastService toastService

<h1>Toast Demo</h1>

<button type="button" @onclick="() => toastService.ShowToast("Message","Heading")">
    Inline message and heading
</button>

<button type="button" @onclick="() => toastService.ShowToast(new ToastOption{
    Message = "Toast option based message",
    Heading = null,
    Timeout = 10000,
    Level = ToastLevel.Error,
    Position = ToastPosition.BottomCenter
})">
    ToastOption based
</button>
```
Full examples for client and server-side Blazor are included in the [samples](https://github.com/Chris-Mingay/Toast/tree/master/samples).

### Remove Toasts When Navigating
If you wish to clear any visible toasts when the user navigates to a new page you can enable the `RemoveToastsOnNavigation` parameter. Setting this to true will remove any visible toasts whenever the `LocationChanged` event fires.
