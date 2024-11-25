using Microsoft.JSInterop;
namespace NewClient.Services;

public class NotificationService
{
    private readonly IJSRuntime _jsRuntime;

    public NotificationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowNotification(string message, string type)
    {
        await _jsRuntime.InvokeVoidAsync("showNotification", message, type);
    }
}