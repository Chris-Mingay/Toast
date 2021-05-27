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

### 3. Register and Configure Toasts Component
Add the `<BlazoredToasts />` tag into your applications *MainLayout.razor*.


### 4. Add reference to style sheet(s)
Add the following line to the `head` tag of your `_Host.cshtml` (Blazor Server app) or `index.html` (Blazor WebAssembly).

For minifed use:

```
<link href="_content/Blazored.Toast/app.min.css" rel="stylesheet" />
```

The stylesheet `app.min.css` contains only the tailwind styles defined in the build process. It is not required that you reference tailwind in your host project, all styles are self contained.

## Usage

Toast instances are generated using the `ToastOptions` class which has the following properties:

- Level, a ToastLevel enum (Info, Success, Error, Warning). Defaults to Info.
- Position, a ToastPosition enum (TopLeft, TopCenter,TopRight,BottomLeft,BottomCenter,BottomRight). Defaults to TopRight.
- Heading, an optional heading string.
- Message, a string or render fragment of the body of the message.
- Timeout, how long the toast should last in milliseconds. Set to 0 to keep in place until closed. Defaults to 5000 (5 seconds).
- OnClick, an optional Action that can be used to run functions upon clicking the included action button.
- ButtonLabel, the label text of the OnClick action.


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


<button class="btn btn-info" @onclick="@(() => toastService.ShowToast("Standard toast","With heading"))">Standard with heading</button>

<button class="btn btn-success" @onclick="@(() => toastService.ShowSuccess("I'm a SUCCESS message with a custom title", "Congratulations!"))">Success Toast</button>
<button class="btn btn-warning" @onclick="@(() => toastService.ShowWarning("I'm a WARNING message"))">Warning Toast</button>
<button class="btn btn-danger" @onclick="@(() => toastService.ShowError("I'm an ERROR message"))">Error Toast</button>
```
Full examples for client and server-side Blazor are included in the [samples](https://github.com/Chris-Mingay/Toast/tree/master/samples).

### Remove Toasts When Navigating
If you wish to clear any visible toasts when the user navigates to a new page you can enable the `RemoveToastsOnNavigation` parameter. Setting this to true will remove any visible toasts whenever the `LocationChanged` event fires.
