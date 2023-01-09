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
using System.IO;
using System.Linq;
using System.Xml.Serialization;
#endregion

namespace RoguelikeV2.Managers.Scores
{
    public class ScoreManager1
    {
        private static string fileName = "scores1.xml";


        public List<ScoreProperties> Highscores { get; private set; }

        public List<ScoreProperties> Scores { get; private set; }


        public ScoreManager1() : this(new List<ScoreProperties>())
        {

        }

        public ScoreManager1(List<ScoreProperties> scores)
        {
            Scores = scores;
            UpdateHighscores();

        }

        public void Add(ScoreProperties score)
        {
            Scores.Add(score);
            Scores = Scores.OrderByDescending(c => c.Value).ToList();
            UpdateHighscores();
        }
        public static ScoreManager1 Load()
        {
            if (!File.Exists(fileName))
            {
                return new ScoreManager1();
            }

            using (var reader = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                var serilizer = new XmlSerializer(typeof(List<ScoreProperties>));
                var scores = (List<ScoreProperties>)serilizer.Deserialize(reader);

                return new ScoreManager1(scores);
            }

        }
        public void UpdateHighscores()
        {
            Highscores = Scores.Take(5).ToList();
        }

        public static void Save(ScoreManager1 scoreManager)
        {
            using (var writer = new StreamWriter(new FileStream(fileName, FileMode.Create)))
            {
                var serilizer = new XmlSerializer(typeof(List<ScoreProperties>));

                serilizer.Serialize(writer, scoreManager.Scores);
            }
        }
    }
}
