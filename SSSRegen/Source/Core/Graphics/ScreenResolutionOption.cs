namespace SSSRegen.Source.Core.Graphics
{
    public enum ScreenResolutionOption
    {
        SRO_640X480 = 1,
        SRO_800X600 = 2,
        SRO_1024X768 = 3,
        SRO_1280X720 = 4,
        SRO_1280X800 = 5,
        SRO_1366X768 = 6,
        SRO_1440X900 = 7,
        SRO_1680X1050 = 8,
        SRO_1920X1080 = 9,
        SRO_1920X1200 = 10,
        SRO_1920X1440 = 11,
        SRO_2560X1440 = 12,
        SRO_3840X2160 = 13,
    }

    //ToDo Replace ScreenResolutionConverter with internal extension method
    //internal static Vector2 ToVector2(this ScreenResolutionOption sro)
    //{
    //    switch (sro)
    //    {
    //        case ScreenResolutionOption.SRO_640X480:
    //            return new Vector2(640, 480);
    //        case ScreenResolutionOption.SRO_800X600:
    //            return new Vector2(800, 600);
    //        case ScreenResolutionOption.SRO_1024X768:
    //            return new Vector2(1024, 768);
    //        case ScreenResolutionOption.SRO_1280X720:
    //            return new Vector2(1280, 720);
    //        case ScreenResolutionOption.SRO_1280X800:
    //            return new Vector2(1280, 800);
    //        case ScreenResolutionOption.SRO_1366X768:
    //            return new Vector2(1366, 768);
    //        case ScreenResolutionOption.SRO_1440X900:
    //            return new Vector2(1440, 900);
    //        case ScreenResolutionOption.SRO_1680X1050:
    //            return new Vector2(1680, 1050);
    //        case ScreenResolutionOption.SRO_1920X1080:
    //            return new Vector2(1920, 1080);
    //        case ScreenResolutionOption.SRO_1920X1200:
    //            return new Vector2(1920, 1200);
    //        case ScreenResolutionOption.SRO_1920X1440:
    //            return new Vector2(1920, 1440);
    //        case ScreenResolutionOption.SRO_2560X1440:
    //            return new Vector2(2560, 1440);
    //        case ScreenResolutionOption.SRO_3840X2160:
    //            return new Vector2(3840, 2160);
    //        default:
    //            throw new ArgumentOutOfRangeException(nameof(sro), sro, null);
    //    }
    //}
}