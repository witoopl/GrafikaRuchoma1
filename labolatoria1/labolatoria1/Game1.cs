using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using labolatoria1.GameObjects;
using System.Collections.Generic;

namespace labolatoria1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, numbers, question;
        List<GameSurface> listOfNumbers = new List<GameSurface>();
        List<GameSurface> questionSufraceList = new List<GameSurface>();
        GameSurface defaultMarket;
        PointerStateGamer virtualMouse = new PointerStateGamer();
        int fokin = 0;
        bool wasPressed = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            IsMouseVisible = true;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>(@"background");
            numbers = Content.Load<Texture2D>(@"numbers");
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Rectangle singleNumber = new Rectangle(i * 100, j * 100, 100, 100);
                    Texture2D singleNumberTexture = new Texture2D(GraphicsDevice, 100, 100);
                    Color[] data = new Color[singleNumber.Width * singleNumber.Height];
                    numbers.GetData(0, singleNumber, data, 0, data.Length);
                    singleNumberTexture.SetData(data);
                    listOfNumbers.Add(new GameSurface(singleNumberTexture, new Vector2(0, 0),new Vector2(40,40)));
                }

            }
            var count = 120;
            foreach (var number in listOfNumbers)
            {
                number.position = new Vector2(20,count);
                count += 30;
            }

            question = Content.Load<Texture2D>(@"question");

            for (int i = 200; i < 50 * 10 + 200; i += 50)
                for (int j = 50; j < 50 * 10 + 50; j += 50)
                {
                    questionSufraceList.Add(new GameSurface(question, new Vector2(i,j), new Vector2(50,50)));
                }
            defaultMarket = new GameSurface(question, new Vector2(20, 20), new Vector2(80, 80));

            virtualMouse.objectTexture = question;
        }

        // TODO: use this.Content to load your game content here


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            virtualMouse.position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                    foreach (var number in listOfNumbers)
                        if (number.IsMouseOver(virtualMouse))
                            virtualMouse.objectTexture = number.objectTexture;
                    foreach (var question in questionSufraceList)
                        if (question.IsMouseOver(virtualMouse))
                            question.objectTexture = virtualMouse.objectTexture;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !wasPressed)
            {
                foreach (var question in questionSufraceList)
                    if (question.IsMouseOver(virtualMouse) && question.objectTexture == virtualMouse.objectTexture)
                        question.Rotation += (float)MathHelper.Pi / 2;
                wasPressed = true;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
                wasPressed = false;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(defaultMarket.objectTexture,new Rectangle((int)defaultMarket.position.X,(int)defaultMarket.position.Y,(int)defaultMarket.Size.X,(int)defaultMarket.Size.Y), Color.White);
            fokin = 0;
            foreach (var number in listOfNumbers)
            {
                spriteBatch.Draw(number.objectTexture,
                    new Rectangle((int)number.position.X, (int)number.position.Y, (int)number.Size.X, (int)number.Size.Y),
                    null, Color.White,number.Rotation,new Vector2(0,0),SpriteEffects.None,0);
                fokin++;
            }
            foreach (var area in questionSufraceList)
            {
                spriteBatch.Draw(area.objectTexture, new Rectangle((int)area.position.X, (int)area.position.Y, (int)area.Size.X, (int)area.Size.Y), null, Color.White, area.Rotation, new Vector2(area.Size.X, area.Size.Y), SpriteEffects.None, 0);
            }

            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}
