#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.Managers.Scores;
using SharpDX.DirectWrite;
using SharpDX.MediaFoundation.DirectX;
using System.Linq;
using Color = Microsoft.Xna.Framework.Color;
#endregion
namespace RoguelikeV2.Managers
{
    internal class GamePlayManager
    {
        public static WeaponSpawner spawner;

        public static ScoreManager1 scores1;
        public static ScoreManager2 scores2;
        public static void LoadGame(Viewport VIEW, GraphicsDevice DEVICE)
        {
            MapManager.LoadMap();
            CameraManager.LoadCamera(VIEW, DEVICE);
            WeaponSpawnManager spawner = new WeaponSpawnManager();
            scores1 = ScoreManager1.Load();
            scores2 = ScoreManager2.Load();
        }
        #region MapEditor
        public static void UpdateEditor() => MapManager.UpdateMapEditor();
        public static void DrawEditor(SpriteBatch spriteBatch) => MapManager.DrawMapEditor(spriteBatch);
        #endregion

        #region Camera
        public static void UpdateEditorCamera(GameTime gameTime) => CameraManager.UpdateEditorCamera(gameTime);
        
        public static void UpdateSplitScreenCamera() => CameraManager.UpdateSplitScreenCamera();

        public static void UpdateOnePlayerCamera() => CameraManager.UpdateOnePlayerCamera();
        #endregion

        #region Tiles
        public static void DrawMap(SpriteBatch spriteBatch) => MapManager.DrawMap(spriteBatch);
        #endregion

        #region Players
        public static void UpdatePlayer1(GameTime gameTime)
        {
            GamePadState state1 = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);

            MapManager.UpdatePlayer1(gameTime, Keys.W, Keys.S, Keys.D, Keys.A, 1, Keys.R, state1);
            ProjectileManager.Update(gameTime, 1);
        }
        public static void DrawPlayer1(SpriteBatch spriteBatch)
        {
            ProjectileManager.Draw(spriteBatch, 1);
            MapManager.DrawPlayer1(spriteBatch);            
        }

        public static void UpdatePlayer2(GameTime gameTime)
        {
            GamePadState state2 = GamePad.GetState(PlayerIndex.Two, GamePadDeadZone.Circular);

            ProjectileManager.Update(gameTime, 2);
            MapManager.UpdatePlayer2(gameTime, Keys.Up, Keys.Down, Keys.Right, Keys.Left, 2, Keys.M, state2);            
        }
        public static void DrawPlayer2(SpriteBatch spriteBatch)
        {
            ProjectileManager.Draw(spriteBatch, 2);
            MapManager.DrawPlayer2(spriteBatch);           
        }
        public static void LooseGame(GameTime gameTime)
        {            
             if (Globals.currentGameState == Globals.GameState.inGame1Player)
             {
                Globals.SurviveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (MapManager.player1.Count == 0)
                {
                    Globals.currentGameState = Globals.GameState.end;
                }
             }
            else if (Globals.currentGameState == Globals.GameState.inGame2Player)
            {
                Globals.SurviveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (MapManager.player1.Count == 0 && MapManager.player2.Count == 0)
                {
                    Globals.currentGameState = Globals.GameState.end2;
                }                
            }
           
        }
        #endregion

        #region Enemies
        public static void UpdateEnemies(GameTime gameTime)
        {
            ProjectileManager.UpdateTurretProjectile(gameTime);
            ProjectileManager.UpdateNecroMancerProjectile(gameTime);
            MapManager.UpdateEnemies(gameTime);
        }

        public static void DrawEnemies(SpriteBatch spriteBatch)
        {
            ProjectileManager.DrawTurretProjectile(spriteBatch);
            ProjectileManager.DrawNecroMancerProjectile(spriteBatch);
            MapManager.DrawEnemies(spriteBatch);
        }       
        #region Spawner
        public static void UpdateEnemySpawner(GameTime gameTime) => EnemySpawnManager.UpdateSpawner(gameTime);
        #endregion
        #endregion

        #region WeaponSpawner
        public static void UpdateWeaponSpawner()
        {

            WeaponSpawnManager.UpdateSpawner();
        }
        public static void DrawWeaponSpawner(SpriteBatch spriteBatch)
        {
            WeaponSpawnManager.DrawSpawner(spriteBatch);
        }
        #endregion
        #region Scores
         
        public static void UpdateScore2Player()
        {
            if (Globals.scoreTimer <= 0)
            {
                scores1.Add(new ScoreProperties()
                {
                    PlayerName = "Player 1",
                    Value = Player.Score1,
                }
                );
                ScoreManager1.Save(scores1);

                
                
                    scores2.Add(new ScoreProperties()
                    {
                        PlayerName = "Player 2",
                        Value = Player.Score2,
                    }
                    );
                    ScoreManager2.Save(scores2);
                    Globals.scoreTimer = 5;
                
            }
        }
        public static void UpdateScore1Player()
        {
            if (Globals.scoreTimer <= 0)
            {               
                scores1.Add(new ScoreProperties()
                {
                        PlayerName = "Player 1",
                        Value = Player.Score1,
                }
                );
                ScoreManager1.Save(scores1);
                Globals.scoreTimer = 5;
                
            }
        }
        public static void DrawScore2Player(SpriteBatch spriteBatch)
        {
            ///Player1
            spriteBatch.DrawString(AssetManager.minecraftFont, "PLAYER 1 SCORE WAS: " + Player.Score1, new Vector2(1100, Globals.screenHeight / 2 + 150), Color.Black, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 1);
            spriteBatch.DrawString(AssetManager.minecraftFont, "Highscores player 1:\n" + string.Join("\n", 
                scores1.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(1100, Globals.screenHeight / 2 + 200), Color.Black);

            ///Player2
            spriteBatch.DrawString(AssetManager.minecraftFont, "PLAYER 2 SCORE WAS: " + Player.Score2, new Vector2(500, Globals.screenHeight / 2 + 150), Color.Black, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 1);
            spriteBatch.DrawString(AssetManager.minecraftFont, "Highscores player2:\n" + string.Join("\n",
                scores2.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(500, Globals.screenHeight / 2 + 200), Color.Black);
        }       
        public static void DrawScore1Player(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(AssetManager.minecraftFont, "YOUR SCORE WAS: " + Player.Score1, new Vector2(Globals.screenWidth / 2 - 100, Globals.screenHeight / 2 + 150), Color.Black, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 1);
            spriteBatch.DrawString(AssetManager.minecraftFont, "Highscores player 1:\n" + string.Join("\n",
                 scores1.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(Globals.screenWidth / 2 - 100, Globals.screenHeight / 2 + 200), Color.Black);
        }
        #endregion

    }
}
