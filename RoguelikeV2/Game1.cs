#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.Menus;
using RoguelikeV2.ParticleEngine;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
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
            this.Components.Add(new MainMenu(this));
            base.Initialize();

        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.LoadAssets(Content);
           
            GamePlayManager.LoadGame(GraphicsDevice.Viewport, GraphicsDevice);
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
            if (Globals.exitGame || InputManager.PressOnce(Keys.Escape)) this.Exit();

            InputManager.KeyboardGetState();
            InputManager.GamePadStateGetState();
            InputManager.GamePadStateGetState2();
            
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

                    MainMenu.UpdateMenu();
                    break;

                case Globals.GameState.inGame1Player:
                    GamePlayManager.UpdateOnePlayerCamera();                   
                    GamePlayManager.UpdateEnemies(gameTime);                    
                    GamePlayManager.UpdatePlayer1(gameTime);
                    GamePlayManager.UpdateWeaponSpawner();
                    GamePlayManager.UpdateEnemySpawner(gameTime);                    
                    break;

                case Globals.GameState.inGame2Player:
                    GamePlayManager.UpdateSplitScreenCamera();
                    GamePlayManager.UpdatePlayer1(gameTime);
                    GamePlayManager.UpdatePlayer2(gameTime);
                    GamePlayManager.UpdateEnemies(gameTime);                    
                    GamePlayManager.UpdateWeaponSpawner();
                    GamePlayManager.UpdateEnemySpawner(gameTime);
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
            DrawRenderTargetLayer();
            GraphicsDevice.Clear(Color.CornflowerBlue);

           
            
            switch (Globals.currentGameState)
            {
                case Globals.GameState.mainMenu:

                    MainMenu.DrawBackground(spriteBatch);

                    break;

                case Globals.GameState.inGame1Player:

                   
                    DrawOnePlayerCamera(CameraManager.onePlayer);
                    
                    break;

                case Globals.GameState.inGame2Player:

                    GraphicsDevice.Viewport = CameraManager.leftView;
                    
                    DrawWithSplitScreenCamera(CameraManager.splitScreenCamera1);
 
                    GraphicsDevice.Viewport = CameraManager.rightView;
                    DrawWithSplitScreenCamera(CameraManager.splitScreenCamera2);                   

                    GraphicsDevice.Viewport = CameraManager.defaultView;

                    spriteBatch.Begin();
                    spriteBatch.Draw(AssetManager.pillar, new Vector2(Globals.screenWidth / 2 - 5, 0), Color.White);
                    CameraManager.viewSize = new Rectangle(Globals.screenWidth / 2 - 200, Globals.screenHeight / 5 - 220, 400, 220);
                    CameraManager.DrawMiniMap(spriteBatch);
                    spriteBatch.End();
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
            GamePlayManager.DrawEnemies(spriteBatch);
            GamePlayManager.DrawPlayer1(spriteBatch);
            GamePlayManager.DrawPlayer2(spriteBatch);
            GamePlayManager.DrawWeaponSpawner(spriteBatch);
            
            spriteBatch.End();
        }
        private void DrawOnePlayerCamera(OnePlayerCamera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            GamePlayManager.DrawMap(spriteBatch);           
            GamePlayManager.DrawEnemies(spriteBatch);            
            GamePlayManager.DrawPlayer1(spriteBatch);
            GamePlayManager.DrawWeaponSpawner(spriteBatch);            
            CameraManager.DrawMiniMap(spriteBatch);   
          
            spriteBatch.End();
        }
        private void DrawRenderTargetLayer()
        {
            // skapa ny spriteBatch
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            // sätt till annat renderTarget
            GraphicsDevice.SetRenderTarget(CameraManager.miniMap);
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            GamePlayManager.DrawMap(spriteBatch);
            GamePlayManager.DrawPlayer1(spriteBatch);
            GamePlayManager.DrawPlayer2(spriteBatch);
            GamePlayManager.DrawWeaponSpawner(spriteBatch);
            spriteBatch.End();
            // Sätt tillbaka graphicsDevice till ordinarie fönster
            GraphicsDevice.SetRenderTarget(null);
        }

    }
}