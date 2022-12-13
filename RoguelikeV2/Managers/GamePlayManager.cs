﻿#region Using...
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
        public static void LoadGame(GameWindow WINDOW)
        {
            MapManager.LoadMap();
            CameraManager.LoadCamera(WINDOW);
        }
        #region MapEditor
        public static void UpdateEditor() => MapManager.UpdateMapEditor();
        public static void DrawEditor(SpriteBatch spriteBatch) => MapManager.DrawMapEditor(spriteBatch);
        #endregion
        #region
        public static void UpdateEditorCamera(GameTime gameTime) => CameraManager.UpdateEditorCamera(gameTime);
        #endregion

        #region Walls
        public static void DrawWalls(SpriteBatch spriteBatch) => MapManager.DrawWalls(spriteBatch);
        #endregion
    }
}
