#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System.Collections.Generic;
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

        public ParticleSystem(Texture2D TEXTURE, Vector2 LOCATION, Color COLOR, int TOTALPARTICLES, int TTL)
        {
            EmitterLocation = LOCATION;
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
            float size = (float)Globals.random.NextDouble();


            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, TTL);
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
        public void UpdateParticle()
        {
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
        
        public void DrawParticle(SpriteBatch spriteBatch)
        {

            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }

        }
    }
}
