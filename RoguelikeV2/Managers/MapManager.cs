#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Stationary;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
using System.Collections.Generic;
#endregion

namespace RoguelikeV2.Managers
{
    internal class MapManager
    {
        private static List<Wall> regularWalls;

        private static MapEditor editor;

        public static void LoadMap()
        {            
            editor = new MapEditor();
            regularWalls = new List<Wall>();
            ReadFromFile("level_1.json");
        }
        #region MapEditor
               
       
        public static void DrawMapEditor(SpriteBatch spriteBatch) => editor.Draw(spriteBatch);
        public static void UpdateMapEditor() => editor.Update();
        #endregion

        #region Map
       
        public static void DrawWalls(SpriteBatch spriteBatch)
        {
            foreach (Wall wall in regularWalls)
            {
                wall.Draw(spriteBatch);
            }
        }

        #endregion
       
        private static void ReadFromFile(string fileName)
        {
            List<Rectangle> wallRects = JsonParser.GetRectangleList(fileName, "walls");
            foreach (Rectangle rect in wallRects)
            {
                Wall w = new Wall(rect, AssetManager.regularWall);
                regularWalls.Add(w);
            }
        }
        
    }
}
