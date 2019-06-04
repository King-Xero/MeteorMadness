namespace SSSRegen.Source.GameComponents.Input
{
    public interface IInputComponent<T>
    {
        void Initialize(T entity);
        void Update(T entity);
    }
}