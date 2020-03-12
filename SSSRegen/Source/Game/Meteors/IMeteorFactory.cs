namespace SSSRegen.Source.Game.Meteors
{
    public interface IMeteorFactory
    {
        Meteor CreateBigMeteor();
        Meteor CreateMediumMeteor();
        Meteor CreateSmallMeteor();
        Meteor CreateTinyMeteor();
    }
}