using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TESTES
{
    public class Game1 : Game
    {
        public static int screenWidth = 1280;
        public static int screenHeight = 720;
        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;
        Player player;
        Ground ground;
      
        List<Objetos> objetos = new List<Objetos>();
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            ground = new Ground(Content.Load<Texture2D>("New Piskel"), new Vector2(0, screenHeight - 100), 100, screenWidth);
            player = new Player(Content.Load<Texture2D>("NUGGY"), new Vector2(screenWidth / 4 - 35, screenHeight / 2 - 35));
            objetos.Add(ground);
        }



        protected override void Update(GameTime gameTime)
        {
            double deltaTime = gameTime.ElapsedGameTime.TotalSeconds;

            player.Update(deltaTime, objetos);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            ground.Draw(spriteBatch);
            player.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }






    }
}