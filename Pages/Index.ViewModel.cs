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
        int motion;

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
                    y--;
                    currentFrame++;
                    if (y < 0)
                    {
                        y = mapBorderMaxY;
                    }
                    break;
                case "a":
                case "A":
                    spriteY = 64;
                    x--;
                    currentFrame++;
                    if (x < 0)
                    {
                        x = mapBorderMaxX;
                    }
                    break;
                case "s":
                case "S":
                    spriteY = 0;
                    y++;
                    currentFrame++;
                    if (y > mapBorderMaxY)
                    {
                        y = 0;
                    }
                    break;
                case "d":
                case "D":
                    spriteY = 128;
                    x++;
                    currentFrame++;
                    if (x > mapBorderMaxX)
                    {
                        x = 0;
                    }
                    break;
            }
        }
    }
}
