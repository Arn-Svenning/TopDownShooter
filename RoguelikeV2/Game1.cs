#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
      
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
            GamePlayManager.LoadGame(GraphicsDevice.Viewport);
            #region SplitScreen
            CameraManager.defaultView = GraphicsDevice.Viewport;
            CameraManager.leftView = CameraManager.defaultView;
            CameraManager.rightView = CameraManager.defaultView;
            CameraManager.leftView.Width = CameraManager.leftView.Width / 2;
            CameraManager.rightView.Width = CameraManager.rightView.Width / 2;
            CameraManager.rightView.X = CameraManager.leftView.Width;
            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            InputManager.KeyboardGetState();
            
            if (InputManager.PressOnce(Keys.E))
            {
                Globals.currentGameState = Globals.GameState.editingMap;
            }
            if (InputManager.PressOnce(Keys.P))
            {
                Globals.currentGameState = Globals.GameState.mainMenu;
            }

            switch (Globals.currentGameState)
            {
                case Globals.GameState.mainMenu:
                    GamePlayManager.UpdateSplitScreenCamera();
                    GamePlayManager.UpdatePlayer1(gameTime);
                    GamePlayManager.UpdatePlayer2(gameTime);
                    GamePlayManager.UpdateChasingEnemies(gameTime);
                    break;

                case Globals.GameState.inGame:
                    break;

                case Globals.GameState.pauseGame:
                    break;

                case Globals.GameState.end:
                    break;

                case Globals.GameState.editingMap:
                    Window.Title = "EDITOR: " + "Is Saved: " + MapEditor.IsSaved;
                    GamePlayManager.UpdateEditor();
                    GamePlayManager.UpdateEditorCamera(gameTime);
                   
                    break;
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

           
            
            switch (Globals.currentGameState)
            {
                case Globals.GameState.mainMenu:

                    GraphicsDevice.Viewport = CameraManager.leftView;
                    DrawWithSplitScreenCamera(CameraManager.splitScreenCamera1);
                    GraphicsDevice.Viewport = CameraManager.rightView;
                    DrawWithSplitScreenCamera(CameraManager.splitScreenCamera2);

                    GraphicsDevice.Viewport = CameraManager.defaultView;

                    spriteBatch.Begin();
                    spriteBatch.Draw(AssetManager.pillar, new Vector2(Globals.screenWidth / 2 - 5, 0), Color.White);
                    spriteBatch.End();

                    break;

                case Globals.GameState.inGame:
                    break;

                case Globals.GameState.pauseGame:
                    break;

                case Globals.GameState.end:
                    break;

                case Globals.GameState.editingMap:

                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, CameraManager.editorCamera.Transform);
                    GamePlayManager.DrawEditor(spriteBatch);
                    spriteBatch.End();
                    break;
            }
           
            base.Draw(gameTime);
        }
        private void DrawWithSplitScreenCamera(SplitScreenCamera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            GamePlayManager.DrawMap(spriteBatch);
            GamePlayManager.DrawChasingEnemies(spriteBatch);
            GamePlayManager.DrawPlayer1(spriteBatch);
            GamePlayManager.DrawPlayer2(spriteBatch);

            spriteBatch.End();
        }
    }
}