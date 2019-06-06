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
                public const int InitialMaxHealth = 20;
            }

            public static class Enemy2
            {
                public const string Name = "enemy2";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 105, Y = 260, Width = 65, Height = 65}
                };
                public const int InitialEnemyCount = 2;
                public const int InitialMaxHealth = 30;
            }

            public static class Enemy3
            {
                public const string Name = "enemy3";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 65, Y = 325, Width = 70, Height = 72}
                };
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 40;
            }

            public static class EnemyBoss
            {
                public const string Name = "enemyBoss";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 65, Y = 397, Width = 96, Height = 96}
                };
                public const int InitialCount = 1;
                public const int InitialMaxHealth = 150;
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

        public static class Bonuses
        {
            public static class HealthPack
            {
                public const string Name = "healthPack";
                public static List<Rectangle> SpriteFrames = new List<Rectangle>
                {
                    new Rectangle {X = 169, Y = 0, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 15, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 30, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 45, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 60, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 75, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 90, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 105, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 120, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 135, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 150, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 165, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 180, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 195, Width = 15, Height = 15},
                    new Rectangle {X = 169, Y = 210, Width = 15, Height = 15},
                };
                public const int FrameDelay = 200;
            }
        }

        public static class Player
        {
            public const float MovementVelocity = 6.0f;
            public const int InitialMaxHealth = 100;
            public const string ScoreFormat = "000000000000";
            public static List<Rectangle> IdleSpriteFrames = new List<Rectangle>
            {
                new Rectangle {X = 105, Y = 0, Width = 50, Height = 40}
            };
        }

        public static class GameStates
        {
            public static class SplashState
            {
                public const string BackgroundTextureName = "splashBackground";
                public const string BackgroundTextureFileName = @"SplashScreen/tempBackground";
                public const float SplashStateDisplayTime = 3.0f;
            }

            public static class PlayState
            {
                public const string PlayElementsSpriteSheetName = "PlayElementsSpriteSheet";
                public const string PlayElementsSpriteSheetFilePath = @"PlayImages/SpriteSheet";
                public const string BackgroundImageName = @"MenuImages/MenuBackground";
            }

            public static class MenuState
            {
                public const string LogoSpriteSheetName = "menuElements";
                public const string LogoSpriteSheetFileName = @"MenuImages/MenuElements";
                public const string RegularFontName = "regularFontName";
                public const string RegularFontFileName = @"MenuFonts/smallFont";
                public const string SelectedFontName = "selectedFontName";
                public const string SelectedFontFileName = @"MenuFonts/largeFont";

                public static class LogoLine1
                {
                    public static List<Rectangle> SpriteFrames = new List<Rectangle>
                    {
                        new Rectangle(0, 0, 536, 131),
                    };
                }
                public static class LogoLine2
                {
                    public static List<Rectangle> SpriteFrames = new List<Rectangle>
                    {
                        new Rectangle(120, 165, 517, 130),
                    };
                }
                public static class LogoLine3
                {
                    public static List<Rectangle> SpriteFrames = new List<Rectangle>
                    {
                        new Rectangle(8, 304, 375, 144),
                    };
                }

                public const string OnePlayerMenuText = "One Player";
                public const string TwoPlayerMenuText = "Two Player";
                public const string HelpMenuText = "Help";
                public const string QuitMenuText = "Quit";
                public const int ItemSpacing = 5;
            }
        }
    }
}