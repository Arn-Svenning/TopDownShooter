#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Stationary.StationaryEnemy;
using RoguelikeV2.GameLogic.Stationary.Tiles;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.ParticleEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace RoguelikeV2.Managers
{
    internal class MapManager
    {
        public static List<GameObjects> mapObjects;
        public static List<Player> player1;
        public static List<Player> player2;      
        public static List<EnemyObjects> enemies;
        
        public static MapEditor editor;
        public static DisplayHearts player1HP;
        public static DisplayHearts player2HP;

        public static List<ParticleSystem> deadEnemies = new List<ParticleSystem>();
        public static void LoadMap()
        {
            player1HP = new DisplayHearts(new Rectangle(400, 400, 16, 16), Color.White);
            player2HP = new DisplayHearts(new Rectangle(400, 400, 16, 16), Color.Blue);
            mapObjects = new List<GameObjects>();
            player1 = new List<Player>();
            player2 = new List<Player>();            
            enemies = new List<EnemyObjects>();
            
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
        public static void UpdatePlayer1(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot, GamePadState state)
        {
            player1HP.Update(gameTime, player1);
            foreach (Player p1 in player1)
            {
                p1.Update(gameTime, up, down, right, left, player, shoot, state);
                p1.UpdateScorePos();
            }
            player1.RemoveAll((p1) => p1.isDead);
            
        }

        public static void DrawPlayer1(SpriteBatch spriteBatch)
        {
           
            foreach (Player p1 in player1)
            {
                p1.Draw(spriteBatch);
                p1.DrawScore1(spriteBatch);
            }
            player1HP.Draw(spriteBatch);
        }

        //player2
        public static void UpdatePlayer2(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot, GamePadState state)
        {
            player2HP.Update(gameTime, player2);
            foreach (Player p2 in player2)
            {
                p2.Update(gameTime, up, down, right, left, player, shoot, state);
                p2.UpdateScorePos();
            }
            player2.RemoveAll((p2) => p2.isDead);
        }

        public static void DrawPlayer2(SpriteBatch spriteBatch)
        {            
            foreach (Player p2 in player2)
            {
                p2.Draw(spriteBatch);
                p2.DrawScore2(spriteBatch);
            }
            player2HP.Draw(spriteBatch);
        }

        #endregion

        #region Enemies
        public static void UpdateEnemies(GameTime gameTime)
        {
            foreach(EnemyObjects enemy in enemies)
            {
                enemy.Update(gameTime);                
            }            
            
        }
        public static void DrawEnemies(SpriteBatch spriteBatch)
        {
            foreach(EnemyObjects enemy in enemies)
            {
                enemy.Draw(spriteBatch);
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
        }
        
    }
}
