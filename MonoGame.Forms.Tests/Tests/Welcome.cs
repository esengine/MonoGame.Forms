﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using MonoGame.Forms.Tests.Utils;

namespace MonoGame.Forms.Tests.Tests
{
    public class Welcome : UpdateWindow
    {
        string WelcomeMessage = "Welcome to MonoGame.Forms!";
        public Animation Logo;
        public bool EditMode = false;
        public int LastFrame = 0;

        protected override void Initialize()
        {
            base.Initialize();

            Logo = new Animation(Editor.Content.Load<Texture2D>("Logo_Sheet"), 10, 10, 0.5f, true, true);
            Editor.BackgroundColor = new Color(20, 19, 40);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            Editor.spriteBatch.Draw(Logo.Texture, new Rectangle(
                       Editor.graphics.Viewport.Width / 2,
                       Editor.graphics.Viewport.Height / 2,
                       Logo.PartSizeX,
                       Logo.PartSizeY),
                       (EditMode ? Logo.GetCurrentFrame() : Logo.DoAnimation()),
                       Logo.GetDrawingColor, 
                       0f, 
                       Logo.GetOrigin, 
                       SpriteEffects.None, 0f);

            Editor.spriteBatch.DrawString(Editor.Font, WelcomeMessage, new Vector2(
                (Editor.graphics.Viewport.Width / 2) - (Editor.Font.MeasureString(WelcomeMessage).X / 2),
                (Editor.graphics.Viewport.Height / 2) - (Editor.Font.MeasureString(WelcomeMessage).Y / 2) + Logo.GetOrigin.Y + 10),
                Color.White);

            Editor.spriteBatch.End();

            Editor.DrawDisplay();
        }
    }
}
