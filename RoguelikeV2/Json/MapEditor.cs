#region Using...
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic;
using RoguelikeV2.Managers;
using SharpDX.DirectWrite;
using System.Collections.Generic;
using System.Diagnostics;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Stationary.Tiles;
#endregion

namespace RoguelikeV2.Json
{
    internal class MapEditor
    {
       
        private static bool isSaved;
        public static bool IsSaved { get { return isSaved; } }

        private const int tileSize = 64;

        public MapEditor()
        {          
            foreach (Player p2 in MapManager.player2)
            {
                MapManager.mapObjects.Add(p2);
            }
           
            isSaved = false;
        }
        public void Update()
        {
           
            InputManager.MouseGetState();
           
            int x = (InputManager.CurrentMouse.X / tileSize) * tileSize + (int)CameraManager.editorCamera.Centre.X;
            int y = (InputManager.CurrentMouse.Y / tileSize) * tileSize + (int)CameraManager.editorCamera.Centre.Y;
            Rectangle rect = new Rectangle(x, y, tileSize, tileSize);           
            

            if (InputManager.PressOnce(Keys.W))
            {
                Wall w = new Wall(rect, AssetManager.regularWall);
                MapManager.mapObjects.Add(w);
               
            }
            else if(InputManager.PressOnce(Keys.F))
            {
                Floor f = new Floor(rect, AssetManager.regularFloor);
                MapManager.mapObjects.Add(f);
            }

            else if (InputManager.PressOnce(Keys.S))
            {
                JsonParser.WriteJsonToFile("level_1.json", MapManager.mapObjects);
                isSaved = true;
            }

            for (int i = MapManager.mapObjects.Count - 1; i >= 0; i--)
            {
                
                if (MapManager.mapObjects[i].Size.Contains((InputManager.CurrentMouse.X / tileSize) * tileSize + (int)CameraManager.editorCamera.Centre.X, 
                    (InputManager.CurrentMouse.Y / tileSize) * tileSize + (int)CameraManager.editorCamera.Centre.Y) && InputManager.PressOnce(Keys.X))
                {

                    MapManager.mapObjects.Remove(MapManager.mapObjects[i]);

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GameObjects obj in MapManager.mapObjects)
            {
                obj.Draw(spriteBatch);
            }
            foreach (Player p1 in MapManager.player1)
            {
                p1.Draw(spriteBatch);
            }
        }
    }
}
