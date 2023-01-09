#region Using...
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.GameLogic.Stationary;
using RoguelikeV2.GameLogic.Stationary.Tiles;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Managers;
using RoguelikeV2.ParticleEngine;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Players
{
    internal class Player : MovingObjects
    {
        private bool isMoving;
        public bool isDead { get; private set; }
        private ParticleSystem dustParticle;
        private PlayerWeapon playerWeapon;
        public int healhPoints { get; private set; }
        private float invicibilityTimer;
        public PlayerWeapon PlayerWeapon { get { return playerWeapon; } }

        //SCORE
        public static int Score1 { get; set; } = 0;
        public static int Score2 { get; set; } = 0;
        private Vector2 scorePos;

        private Color color;
        
        public Player(Rectangle RECTANGLE) : base(RECTANGLE)
        {           
            invicibilityTimer = 60 * 2;
            healhPoints = 5;
            size = RECTANGLE;
            texture = AssetManager.right;
            speed = 250f;
            playerWeapon = new PlayerWeapon(new Rectangle((int)position.X + 35, (int)position.Y + 30, 64, 64), new Vector2(texture.Width / 2, texture.Height / 2), AssetManager.normalGun);           
            dustParticle = new ParticleSystem(AssetManager.circleParticle, Color.BurlyWood, 3, 15);

            isDead = false;           
        }
        public void Update(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot, GamePadState state)
        {
            invicibilityTimer--;
            //gun            
            HoldGun(gameTime, up, down, right, left, player, shoot, state);            
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width / 3, texture.Height);
            ChasingEnemyDamage(player);            
            PlayerMovement(gameTime, up, down, right, left, player, state);            
            Collission();
            
            if (isMoving)
            {
                dustParticle.EmitterLocation = new Vector2(position.X + 30, position.Y + size.Height - 10);
                dustParticle.UpdateParticle(0.3f);
            }
            else
                dustParticle.DeleteParticle();            
            if (healhPoints <= 0)
            {
                isDead = true;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(!isDead)
            {
               
                dustParticle.DrawParticle(spriteBatch);
                spriteBatch.Draw(texture, size, sourceRectangle, color, 0f, Vector2.Zero, SpriteEffects.None, 1);
                playerWeapon.Draw(spriteBatch);

                if (playerWeapon.texture == AssetManager.sniper)
                    playerWeapon.DrawBulletsLeft(spriteBatch, AssetManager.sniperShot, position, 2);
                else if (playerWeapon.texture == AssetManager.RPG)
                    playerWeapon.DrawBulletsLeft(spriteBatch, AssetManager.sniperShot, position, 1);              
            }           
        }
        #region Player Movement
        public void PlayerMovement(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player,GamePadState state)
        {

            position += speed * direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

            float frameSpeed = 600f;          

            if (InputManager.HoldKey(left) || state.ThumbSticks.Left.X < -0.5f)
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.left, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.leftBlue, 100f);

                direction.X = -1;
                direction.Normalize();

            }
            else if (InputManager.HoldKey(right) || state.ThumbSticks.Left.X > +0.5f)
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.right, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.rightBlue, 100f);

                direction.X = 1;
                direction.Normalize();

            }
            else
            {
                isMoving = false;
                direction.X = 0;
            }

            if (InputManager.HoldKey(up) || state.ThumbSticks.Left.Y > +0.5f)
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.up, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upBlue, 100f);

                direction.Y = -1;
                direction.Normalize();

            }
            else if (InputManager.HoldKey(down) || state.ThumbSticks.Left.Y < -0.5f)
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.down, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downBlue, 100f);

                direction.Y = 1;
                direction.Normalize();
            }
            else
            {
                direction.Y = 0;
            }

            if (InputManager.HoldKey(left) && InputManager.HoldKey(up) || state.ThumbSticks.Left.X < -0.5f && state.ThumbSticks.Left.Y > +0.5f)
            {
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upLeft, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upLeftBlue, frameSpeed);
            }


            if (InputManager.HoldKey(right) && InputManager.HoldKey(up) || state.ThumbSticks.Left.X > +0.5f && state.ThumbSticks.Left.Y > +0.5f)
            {
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upRight, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upRightBlue, frameSpeed);
            }


            if (InputManager.HoldKey(right) && InputManager.HoldKey(down) || state.ThumbSticks.Left.X > +0.5f && state.ThumbSticks.Left.Y < -0.5f)
            {

                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downRight, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downRightBlue, frameSpeed);
            }


            if (InputManager.HoldKey(left) && InputManager.HoldKey(down) || state.ThumbSticks.Left.X < -0.5f && state.ThumbSticks.Left.Y < -0.5f)
            {

                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downLeft, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downLeftBlue, frameSpeed);
            }


        }
        private void Collission()
        {
            foreach (GameObjects obj in MapManager.mapObjects)
            {
                if (obj is Wall)
                {
                    if (direction.X > 0 && IsTouchingLeft((Wall)obj) || (direction.X < 0 && IsTouchingRight((Wall)obj)))
                        direction.X = 0;

                    if (direction.Y > 0 && IsTouchingTop((Wall)obj) || (direction.Y < 0 && IsTouchingBottom((Wall)obj)))
                        direction.Y = 0;
                }
            }
        }
        #endregion
        #region Guns
        private void HoldGun(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player, Keys shoot, GamePadState state)
        {
            Rectangle sniperRect = new Rectangle((int)position.X + 35, (int)position.Y + 30, 128, 128);
            Rectangle noramlGunRect = new Rectangle((int)position.X + 35, (int)position.Y + 30, 64, 64);

            //regular gun
            if (playerWeapon.texture == AssetManager.normalGun)
            {                
                playerWeapon.Size = noramlGunRect;
                playerWeapon.origin = new Vector2(texture.Width / 2, texture.Height / 2);                
            }
            ////sniper
            else if (playerWeapon.texture == AssetManager.sniper)
            {               
                playerWeapon.Size = sniperRect;
                playerWeapon.origin = new Vector2(texture.Width - 30, texture.Height);
            }
            //RPG
            else if(playerWeapon.texture == AssetManager.RPG)
            {
                playerWeapon.Size = sniperRect;
                playerWeapon.origin = new Vector2(texture.Width - 30, texture.Height);
            }
            
            playerWeapon.Update(gameTime, left, right, down, up, shoot, player, state);

            if (playerWeapon.SniperAmmo <= 0 || playerWeapon.RPGAmmo <= 0)
            {
                playerWeapon.Size = noramlGunRect;
                playerWeapon.texture = AssetManager.normalGun;
            }

            PickUpGun();
        }
        private void PickUpGun()
        {
           
            foreach (PlayerWeapon gun in WeaponSpawner.weapons)
            {              
                if (size.Intersects(gun.Size))
                {
                    WeaponSpawner.weapons.Remove(gun);
                    playerWeapon = gun;                   
                    break;
                }              
            }
            
        }

        #endregion
        #region Take Damage / HP
        private void ChasingEnemyDamage(int player)
        {
            if (invicibilityTimer <= 0)
            {
                color = Color.White;
            }
            else if(invicibilityTimer > 0 && player == 1)
                color = Color.Red;
            else if(invicibilityTimer > 0 && player == 2)
                color = Color.Blue;

            foreach(EnemyObjects enemy in MapManager.enemies)
            {
                if(enemy is ChasingEnemy)
                {
                    if(enemy.Rect.Intersects(size) && enemy.texture == AssetManager.chaserAttack)
                    {
                        TakeDamage(1);                        
                    }
                }
            }
        }
        public void TakeDamage(int damage)
        {
            if(invicibilityTimer <= 0)
            {
                healhPoints -= damage;
                invicibilityTimer = 60 * 2;
            }
           
        }
        #endregion
        #region Score
        public void DrawScore1(SpriteBatch spriteBatch) => spriteBatch.DrawString(AssetManager.minecraftFont, "Score: " + Score1, scorePos, Color.White);
        public void DrawScore2(SpriteBatch spriteBatch) => spriteBatch.DrawString(AssetManager.minecraftFont, "Score: " + Score2, scorePos, Color.White);
        public void UpdateScorePos() => scorePos = position + new Vector2(-35,-25);
        #endregion
    }
}
