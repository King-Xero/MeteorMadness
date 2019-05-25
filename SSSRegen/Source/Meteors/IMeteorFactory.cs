namespace SSSRegen.Source.Meteors
{
    public interface IMeteorFactory
    {
        Meteor CreateSmallMeteor();
        Meteor CreateMediumMeteor();
    }
}