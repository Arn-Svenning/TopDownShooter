#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion
namespace RoguelikeV2.Managers
{
    internal class GamePlayManager
    {
        public static WeaponSpawner spawner;
        public static void LoadGame(Viewport VIEW, GraphicsDevice DEVICE)
        {
            MapManager.LoadMap();
            CameraManager.LoadCamera(VIEW, DEVICE);
            WeaponSpawnManager spawner = new WeaponSpawnManager();
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

            MapManager.UpdatePlayer1(gameTime, Keys.W, Keys.S, Keys.D, Keys.A, 1, Keys.H, state1);
            ProjectileManager.Update(gameTime, MapManager.enemies, 1);
        }
        public static void DrawPlayer1(SpriteBatch spriteBatch)
        {
            ProjectileManager.Draw(spriteBatch, 1);
            MapManager.DrawPlayer1(spriteBatch);            
        }

        public static void UpdatePlayer2(GameTime gameTime)
        {
            GamePadState state2 = GamePad.GetState(PlayerIndex.Two, GamePadDeadZone.Circular);

            ProjectileManager.Update(gameTime, MapManager.enemies, 2);
            MapManager.UpdatePlayer2(gameTime, Keys.Up, Keys.Down, Keys.Right, Keys.Left, 2, Keys.G, state2);            
        }
        public static void DrawPlayer2(SpriteBatch spriteBatch)
        {
            ProjectileManager.Draw(spriteBatch, 2);
            MapManager.DrawPlayer2(spriteBatch);           
        }
        #endregion

        #region Enemies
        public static void UpdateChasingEnemies(GameTime gameTime) => MapManager.UpdateChasingEnemies(gameTime);

        public static void DrawChasingEnemies(SpriteBatch spriteBatch) => MapManager.DrawChasingEnemies(spriteBatch);

        public static void UpdateNecromancers(GameTime gameTime)
        {
            ProjectileManager.UpdateNecroMancerProjectile(gameTime);
            MapManager.UpdateNecromancers(gameTime);
        }
        public static void DrawNecromancers(SpriteBatch spriteBatch)
        {
            ProjectileManager.DrawNecroMancerProjectile(spriteBatch);
            MapManager.DrawNecromancers(spriteBatch);
        }

        public static void UpdateTurrets(GameTime gameTime)
        {
            MapManager.UpdateTurrets(gameTime);
            ProjectileManager.UpdateTurretProjectile(gameTime);
        }
        public static void DrawTurrets(SpriteBatch spriteBatch)
        {
            MapManager.DrawTurrets(spriteBatch);
            ProjectileManager.DrawTurretProjectile(spriteBatch);
        }
        #region Spawner
        public static void UpdateEnemySpawner(GameTime gameTime) => EnemySpawnManager.UpdateSpawner(gameTime);       
        #endregion
        #endregion
        public static void UpdateWeaponSpawner()
        {

            WeaponSpawnManager.UpdateSpawner();
        }
        public static void DrawWeaponSpawner(SpriteBatch spriteBatch)
        {
            WeaponSpawnManager.DrawSpawner(spriteBatch);
        }
        

        
    }
}
