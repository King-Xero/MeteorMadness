namespace SSSRegen.Source.Core.Interfaces
{
    public interface IHandleCollisions : IGameObject
    {
        void CollidedWith(IHandleCollisions gameObject);
    }
}