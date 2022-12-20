#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion
namespace RoguelikeV2.Managers
{
    internal class GamePlayManager
    {        
        public static void LoadGame(Viewport VIEW)
        {
            MapManager.LoadMap();
            CameraManager.LoadCamera(VIEW);
        }
        #region MapEditor
        public static void UpdateEditor() => MapManager.UpdateMapEditor();
        public static void DrawEditor(SpriteBatch spriteBatch) => MapManager.DrawMapEditor(spriteBatch);
        #endregion

        #region Camera
        public static void UpdateEditorCamera(GameTime gameTime) => CameraManager.UpdateEditorCamera(gameTime);
        
        public static void UpdateSplitScreenCamera() => CameraManager.UpdateSplitScreenCamera();
        #endregion

        #region Tiles
        public static void DrawMap(SpriteBatch spriteBatch) => MapManager.DrawMap(spriteBatch);
        #endregion

        #region Players
        public static void UpdatePlayer1(GameTime gameTime)
        {
            MapManager.UpdatePlayer1(gameTime, Keys.W, Keys.S, Keys.D, Keys.A, 1, Keys.H);
            ProjectileManager.Update(gameTime);
        }
        public static void DrawPlayer1(SpriteBatch spriteBatch)
        {
            ProjectileManager.Draw(spriteBatch);
            MapManager.DrawPlayer1(spriteBatch);            
        }

        public static void UpdatePlayer2(GameTime gameTime)
        {
            ProjectileManager.Update(gameTime);
            MapManager.UpdatePlayer2(gameTime, Keys.Up, Keys.Down, Keys.Right, Keys.Left, 2, Keys.G);            
        }
        public static void DrawPlayer2(SpriteBatch spriteBatch)
        {
            ProjectileManager.Draw(spriteBatch);
            MapManager.DrawPlayer2(spriteBatch);           
        }
        #endregion

        #region Enemies
        public static void UpdateChasingEnemies(GameTime gameTime) => MapManager.UpdateChasingEnemies(gameTime);

        public static void DrawChasingEnemies(SpriteBatch spriteBatch) => MapManager.DrawChasingEnemies(spriteBatch);

        public static void UpdateNecromancers(GameTime gameTime)
        {
            ProjectileManager.UpdateNecromancerProjectile(gameTime);
            MapManager.UpdateNecromancers(gameTime);
        }

        public static void DrawNecromancers(SpriteBatch spriteBatch)
        {
            ProjectileManager.DrawNecroMancerProjectile(spriteBatch);
            MapManager.DrawNecromancers(spriteBatch);
        }
        #endregion
    }
}
