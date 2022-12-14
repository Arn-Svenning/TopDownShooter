#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.ParticleEngine
{
    internal class Particle
    {
        public Texture2D Texture { get; set; }        // The texture that will be drawn to represent the particle
        public Vector2 Position { get; set; }        // The current position of the particle        
        public Vector2 Velocity { get; set; }        // The speed of the particle at the current instance
        public float Angle { get; set; }            // The current angle of rotation of the particle
        public float AngularVelocity { get; set; }    // The speed that the angle is changing
        public float Size { get; set; }                // The size of the particle
        public int TTL { get; set; }                // The 'time to live' of the particle
        public Color Color { get; set; }            // The color of the particle
              
        public Particle(Texture2D TEXTURE, Vector2 POSITION, Vector2 VELOCITY, float ANGLE, float ANGULARVELOCITY, Color COLOR, float SIZE, int TTL)
        {
            Texture = TEXTURE;
            Position = POSITION;
            Velocity = VELOCITY;
            Angle = ANGLE;
            AngularVelocity = ANGULARVELOCITY;
            Color = COLOR;
            Size = SIZE;
            this.TTL = TTL;
        }
        public void Update()
        {
            TTL--;
            Position += Velocity;
            Angle += AngularVelocity;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color, Angle, origin, Size, SpriteEffects.None, 0f);
        }
    }
}
