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
        #endregion

        #region Tiles
        public static void DrawMap(SpriteBatch spriteBatch) => MapManager.DrawMap(spriteBatch);
        #endregion

        #region Players
        public static void UpdatePlayer1(GameTime gameTime) => MapManager.UpdatePlayer1(gameTime);
        public static void DrawPlayer1(SpriteBatch spriteBatch) => MapManager.DrawPlayer1(spriteBatch);
        #endregion
    }
}
