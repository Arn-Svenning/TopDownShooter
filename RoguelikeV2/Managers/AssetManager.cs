#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RoguelikeV2.GameLogic;
using System;
using System.Collections.Generic;
#endregion

namespace RoguelikeV2.Managers
{
    internal class AssetManager
    {
        #region Sound

        //Menu
        public static SoundEffect click;
        //Music
        public static Song backgroundSong;
        //Guns
        public static SoundEffect normalGunSound;
        public static SoundEffect sniperSound;
        public static SoundEffect RPGFire;
        public static SoundEffect RPGExplosion;

        //Enemies
        public static SoundEffect chaserAttackSound;
        public static SoundEffect necroAttackSound;
        public static SoundEffect turretAttackSound;
        #endregion


        //Enemies
        public static Texture2D chasingEnemy;
        public static Texture2D necromancer;
        public static Texture2D turret;

        //Enemies Attack
        public static Texture2D chaserAttack;

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

        //playerLives
        public static Texture2D hearts;

        //splitScreen
        public static Texture2D pillar;

        //guns
        public static Texture2D normalGun;
        public static Texture2D sniper;
        public static Texture2D RPG;

        //bullets and magic
        public static Texture2D regularBulletRed;
        public static Texture2D regularBulletBlue;
        public static Texture2D necromancerMagic;
        public static Texture2D turretBullet;
        public static Texture2D sniperShot;
        public static Texture2D RPGBullet;

        //particles
        public static Texture2D circleParticle;

        //walls
        public static Texture2D regularWall;
        public static Texture2D wallUp;
        //floor
        public static Texture2D regularFloor;

        //fonts
        public static SpriteFont minecraftFont;

        //main menu
        public static Texture2D menuBackground;

        
        public static void LoadAssets(ContentManager Content)
        {
            #region Sound
            //Menu
            click = Content.Load<SoundEffect>("Sound/MenuButtons/button-8-88355");

            //Music
            backgroundSong = Content.Load<Song>("Sound/BackgroundSong/psykick-112469");
            MediaPlayer.Play(backgroundSong);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.1f;
            //Guns
            normalGunSound = Content.Load<SoundEffect>("Sound/NormalGun/laser-45816");
            sniperSound = Content.Load<SoundEffect>("Sound/Sniper/zip-laser-94333");
            RPGFire = Content.Load<SoundEffect>("Sound/RPG/Fire/pvc-rocket-cannon_2-106658");
            RPGExplosion = Content.Load<SoundEffect>("Sound/RPG/Explode/explosion-6055");

            //Enemies
            chaserAttackSound = Content.Load<SoundEffect>("Sound/Enemies/Chasing/fast-simple-chop-5-6270");
            necroAttackSound = Content.Load<SoundEffect>("Sound/Enemies/Necromancer/magic-spell-6005");
            turretAttackSound = Content.Load<SoundEffect>("Sound/Enemies/Turret/shoot02wav-14562");
            #endregion

            //enemies
            chasingEnemy = Content.Load<Texture2D>("Moving/Enemies/Chaser-Enemy");
            necromancer = Content.Load<Texture2D>("Moving/Enemies/Necromancer-Sheet");
            turret = Content.Load<Texture2D>("Stationary/Enemies/Turret-Sheet");

            //enemies attack
            chaserAttack = Content.Load<Texture2D>("Moving/Enemies/Attack/Chaser-Enemy-Attack");

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

            //playerLives
            hearts = Content.Load<Texture2D>("Moving/Players/Lives/Hearts");

            //splitScreen
            pillar = Content.Load<Texture2D>("Stationary/SplitScreen/SplitScreen");

            //guns
            normalGun = Content.Load<Texture2D>("Stationary/Guns/Normal-Gun");
            sniper = Content.Load<Texture2D>("Stationary/Guns/Sniper");
            RPG = Content.Load<Texture2D>("Stationary/Guns/RPG-Gun");

            //bullets and magic
            regularBulletRed = Content.Load<Texture2D>("Moving/Bullets/Player1-Bullet");
            regularBulletBlue = Content.Load<Texture2D>("Moving/Bullets/Player2-Bullet");
            necromancerMagic = Content.Load<Texture2D>("Moving/Bullets/Necromancer-Shot");
            turretBullet = Content.Load<Texture2D>("Moving/Bullets/Turret-Projectile");
            sniperShot = Content.Load<Texture2D>("Moving/Bullets/Sniper-Shot-Red");
            RPGBullet = Content.Load<Texture2D>("Moving/Bullets/RPG-Bullet");

            //particles
            circleParticle = Content.Load<Texture2D>("Moving/Particles/circle");

            //walls
            regularWall = Content.Load<Texture2D>("Stationary/Walls/Wall-Tile");
            wallUp = Content.Load<Texture2D>("Stationary/Walls/WallTile-Up");
            //floor
            regularFloor = Content.Load<Texture2D>("Stationary/Floor/Floor-Tile");

            //fonts
            minecraftFont = Content.Load<SpriteFont>("defaultFont");

            //main menu
            menuBackground = Content.Load<Texture2D>("Background/MainMenu/Main-Menu-Background");

            
        }
    }
}
