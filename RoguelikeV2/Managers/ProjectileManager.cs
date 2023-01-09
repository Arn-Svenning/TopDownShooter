#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.GameLogic.Stationary.StationaryEnemy;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.Menus;
using RoguelikeV2.ParticleEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
#endregion

namespace RoguelikeV2.Managers
{
    internal class ProjectileManager
    {
        public static List<PlayerBullet> Player1Bullets { get; } = new List<PlayerBullet>();
        public static List<PlayerBullet> Player2Bullets { get; } = new List<PlayerBullet>();
        public static List<NecromancerProjectile> NecromancerProjectiles { get; } = new List<NecromancerProjectile>();

        public static List<TurretProjectile> TurretProjectiles { get; } = new List<TurretProjectile>();
        

        #region PlayerProjectiles
        public static void AddPlayer1Projectile(ProjectileData projectile, int player)
        {            
            Player1Bullets.Add(new(new Rectangle((int)projectile.Position.X, (int)projectile.Position.Y, AssetManager.regularBulletRed.Width, AssetManager.regularBulletRed.Height),projectile, player));                       
        }
        public static void AddPlayer2Projectile(ProjectileData projectile, int player)
        {
            
            Player2Bullets.Add(new(new Rectangle((int)projectile.Position.X, (int)projectile.Position.Y, AssetManager.regularBulletRed.Width, AssetManager.regularBulletRed.Height), projectile, player));
        }
        public static void Update(GameTime gameTime, int player)
        {
            
            if(player == 1)
            {
                foreach (PlayerBullet bullet in Player1Bullets)
                {
                    bullet.Update(gameTime, player);                                       
                    foreach (EnemyObjects enemy in MapManager.enemies)
                    {                       
                        if (enemy.HealthPoints <= 0) continue;                       
                        if (bullet.Size.Intersects(enemy.Rect))
                        {
                            enemy.TakeDamage(bullet.Damage);
                            if(bullet.texture == AssetManager.RPGBullet)
                            {
                                RPGExplosionParticles.endPos = bullet.Position;
                                RPGExplosionParticles.explosion = true;
                            }

                            bullet.DestroyBullet();
                            if (enemy is ChasingEnemy && enemy.HealthPoints <= 0)
                            {
                                Player.Score1++;
                            }
                            else if (enemy is Necromancer && enemy.HealthPoints <= 0)
                            {
                                Player.Score1 = Player.Score1 + 2;
                            }
                            else if (enemy is TurretEnemy && enemy.HealthPoints <= 0)
                            {
                                Player.Score1 = Player.Score1 + 3;
                            }
                            break;                            
                        }       
                    }
                    MapManager.enemies.RemoveAll((enemy) => enemy.HealthPoints <= 0);                     
                }
                Player1Bullets.RemoveAll((p) => p.LifeSpan <= 0);
            }
            else if(player == 2)
            {
                foreach (PlayerBullet bullet in Player2Bullets)
                {
                    bullet.Update(gameTime, player);

                    foreach (EnemyObjects enemy in MapManager.enemies)
                    {
                        if (enemy.HealthPoints <= 0) continue;
                        if (bullet.Size.Intersects(enemy.Rect))
                        {
                            enemy.TakeDamage(bullet.Damage);
                            if (bullet.texture == AssetManager.RPGBullet)
                            {                                
                                RPGExplosionParticles.endPos = bullet.Position;
                                RPGExplosionParticles.explosion = true;                                
                            }
                            bullet.DestroyBullet();
                            if (enemy is ChasingEnemy && enemy.HealthPoints <= 0)
                            {
                                Player.Score2++;
                            }
                            else if (enemy is Necromancer && enemy.HealthPoints <= 0)
                            {
                                Player.Score2 = Player.Score2 + 2;
                            }
                            else if (enemy is TurretEnemy && enemy.HealthPoints <= 0)
                            {
                                Player.Score2 = Player.Score2 + 3;
                            }
                            break;
                        }             
                    }
                    MapManager.enemies.RemoveAll((enemy) => enemy.HealthPoints <= 0);
                    
                }
                Player2Bullets.RemoveAll((p) => p.LifeSpan <= 0);
            }
           
        }
        public static void Draw(SpriteBatch spriteBatch, int player)
        {
           
            if(player == 1)
            {
                foreach (PlayerBullet bullet in Player1Bullets)
                {
                    bullet.Draw(spriteBatch);
                }
            }
            else if(player == 2)
            {
                foreach (PlayerBullet bullet in Player2Bullets)
                {
                    bullet.Draw(spriteBatch);
                }
            }
            
        }
        #endregion
        #region EnemyProjectiles
        public static void AddNecroMancerProjectile(ProjectileData projectile)
        {
            NecromancerProjectiles.Add(new(new Rectangle((int)projectile.Position.X, (int)projectile.Position.Y, AssetManager.necromancerMagic.Width, AssetManager.necromancerMagic.Height), projectile));            
        }
        public static void AddTurretProjectile(ProjectileData projectile)
        {
            TurretProjectiles.Add(new(new Rectangle((int)projectile.Position.X, (int)projectile.Position.Y, AssetManager.turretBullet.Width, AssetManager.turretBullet.Height), projectile));
        }
        public static void UpdateNecroMancerProjectile(GameTime gameTime)
        {
            foreach(NecromancerProjectile projectile in NecromancerProjectiles)
            {
                projectile.Update(gameTime);

                foreach(Player player in MapManager.player1)
                {
                    if (projectile.Size.Intersects(player.Size))
                    {
                        player.TakeDamage(2);
                        projectile.DestroyProjectile();
                        break;
                    }
                   
                }
                foreach (Player player in MapManager.player2)
                {
                    if (projectile.Size.Intersects(player.Size))
                    {
                        player.TakeDamage(2);
                        projectile.DestroyProjectile();
                        break;
                    }

                }
            }
            NecromancerProjectiles.RemoveAll((p) => p.LifeSpan <= 0);
          
        }
        public static void DrawNecroMancerProjectile(SpriteBatch spriteBatch)
        {
            foreach(NecromancerProjectile projectile in NecromancerProjectiles)
            {
                projectile.Draw(spriteBatch);
            }            
        }

        public static void UpdateTurretProjectile(GameTime gameTime)
        {
            foreach (TurretProjectile projectile in TurretProjectiles)
            {
                projectile.Update(gameTime);
                foreach (Player player in MapManager.player1)
                {
                    if (projectile.Size.Intersects(player.Size))
                    {
                        player.TakeDamage(1);
                        projectile.DestroyProjectile();
                        break;
                    }
                }
                foreach (Player player in MapManager.player2)
                {
                    if (projectile.Size.Intersects(player.Size))
                    {
                        player.TakeDamage(1);
                        projectile.DestroyProjectile();
                        break;
                    }

                }
            }
            TurretProjectiles.RemoveAll((p) => p.LifeSpan <= 0);
        }
        public static void DrawTurretProjectile(SpriteBatch spriteBatch)
        {
            foreach (TurretProjectile projectile in TurretProjectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
