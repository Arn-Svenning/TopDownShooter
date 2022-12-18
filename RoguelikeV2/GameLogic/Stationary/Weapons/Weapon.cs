#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.GameLogic.Stationary.Weapons
{
    abstract class Weapon : StationaryObjects
    {
        protected Vector2 origin;

        protected float rotation;
       
        public Weapon(Rectangle RECTANGLE) : base(RECTANGLE)
        {

        }
       
    }
}
