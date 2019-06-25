namespace SSSRegen.Source.GameComponents.Graphics
{
    public interface IGraphicsComponent<T>
    {
        void Initialize(T entity);
        void Update(T entity);
        void Draw(T entity);
    }
}