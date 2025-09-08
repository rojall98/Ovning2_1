using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Ö2_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D texture;
        Texture2D texture2;
        Vector2 pos1 = Vector2.Zero;
        Vector2 pos2 = new Vector2(100, 100);
        Vector2[] posArray;

        int stopX;
        int stopY;
        Random rnd;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        } 

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>(@"mau_logo");
            texture2 = Content.Load<Texture2D>(@"mau_logo_trans");

            rnd = new Random();

            stopX = Window.ClientBounds.Width - texture.Width;
            stopY = Window.ClientBounds.Height - texture.Height;

            posArray = new Vector2[3];

            for (int i = 0; i < 3; i++)
            {
                int randX = rnd.Next(0, stopX);
                int randY = rnd.Next(0, stopY);
                Vector2 pos = new Vector2(randX, randY);
                posArray[i] = pos;
            }

            



            pos2.X = Window.ClientBounds.Width / 2 - texture2.Width / 2;
            pos2.Y = Window.ClientBounds.Height / 2 - texture2.Height / 2;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            int stopX = Window.ClientBounds.Width - texture.Width;
            //int stopY2 = Window.ClientBounds.Height - texture.Height;
            int stopY = Window.ClientBounds.Height - texture2.Height;

            if (pos1.X < stopX)
            {
                pos1.X = pos1.X + 2;
                //pos1.Y = pos1.Y +1;
            }
            
            
            if (pos2.Y < stopY)
            {
                pos2.X = pos2.X + 1;
                pos2.Y = pos2.Y + 1;
            }
            

           

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(texture, pos1, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f); 
            spriteBatch.Draw(texture2, pos2, Color.White);

            foreach(var pos in posArray)
            {
                spriteBatch.Draw(texture2, pos, Color.White);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
