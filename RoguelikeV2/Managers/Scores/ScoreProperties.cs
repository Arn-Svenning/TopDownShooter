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

namespace RoguelikeV2.Managers.Scores
{
    public class ScoreProperties
    {
        public string PlayerName { get; set; }
        public int Value { get; set; }
    }
}
