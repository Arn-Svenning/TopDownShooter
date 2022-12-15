#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Moving;
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
        public static List<Wall> regularWalls;
        public static List<Floor> floorList;
        public static Player player1;

        private static MapEditor editor;

        public static void LoadMap()
        {                        
            regularWalls = new List<Wall>();
            floorList = new List<Floor>();            
            ReadFromFile("level_1.json");
            editor = new MapEditor();
        }
        #region MapEditor
                      
        public static void DrawMapEditor(SpriteBatch spriteBatch) => editor.Draw(spriteBatch);
        public static void UpdateMapEditor() => editor.Update();
        #endregion

        #region Tiles
       
        public static void DrawMap(SpriteBatch spriteBatch)
        {
            foreach (Wall wall in regularWalls)
            {
                wall.Draw(spriteBatch);
            }
            foreach(Floor floor in floorList)
            {
                floor.Draw(spriteBatch);
            }
        }

        #endregion

        #region Players

        public static void UpdatePlayer1(GameTime gameTime) => player1.Update(gameTime);

        public static void DrawPlayer1(SpriteBatch spriteBatch) => player1.Draw(spriteBatch);

        #endregion

        private static void ReadFromFile(string fileName)
        {
            //wall
            List<Rectangle> wallRects = JsonParser.GetRectangleList(fileName, "walls");
            foreach (Rectangle rect in wallRects)
            {
                Wall w = new Wall(rect, AssetManager.regularWall);
                regularWalls.Add(w);
            }

            //floor
            List<Rectangle> floorRects = JsonParser.GetRectangleList(fileName, "floor");
            foreach (Rectangle rect in floorRects)
            {
                Floor f = new Floor(rect, AssetManager.regularFloor);
                floorList.Add(f);
            }

            //players
            Rectangle playerRect = JsonParser.GetRectangle(fileName, "player1");
            player1 = new Player(playerRect);
        }
        
    }
}
