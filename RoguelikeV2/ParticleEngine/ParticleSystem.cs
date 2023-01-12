#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;
#endregion

namespace RoguelikeV2.ParticleEngine
{
    internal class ParticleSystem
    {

        private Color color;

        private Texture2D texture;
        public Vector2 EmitterLocation { get; set; }

        private int totalParticles;
        private int TTL;

        private List<Particle> particles;

        private float decreaseRandomScale;

        private int sizeModifier1;
        private int sizeModifier2;

        private Rectangle rect;
        public Rectangle Rect { get { return rect; } }

        public ParticleSystem(Texture2D TEXTURE, Color COLOR, int TOTALPARTICLES, int TTL)
        {            
            texture = TEXTURE;
            color = COLOR;
            totalParticles = TOTALPARTICLES;
            this.TTL = TTL;

            particles = new List<Particle>();
        }
        private Particle GenerateNewParticle()
        {
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(1f * (float)(Globals.random.NextDouble() * 2 - 1), 1f * (float)(Globals.random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(Globals.random.NextDouble() * 2 - 1);
            float size = (float)Globals.random.NextDouble() - decreaseRandomScale;
            rect = new Rectangle((int)position.X, (int)position.Y, (int)size + 40, (int)size + 40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, TTL,rect);
        }
        private Particle GenerateNewBigParticle()
        {
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(1f * (float)(Globals.random.NextDouble() * 2 - 1), 1f * (float)(Globals.random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(Globals.random.NextDouble() * 2 - 1);
            float size = Globals.random.Next(sizeModifier1, sizeModifier2);            
            rect = new Rectangle((int)position.X, (int)position.Y, 150,150);
            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, TTL, rect);
        }
        public void DeleteParticle()
        {

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }
        public void UpdateParticle(float DECREASERANDOMSCALE)
        {
            decreaseRandomScale = DECREASERANDOMSCALE;
            for (int i = 0; i < totalParticles; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }
        public void UpdateBigParticle(int SizeModifier1, int SizeModifier2)
        {            
            sizeModifier1 = SizeModifier1;
            sizeModifier2 = SizeModifier2;
            for (int i = 0; i < totalParticles; i++)
            {
                particles.Add(GenerateNewBigParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }
        public void DrawParticle(SpriteBatch spriteBatch)
        {

            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }
    }
}
