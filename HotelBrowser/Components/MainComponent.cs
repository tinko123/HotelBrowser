using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Components
{
    public class MainComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
