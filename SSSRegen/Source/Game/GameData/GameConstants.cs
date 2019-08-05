using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Game.GameData
{
    public static class GameConstants
    {
        public static class GameSetupConstants
        {
            public static readonly Vector2 VirtualResolution = new Vector2(1366, 768);
            public static readonly Vector2 DefaultActualResolution = new Vector2(1366, 768);
        }

        public static class EnemyConstants
        {
            public static class Enemy1Constants
            {
                public const string Name = "enemy1";
                public const int InitialCount = 4;
                public const int InitialMaxHealth = 10;
                public const int CollisionDamage = 2;
                public const int ScoreValue = 100;
                public const int AggroRange = 600;
                public const int Speed = 40;

                public static class Textures
                {
                    public const string BlackTextureName = "enemy1Black";
                    public const string BlackTextureFileName = @"Images/Enemies/enemyBlack1";
                }
            }

            public static class Enemy2Constants
            {
                public const string Name = "enemy2";
                public const int InitialCount = 4;
                public const int InitialMaxHealth = 15;
                public const int CollisionDamage = 4;
                public const int ScoreValue = 200;
                public const int AggroRange = 600;
                public const int Speed = 40;

                public static class Textures
                {
                    public const string BlueTextureName = "enemy2Blue";
                    public const string BlueTextureFileName = @"Images/Enemies/enemyBlue2";
                }
            }

            public static class Enemy3Constants
            {
                public const string Name = "enemy3";
                public const int InitialCount = 4;
                public const int InitialMaxHealth = 20;
                public const int CollisionDamage = 6;
                public const int ScoreValue = 300;
                public const int AggroRange = 600;
                public const int Speed = 40;

                public static class Textures
                {
                    public const string GreenTextureName = "enemy3Green";
                    public const string GreenTextureFileName = @"Images/Enemies/enemyGreen3";
                }
            }

            public static class Enemy4Constants
            {
                public const string Name = "enemy4";
                public const int InitialCount = 4;
                public const int InitialMaxHealth = 25;
                public const int CollisionDamage = 2;
                public const int ScoreValue = 400;
                public const int AggroRange = 600;
                public const int Speed = 40;

                public static class Textures
                {
                    public const string RedTextureName = "enemy4Red";
                    public const string RedTextureFileName = @"Images/Enemies/enemyRed4";
                }
            }

            public static class Enemy5Constants
            {
                public const string Name = "enemy5";
                public const int InitialCount = 4;
                public const int InitialMaxHealth = 30;
                public const int CollisionDamage = 2;
                public const int ScoreValue = 500;
                public const int AggroRange = 600;
                public const int Speed = 40;

                public static class Textures
                {
                    public const string BlackTextureName = "enemy5Black";
                    public const string BlackTextureFileName = @"Images/Enemies/enemyBlack5";
                }
            }
        }

        public static class MeteorConstants
        {
            public static class BigMeteor1Constants
            {
                public const string Name = "bigMeteor1";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 30;
                public const int CollisionDamage = 10;
                public const int ScoreValue = 200;
                public static class Textures
                {
                    public const string BrownTextureName = "bigMeteor1Brown";
                    public const string BrownTextureFileName = @"Images/Meteors/meteorBrown_big1";
                }
            }
            public static class BigMeteor2Constants
            {
                public const string Name = "bigMeteor2";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 30;
                public const int CollisionDamage = 10;
                public const int ScoreValue = 200;
                public static class Textures
                {
                    public const string GreyTextureName = "bigMeteor2Grey";
                    public const string GreyTextureFileName = @"Images/Meteors/meteorGrey_big2";
                }
            }
            public static class BigMeteor3Constants
            {
                public const string Name = "bigMeteor3";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 30;
                public const int CollisionDamage = 10;
                public const int ScoreValue = 200;
                public static class Textures
                {
                    public const string BrownTextureName = "bigMeteor3Brown";
                    public const string BrownTextureFileName = @"Images/Meteors/meteorBrown_big3";
                }
            }
            public static class BigMeteor4Constants
            {
                public const string Name = "bigMeteor4";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 30;
                public const int CollisionDamage = 10;
                public const int ScoreValue = 200;
                public static class Textures
                {
                    public const string GreyTextureName = "bigMeteor4Grey";
                    public const string GreyTextureFileName = @"Images/Meteors/meteorGrey_big4";
                }
            }
            public static class MediumMeteor1Constants
            {
                public const string Name = "mediumMeteor1";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 20;
                public const int CollisionDamage = 6;
                public const int ScoreValue = 150;
                public static class Textures
                {
                    public const string BrownTextureName = "mediumMeteor1Brown";
                    public const string BrownTextureFileName = @"Images/Meteors/meteorBrown_med1";
                }
            }
            public static class MediumMeteor2Constants
            {
                public const string Name = "mediumMeteor2";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 20;
                public const int CollisionDamage = 6;
                public const int ScoreValue = 150;
                public static class Textures
                {
                    public const string GreyTextureName = "mediumMeteor2Grey";
                    public const string GreyTextureFileName = @"Images/Meteors/meteorGrey_med2";
                }
            }
            public static class MediumMeteor3Constants
            {
                public const string Name = "mediumMeteor3";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 20;
                public const int CollisionDamage = 6;
                public const int ScoreValue = 150;
                public static class Textures
                {
                    public const string BrownTextureName = "mediumMeteor3Brown";
                    public const string BrownTextureFileName = @"Images/Meteors/meteorBrown_med3";
                }
            }
            public static class SmallMeteor1Constants
            {
                public const string Name = "smallMeteor1";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 10;
                public const int CollisionDamage = 4;
                public const int ScoreValue = 100;
                public static class Textures
                {
                    public const string GreyTextureName = "smallMeteor1Grey";
                    public const string GreyTextureFileName = @"Images/Meteors/meteorGrey_small1";
                }
            }
            public static class SmallMeteor2Constants
            {
                public const string Name = "smallMeteor1";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 10;
                public const int CollisionDamage = 4;
                public const int ScoreValue = 100;
                public static class Textures
                {
                    public const string BrownTextureName = "smallMeteor2Brown";
                    public const string BrownTextureFileName = @"Images/Meteors/meteorBrown_small2";
                }
            }
            public static class TinyMeteor1Constants
            {
                public const string Name = "tinyMeteor1";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 5;
                public const int CollisionDamage = 2;
                public const int ScoreValue = 50;
                public static class Textures
                {
                    public const string GreyTextureName = "tinyMeteor1Grey";
                    public const string GreyTextureFileName = @"Images/Meteors/meteorGrey_tiny1";
                }
            }
            public static class TinyMeteor2Constants
            {
                public const string Name = "tinyMeteor1";
                public const int InitialCount = 2;
                public const int InitialMaxHealth = 5;
                public const int CollisionDamage = 2;
                public const int ScoreValue = 50;
                public static class Textures
                {
                    public const string BrownTextureName = "tinyMeteor2Brown";
                    public const string BrownTextureFileName = @"Images/Meteors/meteorBrown_tiny2";
                }
            }

            public static int NumMeteorsSpawnedWhenDestroyed = 2;
        }

        public static class BonusConstants
        {
            public static class HealthPackConstants
            {
                public static class Textures
                {
                    public const string RedTextureName = "healthPackRed";
                    public const string RedTextureFileName = @"Images/Bonuses/pill_red";
                }

                public static class Audio
                {
                    public const string CollectedSoundEffectName = "healthPackCollectedSoundEffect";
                    public const string CollectedSoundEffectFileName = @"Audio/Bonuses/HealthPack/PUZZLE_Success_Beep_Three_Note_Fast_Climb_Delay_stereo";
                }

                public const int InitialCount = 2;
                public const int HealAmount = 2;
            }
        }

        public static class PlayerConstants
        {
            public static readonly Vector2 MovementVector = new Vector2(1.0f, 0);
            public const int InitialMaxHealth = 10;
            public const int InitialCollisionDamage = 50;
            public const string ScoreFormat = "000000000000";
            
            public static class PlayerShip1Constants
            {
                public static class Textures
                {
                    public const string LightDamageTextureName = "playerShip1Damage1";
                    public const string LightDamageTextureFileName = @"Images/Players/playerShip1_damage1";
                    public const string MediumDamageTextureName = "playerShip1Damage2";
                    public const string MediumDamageTextureFileName = @"Images/Players/playerShip1_damage2";
                    public const string HeavyDamageTextureName = "playerShip1Damage3";
                    public const string HeavyDamageTextureFileName = @"Images/Players/playerShip1_damage3";

                    public const string RedShipTextureName = "playerShip1Red";
                    public const string RedShipTextureFileName = @"Images/Players/playerShip1_red";
                    public const string RedLifeIconTextureName = "playerShip1RedLife";
                    public const string RedLifeIconTextureFileName = @"Images/UI/playerLife1_red";
                }
            }
            public static class PlayerShip2Constants
            {
                public static class Textures
                {
                    public const string LightDamageTextureName = "playerShip2Damage1";
                    public const string LightDamageTextureFileName = @"Images/Players/playerShip2_damage1";
                    public const string MediumDamageTextureName = "playerShip2Damage2";
                    public const string MediumDamageTextureFileName = @"Images/Players/playerShip2_damage2";
                    public const string HeavyDamageTextureName = "playerShip2Damage3";
                    public const string HeavyDamageTextureFileName = @"Images/Players/playerShip2_damage3";

                    public const string GreenShipTextureName = "playerShip2Green";
                    public const string GreenShipTextureFileName = @"Images/Players/playerShip2_green";
                    public const string GreenLifeIconTextureName = "playerShip2GreenLife";
                    public const string GreenLifeIconTextureFileName = @"Images/UI/playerLife2_Green";
                }
            }
            public static class PlayerShip3Constants
            {
                public static class Textures
                {
                    public const string LightDamageTextureName = "playerShip3Damage1";
                    public const string LightDamageTextureFileName = @"Images/Players/playerShip3_damage1";
                    public const string MediumDamageTextureName = "playerShip3Damage2";
                    public const string MediumDamageTextureFileName = @"Images/Players/playerShip3_damage2";
                    public const string HeavyDamageTextureName = "playerShip3Damage3";
                    public const string HeavyDamageTextureFileName = @"Images/Players/playerShip3_damage3";

                    public const string BlueShipTextureName = "playerShip3Blue";
                    public const string BlueShipTextureFileName = @"Images/Players/playerShip3_blue";
                    public const string BlueLifeIconTextureName = "playerShip3BlueLife";
                    public const string BlueLifeIconTextureFileName = @"Images/UI/playerLife3_Blue";
                }
            }
        }

        public static class GameStateConstants
        {
            public static class SplashStateConstants
            {
                public static class Textures
                {
                    public const string BackgroundTextureName = "splashStateBackground";
                    public const string BackgroundTextureFileName = @"Images/Backgrounds/SplashState/tempBackground";
                }

                public static class Audio
                {
                    public const string SplashScreenSoundEffectName = "splashStateSoundEffect";
                    public const string SplashScreenSoundEffectFileName = @"Audio/States/SplashState/VOICE_ROBOTIC_MALE_0_stereo";
                }

                public const float SplashStateDisplayTime = 1.0f;
            }

            public static class PlayStateConstants
            {
                public static class Textures
                {
                    public const string BackgroundTextureName = "playStateBackground";
                    public const string BackgroundTextureFileName = @"Images/Backgrounds/PlayState/Space003";
                }

                public static class Audio
                {
                    public const string BackgroundMusicName = "playStateBackgroundMusic";
                    public const string BackgroundMusicFileName = @"Audio/States/PlayState/Long_Range_Combat_LOOP";
                }

                public const string MenuTextResume = "Resume";
                public const string MenuTextHelp = "Help";
                public const string MenuTextQuit = "Quit";
            }

            public static class MenuStateConstants
            {
                public const string RegularFontName = "regularFontName";
                public const string RegularFontFileName = @"Fonts/smallFont";
                public const string SelectedFontName = "selectedFontName";
                public const string SelectedFontFileName = @"Fonts/largeFont";
                public const string LogoFontName = "logoFontName";
                public const string LogoFontFileName = @"Fonts/logoFont";

                public static class Textures
                {
                    public const string BackgroundTextureName = "menuBackground";
                    public const string BackgroundTextureFileName = @"Images/Backgrounds/MenuState/Space005";
                }

                public static class Audio
                {
                    public const string ModalMenuOpenedSoundEffectName = "modalMenuOpenedSoundEffect";
                    public const string ModalMenuOpenedSoundEffectFileName = @"Audio/States/MenuState/UI_Animate_Stutter_Beep_Appear_stereo";
                    public const string ModalMenuClosedSoundEffectName = "modalMenuClosedSoundEffect";
                    public const string ModalMenuClosedSoundEffectFileName = @"Audio/States/MenuState/UI_Animate_Stutter_Beep_Disappear_stereo";
                    public const string MenuNavigateSoundEffectName = "menuSelectionChangedSoundEffect";
                    public const string MenuNavigateSoundEffectFileName = @"Audio/States/MenuState/UI_Beep_Double_Quick_Bright_Short_stereo";
                    public const string MenuSelectionConfirmedSoundEffectName = "menuSelectionConfirmedSoundEffect";
                    public const string MenuSelectionConfirmedSoundEffectFileName = @"Audio/States/MenuState/UI_SCI-FI_Confirm_Dry_stereo";
                    public const string NewStateSelectionConfirmedSoundEffectName = "newStateSelectionConfirmedSoundEffect";
                    public const string NewStateSelectionConfirmedSoundEffectFileName = @"Audio/States/MenuState/UI_SCI-FI_Confirm_Wet_stereo";
                    public const string BackgroundMusicName = "mainMenuMusic";
                    public const string BackgroundMusicFileName = @"Audio/States/MenuState/Planet_Title_LOOP";
                }

                public static class LogoLine1
                {
                    //ToDo Logo position to go here
                }
                public static class LogoLine2
                {
                    //ToDo Logo position to go here
                }
                public static class LogoLine3
                {
                    //ToDo Logo position to go here
                }

                public const string PlayMenuText = "Play";
                //public const string OnePlayerMenuText = "One Player";
                //public const string TwoPlayerMenuText = "Two Player";
                public const string HelpMenuText = "Help";
                public const string QuitMenuText = "Quit";
                public const int ItemSpacing = 5;
            }
        }

        public static class ProjectileConstants
        {
            public const int MaxBulletsOnScreen = 30;
            
            public static class Bullet1Constants
            {
                public const int DamageAmount = 10;
                public const int BulletSpeed = 800;

                public static class Textures
                {
                    public const string BlueTextureName = "blueBullet1";
                    public const string BlueTextureFileName = @"Images/Projectiles/laserBlue07";
                }
                public static class Audio
                {
                    public const string ShootSoundEffectName = "bullet1ShootSoundEffect";
                    public const string ShootSoundEffectFileName = @"Audio/Projectiles/Bullet1/BLASTER_Bright_Short_stereo";
                }
            }

            public static class Bullet2Constants
            {
                public const int DamageAmount = 15;
                public const int BulletSpeed = 800;

                public static class Textures
                {
                    public const string GreenTextureName = "greenBullet2";
                    public const string GreenTextureFileName = @"Images/Projectiles/laserGreen05";
                }
                public static class Audio
                {
                    public const string ShootSoundEffectName = "bullet2ShootSoundEffect";
                    public const string ShootSoundEffectFileName = @"Audio/Projectiles/Bullet2/BLASTER_Cartoon_stereo";
                }
            }

            public static class Bullet3Constants
            {
                public const int DamageAmount = 20;
                public const int BulletSpeed = 800;
                
                public static class Textures
                {
                    public const string RedTextureName = "redBullet3";
                    public const string RedTextureFileName = @"Images/Projectiles/laserRed13";
                }
                public static class Audio
                {
                    public const string ShootSoundEffectName = "bullet3ShootSoundEffect";
                    public const string ShootSoundEffectFileName = @"Audio/Projectiles/Bullet3/BLASTER_Quick_Deep_stereo";
                }
            }
        }

        public static class ThrusterConstants
        {
            public static class Thruster1Constants
            {
                public const float FrameDelay = 2;
                public static class Textures
                {
                    public const string Frame1TextureName = "thust1Frame1";
                    public const string Frame1TextureFileName = @"Images/Thrusters/Thruster1/fire03";
                    public const string Frame2TextureName = "thust1Frame2";
                    public const string Frame2TextureFileName = @"Images/Thrusters/Thruster1/fire06";
                    public const string Frame3TextureName = "thust1Frame3";
                    public const string Frame3TextureFileName = @"Images/Thrusters/Thruster1/fire07";
                    public const string Frame4TextureName = "thust1Frame4";
                    public const string Frame4TextureFileName = @"Images/Thrusters/Thruster1/fire13";
                    public const string Frame5TextureName = "thust1Frame5";
                    public const string Frame5TextureFileName = @"Images/Thrusters/Thruster1/fire16";
                    public const string Frame6TextureName = "thust1Frame6";
                    public const string Frame6TextureFileName = @"Images/Thrusters/Thruster1/fire17";
                }
                public static class Audio
                {
                    public const string ThrustingSoundEffectName = "thruster1SoundEffect";
                    public const string ThrustingSoundEffectFileName = @"Audio/Thrusters/SPACECRAFT_Rocket_04_Smooth_Burn_loop_mono";
                }
            }
        }
    }
}