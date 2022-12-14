#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic;
using System;
using System.Collections.Generic;
#endregion

namespace RoguelikeV2.Managers
{
    internal class AssetManager
    {
        //players
        public static Texture2D playerTex;

        //walls
        public static Texture2D regularWall;

        //floor
        public static Texture2D regularFloor;

        public static Texture2D test;
        public static void LoadAssets(ContentManager Content)
        {
            //player
            playerTex = Content.Load<Texture2D>("Moving/Players/player");

            //walls
            regularWall = Content.Load<Texture2D>("Stationary/Walls/Wall-Tile");

            //floor
            regularFloor = Content.Load<Texture2D>("Stationary/Floor/Floor-Tile");

            test = Content.Load<Texture2D>("Ninja-Run-Sheet");
        }
    }
}
