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

        //player2
        public static Texture2D upBlue;
        public static Texture2D downBlue;
        public static Texture2D rightBlue;
        public static Texture2D leftBlue;
        public static Texture2D upRightBlue;
        public static Texture2D upLeftBlue;
        public static Texture2D downRightBlue;
        public static Texture2D downLeftBlue;

        //splitScreen
        public static Texture2D pillar;

        //guns
        public static Texture2D normalGun;
        public static Texture2D sniper;

        //particles
        public static Texture2D circleParticle;

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

            //player2
            upBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Up-Sheet-Blue");
            downBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Down-Sheet-Blue");
            rightBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Right-Sheet-Blue");
            leftBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Left-Sheet-Blue");
            upRightBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Up-Right-Sheet-Blue");
            upLeftBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Up-Left-Sheet-Blue");
            downRightBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Down-Right-Sheet-Blue");
            downLeftBlue = Content.Load<Texture2D>("Moving/Players/Player2/Move/Down-Left-Sheet-Blue");

            //splitScreen
            pillar = Content.Load<Texture2D>("Stationary/SplitScreen/SplitScreen");

            //guns
            normalGun = Content.Load<Texture2D>("Stationary/Guns/Normal-Gun");
            sniper = Content.Load<Texture2D>("Stationary/Guns/Sniper");

            //particles
            circleParticle = Content.Load<Texture2D>("Moving/Particles/circle");

            //walls
            regularWall = Content.Load<Texture2D>("Stationary/Walls/Wall-Tile");

            //floor
            regularFloor = Content.Load<Texture2D>("Stationary/Floor/Floor-Tile");

            
        }
    }
}
