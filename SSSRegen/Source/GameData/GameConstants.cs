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
                public const int InitialEnemyCount = 4;
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
                public const int InitialEnemyCount = 2;
            }

            public static class EnemyBoss
            {
                public const string Name = "enemyBoss";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 65, Y = 397, Width = 96, Height = 96}
                };
                public const int InitialEnemyCount = 1;
            }
        }
    }
}