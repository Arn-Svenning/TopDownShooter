#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using SharpDX.MediaFoundation;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Projectiles
{
    internal class PlayerBullet : MovingObjects
    {        
        public float LifeSpan { get; private set; }
        public PlayerBullet(Rectangle RECTANGLE,ProjectileData DATA, int player) : base(RECTANGLE)
        {
            if(player == 1)
                texture = AssetManager.regularBulletRed;
            if(player == 2)
                texture = AssetManager.regularBulletBlue;

            speed = DATA.Speed;
            rotation = DATA.Rotation;
            direction = new((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            LifeSpan = DATA.LifeSpan;
        }
        public void Update(GameTime gameTime)
        {
            position += -direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            LifeSpan -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, rotation, Vector2.Zero, 1, SpriteEffects.None, 1);
        }        
        
    }
}
