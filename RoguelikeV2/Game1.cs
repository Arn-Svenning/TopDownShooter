#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        GamePlayManager game;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.LoadAssets(Content);
            GamePlayManager.LoadGame();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            InputManager.KeyboardGetState();

            if (InputManager.PressOnce(Keys.V))
            {
                Globals.currentGameState = Globals.GameState.editingMap;
            }
            else if (InputManager.PressOnce(Keys.P))
            {
                Globals.currentGameState = Globals.GameState.mainMenu;
            }

            switch (Globals.currentGameState)
            {
                case Globals.GameState.mainMenu:
                    break;

                case Globals.GameState.inGame:
                    break;

                case Globals.GameState.pauseGame:
                    break;

                case Globals.GameState.end:
                    break;

                case Globals.GameState.editingMap:
                    GamePlayManager.UpdateEditor();
                    
                    break;
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
           
            switch (Globals.currentGameState)
            {
                case Globals.GameState.mainMenu:
                    GamePlayManager.DrawWalls(spriteBatch);
                    break;

                case Globals.GameState.inGame:
                    break;

                case Globals.GameState.pauseGame:
                    break;

                case Globals.GameState.end:
                    break;

                case Globals.GameState.editingMap:
                    GamePlayManager.DrawEditor(spriteBatch);                    
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}