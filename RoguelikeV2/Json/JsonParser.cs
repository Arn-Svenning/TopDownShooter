#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RoguelikeV2.GameLogic;
using System.Collections.Generic;
using System.IO;
using System;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Stationary.Tiles;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Stationary.StationaryEnemy;
#endregion

namespace RoguelikeV2.Json
{
    internal class JsonParser
    {
        static JObject wholeObject;
        static string currentFileName;

        public static void GetJObjectFromFile(string fileName)
        {
            currentFileName = fileName;

            ///creates file if it's not created
            if (File.Exists(fileName) == false)
            {
                File.Create(fileName).Close();

            }
            StreamReader file = File.OpenText(fileName);
            JsonTextReader reader = new JsonTextReader(file);
            wholeObject = JObject.Load(reader);
            file.Close();
        }
        public static Rectangle GetRectangle(string fileName, string propertyName)
        {
            if (wholeObject == null || currentFileName == null || currentFileName != fileName)
            {
                GetJObjectFromFile(fileName);
            }
            JObject obj = (JObject)wholeObject.GetValue(propertyName);
            return GetRectangle(obj);
        }
        public static List<Rectangle> GetRectangleList(string fileName, string propertyName)
        {
            if (wholeObject == null || currentFileName == null || currentFileName != fileName)
            {
                GetJObjectFromFile(fileName);
            }
            List<Rectangle> rectList = new List<Rectangle>();
            JArray arrayObj = (JArray)wholeObject.GetValue(propertyName);

            for (int i = 0; i < arrayObj.Count; i++)
            {

                JObject obj = (JObject)arrayObj[i];
                Rectangle rect = GetRectangle(obj);
                rectList.Add(rect);
            }
            return rectList;
        }
        private static Rectangle GetRectangle(JObject obj)
        {
            int x = Convert.ToInt32(obj.GetValue("positionX"));
            int y = Convert.ToInt32(obj.GetValue("positionY"));
            int height = Convert.ToInt32(obj.GetValue("height"));
            int width = Convert.ToInt32(obj.GetValue("width"));
            Rectangle rect = new Rectangle(x, y, width, height);
            return rect;
        }
        public static void WriteJsonToFile(string filename, List<GameObjects> gList)
        {
            JArray wallArray = new JArray();
            JArray floorArray = new JArray();
            JArray p1Array = new JArray();
            JArray p2Array = new JArray();            
            JObject bigobj = new JObject();
            JArray array = new JArray();

            for (int i = 0; i < gList.Count; i++)
            {
                if (gList[i] is Wall)
                {
                    JObject obj = CreateObject(gList[i].Size);
                    wallArray.Add(obj);
                }
                else if (gList[i] is Floor)
                {
                    JObject obj = CreateObject(gList[i].Size);
                    floorArray.Add(obj);
                }
                else if (gList[i] is Player)
                {
                    JObject obj = CreateObject(gList[i].Size);
                    p1Array.Add(obj);
                    p2Array.Add(obj);
                }                
            }           
            bigobj.Add("player1", p1Array);
            bigobj.Add("player2", p2Array);
            bigobj.Add("walls", wallArray);
            bigobj.Add("floor", floorArray);
            System.Diagnostics.Debug.WriteLine(bigobj.ToString());
            File.WriteAllText(filename, bigobj.ToString());
        }
        private static JObject CreateObject(Rectangle rect)
        {
            JObject obj = new JObject();
            obj.Add("positionX", rect.X);
            obj.Add("positionY", rect.Y);
            obj.Add("height", rect.Height);
            obj.Add("width", rect.Width);
            return obj;
        }
    }
}
