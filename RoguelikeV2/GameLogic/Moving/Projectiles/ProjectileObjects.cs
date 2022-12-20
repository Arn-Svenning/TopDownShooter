#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Projectiles
{
    internal class ProjectileObjects : MovingObjects
    {
        public float LifeSpan { get; protected set; }
        public ProjectileObjects(Rectangle RECTANGLE, ProjectileData DATA) : base(RECTANGLE)
        {

        }
    }
}
