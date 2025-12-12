using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWasmJsRuntime.Layout;

public partial class MainLayout : LayoutComponentBase
{
    [Inject] private IJSRuntime? JsRuntime { get; set; }
    private const string LoadScriptFunction = "loadScript";
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsRuntime!.InvokeVoidAsync(LoadScriptFunction, "template.js");
        }
    }
}
