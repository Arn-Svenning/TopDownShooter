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

        public static void LoadMap()
        {                               
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
            foreach(Player p1 in player1)
            {
                p1.Update(gameTime, up, down, right, left, player, shoot, state);
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
        public static void UpdatePlayer2(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot, GamePadState state)
        {
            foreach(Player p2 in player2)
            {
                p2.Update(gameTime, up, down, right, left, player, shoot, state);
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
            foreach(EnemyObjects enemy in enemies)
            {
                if(enemy is ChasingEnemy)
                    enemy.Update(gameTime);               
            }            
            
        }
        public static void DrawChasingEnemies(SpriteBatch spriteBatch)
        {
            foreach(EnemyObjects enemy in enemies)
            {
                if (enemy is ChasingEnemy)
                    enemy.Draw(spriteBatch);
            }           
        }
        public static void UpdateNecromancers(GameTime gameTime)
        {
            foreach (EnemyObjects enemy in enemies)
            {
                if (enemy is Necromancer)
                    enemy.Update(gameTime);
            }
        }
        public static void DrawNecromancers(SpriteBatch spriteBatch)
        {
            foreach (EnemyObjects enemy in enemies)
            {
                if (enemy is Necromancer)
                    enemy.Draw(spriteBatch);
            }
        }
        public static void UpdateTurrets(GameTime gameTime)
        {
            foreach(EnemyObjects enemy in enemies)
            {
                if (enemy is TurretEnemy)
                    enemy.Update(gameTime);
            }
        }
        public static void DrawTurrets(SpriteBatch spriteBatch)
        {
            foreach(EnemyObjects enemy in enemies)
            {
                if (enemy is TurretEnemy)
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

            //chasingEnemies
            List<Rectangle> chasingEnemyRect = JsonParser.GetRectangleList(fileName, "chasingEnemies");
            foreach (Rectangle rect in chasingEnemyRect)
            {
                ChasingEnemy c = new ChasingEnemy(rect);
                enemies.Add(c);
            }
            //necromancer
            List<Rectangle> necromancerRect = JsonParser.GetRectangleList(fileName, "necromancer");
            foreach (Rectangle rect in necromancerRect)
            {
                Necromancer n = new Necromancer(rect);
                enemies.Add(n);
            }
            //turrets
            List<Rectangle> turretRect = JsonParser.GetRectangleList(fileName, "turret");
            foreach (Rectangle rect in turretRect)
            {
                TurretEnemy n = new TurretEnemy(rect);
                enemies.Add(n);
            }

        }
        
    }
}
