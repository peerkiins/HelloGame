using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HelloGame
{
    public class IndexViewModel : ComponentBase
    {
        private Canvas2DContext _context;

        protected BECanvasComponent _canvasReference;
        protected ElementReference ashRef;
        int maxFrames = 4;
        int currentFrame = 1;
        int mapBorderMaxY = 768;
        int mapBorderMaxX = 1024;
        int spriteX = 64;
        int spriteY = 0;
        int y = 352;
        int x = 480;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this._context = await this._canvasReference.CreateCanvas2DAsync();
                await Task.Delay(100);
                await this._context.SetFillStyleAsync("cornflowerblue");
                await this._context.FillRectAsync(0, 0, mapBorderMaxX, mapBorderMaxY);
                await this._context.DrawImageAsync(ashRef, (currentFrame - 1) * spriteX, spriteY, 64, 64, x, y, 64, 64);
                if (currentFrame > maxFrames)
                    currentFrame = 1;
            }
            else
            {
                await Task.Delay(100);
                await this._context.SetFillStyleAsync("cornflowerblue");
                await this._context.FillRectAsync(0, 0, mapBorderMaxX, mapBorderMaxY);
                await this._context.DrawImageAsync(ashRef, (currentFrame - 1) * spriteX, spriteY, 64, 64, x, y, 64, 64);
                if (currentFrame > maxFrames)
                    currentFrame = 1;
            }
        }

        protected void OnKeypress(KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case "w":
                case "W":
                    spriteY = 192;
                    if (y != 0)
                    {

                        currentFrame++;
                        y--;
                    }
                    break;
                case "a":
                case "A":
                    spriteY = 64;
                    if (x != 0)
                    {
                        x--;
                        currentFrame++;
                    }
                    break;
                case "s":
                case "S":
                    spriteY = 0;
                    if (y != mapBorderMaxY)
                    {
                        y++;
                        currentFrame++;
                    }
                    break;
                case "d":
                case "D":
                    spriteY = 128;
                    if (x != mapBorderMaxX)
                    {
                        x++;
                        currentFrame++;
                    }
                    break;
            }
        }
    }
}
