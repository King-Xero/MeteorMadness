using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.GameData
{
    public static class GameConstants
    {
        public static class Enemies
        {
            public static class Enemy1
            {
                public const string Name = "enemy1";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 105, Y = 210, Width = 50, Height = 50}
                };
                public const int InitialCount = 4;
            }

            public static class Enemy2
            {
                public const string Name = "enemy2";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 105, Y = 260, Width = 65, Height = 65}
                };
                public const int InitialEnemyCount = 2;
            }

            public static class Enemy3
            {
                public const string Name = "enemy3";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 65, Y = 325, Width = 70, Height = 72}
                };
                public const int InitialCount = 2;
            }

            public static class EnemyBoss
            {
                public const string Name = "enemyBoss";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 65, Y = 397, Width = 96, Height = 96}
                };
                public const int InitialCount = 1;
            }
        }

        public static class Meteors
        {
            public static class SmallMeteor
            {
                public const string Name = "smallMeteor";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 0, Y = 0, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 40, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 80, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 120, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 160, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 200, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 240, Width = 40, Height = 40},
                    new Rectangle {X = 0, Y = 280, Width = 40, Height = 40},
                };
                public const int InitialCount = 2;
            }

            public static class MediumMeteor
            {
                public const string Name = "mediumMeteor";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 0, Y = 0, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 65, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 130, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 195, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 260, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 325, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 390, Width = 65, Height = 65},
                    new Rectangle {X = 0, Y = 455, Width = 65, Height = 65},
                };
                public const int InitialCount = 2;
            }
        }
    }
}