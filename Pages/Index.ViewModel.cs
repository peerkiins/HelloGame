using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HelloGame
{
    public class IndexViewModel: ComponentBase
    {
        private Canvas2DContext _context;

        protected BECanvasComponent _canvasReference;
        protected ElementReference ashRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                this._context = await this._canvasReference.CreateCanvas2DAsync();
                int maxFrames = 4;
                int currentFrame = 1;
                int y = 0;
                while(true)
                {
                    await Task.Delay(100);
                    await this._context.SetFillStyleAsync("cornflowerblue");
                    await this._context.FillRectAsync(0, 0, 1024, 768);
                    await this._context.DrawImageAsync(ashRef, (currentFrame - 1) * 64, 0, 64, 64, 0, y, 64, 64);
                    currentFrame++;
                    y++;
                    if(currentFrame > maxFrames)
                        currentFrame = 1;
                }
            }
        }

        protected void OnKeypress(KeyboardEventArgs e)
        {
            Console.WriteLine(e.Code);
        }
    }
}
