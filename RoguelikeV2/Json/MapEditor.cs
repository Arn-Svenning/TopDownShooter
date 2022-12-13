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
            //int X = (int)CameraManager.editorCamera.NewCenter.X;
            //int Y = (int)CameraManager.editorCamera.NewCenter.Y;

            int x = (InputManager.CurrentMouse.X / tileSize) * tileSize + (int)CameraManager.editorCamera.FirstCentre.X;
            int y = (InputManager.CurrentMouse.Y / tileSize) * tileSize + (int)CameraManager.editorCamera.FirstCentre.Y;
                       


            if (InputManager.PressOnce(Keys.W))
            {
                Wall w = new Wall(new Rectangle(x, y, tileSize, tileSize), AssetManager.regularWall);
                gameObjectList.Add(w);
            }
            else if (InputManager.PressOnce(Keys.S))
            {
                JsonParser.WriteJsonToFile("level_1.json", gameObjectList);
                isSaved = true;
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
