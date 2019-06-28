namespace SSSRegen.Source.Meteors
{
    public interface IMeteorFactory
    {
        Meteor CreateBigMeteor();
        Meteor CreateMediumMeteor();
        Meteor CreateSmallMeteor();
        Meteor CreateTinyMeteor();
    }
}