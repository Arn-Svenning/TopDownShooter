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
        //player1
        public static Texture2D up;
        public static Texture2D down;
        public static Texture2D right;
        public static Texture2D left;
        public static Texture2D upRight;
        public static Texture2D upLeft;
        public static Texture2D downRight;
        public static Texture2D downLeft;
        

        //walls
        public static Texture2D regularWall;

        //floor
        public static Texture2D regularFloor;

        
        public static void LoadAssets(ContentManager Content)
        {
            //player1
            up = Content.Load<Texture2D>("Moving/Players/Player1/Move/Up-Sheet");
            down = Content.Load<Texture2D>("Moving/Players/Player1/Move/Front-Sheet");
            right = Content.Load<Texture2D>("Moving/Players/Player1/Move/Right-Sheet");
            left = Content.Load<Texture2D>("Moving/Players/Player1/Move/Left-Sheet");
            upRight = Content.Load<Texture2D>("Moving/Players/Player1/Move/Up-Right-Sheet");
            upLeft = Content.Load<Texture2D>("Moving/Players/Player1/Move/Up-Left-Sheet");
            downRight = Content.Load<Texture2D>("Moving/Players/Player1/Move/Down-Right-Sheet");
            downLeft = Content.Load<Texture2D>("Moving/Players/Player1/Move/Down-Left-Sheet");
            


            //walls
            regularWall = Content.Load<Texture2D>("Stationary/Walls/Wall-Tile");

            //floor
            regularFloor = Content.Load<Texture2D>("Stationary/Floor/Floor-Tile");

            
        }
    }
}
