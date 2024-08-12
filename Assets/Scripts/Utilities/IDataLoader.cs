namespace Utilities
{
    /// <summary>
    /// Позволяет загрузить данные в объект.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataLoader<in T>
    {
        /// <summary>
        /// Загрузить данные в объект.
        /// </summary>
        void LoadData(T data);
    }
}
