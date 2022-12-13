#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic;
using RoguelikeV2.GameLogic.Stationary;
using RoguelikeV2.Managers;
using SharpDX.DirectWrite;
using System.Collections.Generic;
#endregion

namespace RoguelikeV2.Json
{
    internal class MapEditor
    {
        private List<GameObjects> gameObjectList;

        private static bool isSaved;
        public static bool IsSaved { get { return isSaved; } }

        private const int tileSize = 64;

        public MapEditor()
        {            
            gameObjectList = new List<GameObjects>();
            foreach(Wall walls in MapManager.regularWalls)
            {
                gameObjectList.Add(walls);
            }
            isSaved = false;
        }
        public void Update()
        {
           
            InputManager.MouseGetState();
           
            int x = (InputManager.CurrentMouse.X / tileSize) * tileSize + (int)CameraManager.editorCamera.FirstCentre.X;
            int y = (InputManager.CurrentMouse.Y / tileSize) * tileSize + (int)CameraManager.editorCamera.FirstCentre.Y;
            Rectangle rect = new Rectangle(x, y, tileSize, tileSize);           
            

            if (InputManager.PressOnce(Keys.W))
            {
                Wall w = new Wall(rect, AssetManager.regularWall);
                gameObjectList.Add(w);
            }
            else if (InputManager.PressOnce(Keys.S))
            {
                JsonParser.WriteJsonToFile("level_1.json", gameObjectList);
                isSaved = true;
            }

            for (int i = gameObjectList.Count - 1; i >= 0; i--)
            {
                
                if (gameObjectList[i].Size.Contains((InputManager.CurrentMouse.X / tileSize) * tileSize + (int)CameraManager.editorCamera.FirstCentre.X, 
                    (InputManager.CurrentMouse.Y / tileSize) * tileSize + (int)CameraManager.editorCamera.FirstCentre.Y) && InputManager.PressOnce(Keys.X))
                {

                    gameObjectList.Remove(gameObjectList[i]);

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObjects obj in gameObjectList)
            {
                obj.Draw(spriteBatch);
            }
        }
    }
}
