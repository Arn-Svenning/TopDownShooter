#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Stationary.Tiles;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
using System.Collections.Generic;
#endregion

namespace RoguelikeV2.Managers
{
    internal class MapManager
    {
        public static List<GameObjects> mapObjects;
        public static List<Player> player1;
        public static List<Player> player2;
        public static List<ChasingEnemy> chasingEnemies;

        private static MapEditor editor;

        public static void LoadMap()
        {                               
            mapObjects = new List<GameObjects>();
            player1 = new List<Player>();
            player2 = new List<Player>();
            chasingEnemies = new List<ChasingEnemy>();
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
           
            foreach(GameObjects obj in mapObjects)
            {
                obj.Draw(spriteBatch);
            }
        }

        #endregion

        #region Players
        //player1
        public static void UpdatePlayer1(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot)
        {
            foreach(Player p1 in player1)
            {
                p1.Update(gameTime, up, down, right, left, player, shoot);
            }
        }

        public static void DrawPlayer1(SpriteBatch spriteBatch)
        {
            foreach(Player p1 in player1)
            {
                p1.Draw(spriteBatch);
            }
        }

        //player2
        public static void UpdatePlayer2(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot)
        {
            foreach(Player p2 in player2)
            {
                p2.Update(gameTime, up, down, right, left, player, shoot);
            }
        }

        public static void DrawPlayer2(SpriteBatch spriteBatch)
        {
            foreach(Player p2 in player2)
            {
                p2.Draw(spriteBatch);
            }
        }

        #endregion

        #region Enemies
        public static void UpdateChasingEnemies(GameTime gameTime)
        {
            foreach(ChasingEnemy chasing in chasingEnemies)
            {
                chasing.Update(gameTime);
            }
        }
        public static void DrawChasingEnemies(SpriteBatch spriteBatch)
        {
            foreach(ChasingEnemy chasing in chasingEnemies)
            {
                chasing.Draw(spriteBatch);
            }
        }
        #endregion

        private static void ReadFromFile(string fileName)
        {
           
            //wall
            List<Rectangle> wallRects = JsonParser.GetRectangleList(fileName, "walls");
            foreach (Rectangle rect in wallRects)
            {
                Wall w = new Wall(rect, AssetManager.regularWall);
                mapObjects.Add(w);
            }

            //floor
            List<Rectangle> floorRects = JsonParser.GetRectangleList(fileName, "floor");
            foreach (Rectangle rect in floorRects)
            {
                Floor f = new Floor(rect, AssetManager.regularFloor);
                mapObjects.Add(f);
            }

            ////player1          
            List<Rectangle> player1Rect = JsonParser.GetRectangleList(fileName, "player1");
            foreach (Rectangle rect in player1Rect)
            {
                Player p = new Player(rect);
                player1.Add(p);
            }

            ////player2
            List<Rectangle> player2Rect = JsonParser.GetRectangleList(fileName, "player2");
            foreach (Rectangle rect in player2Rect)
            {
                Player p = new Player(rect);
                player2.Add(p);
            }

            //chasingEnemies
            List<Rectangle> chasingEnemyRect = JsonParser.GetRectangleList(fileName, "chasingEnemies");
            foreach (Rectangle rect in chasingEnemyRect)
            {
                ChasingEnemy c = new ChasingEnemy(rect);
                chasingEnemies.Add(c);
            }


        }
        
    }
}
