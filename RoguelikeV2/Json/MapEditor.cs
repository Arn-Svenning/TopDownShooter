#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic;
using RoguelikeV2.GameLogic.Stationary;
using RoguelikeV2.Managers;
using System.Collections.Generic;
#endregion

namespace RoguelikeV2.Json
{
    internal class MapEditor
    {
        private List<GameObjects> gameObjectList;

        private bool isSaved;
        public bool IsSaved { get { return isSaved; } }

        private const int tileSize = 64;        

        public MapEditor()
        {
            gameObjectList = new List<GameObjects>();
            isSaved = false;
        }
        public void Update()
        {
            InputManager.UpdateInput();
            InputManager.KeyboardGetState();
            InputManager.MouseGetState();

            int x = (InputManager.CurrentMouse.X / tileSize) * tileSize;
            int y = (InputManager.CurrentMouse.Y / tileSize) * tileSize;

            if(InputManager.PressOnce(Keys.W))
            {
                Wall w = new Wall(new Rectangle(x, y, tileSize, tileSize), AssetManager.regularWall);
                gameObjectList.Add(w);
            }
            if(InputManager.PressOnce(Keys.S))
            {
                JsonParser.WriteJsonToFile("level_1.json", gameObjectList);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GameObjects obj in gameObjectList)
            {
                obj.Draw(spriteBatch);
            }
        }
    }
}
