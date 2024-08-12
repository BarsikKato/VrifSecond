namespace Utilities
{
    /// <summary>
    /// ��������� ��������� ������ � ������.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataLoader<in T>
    {
        /// <summary>
        /// ��������� ������ � ������.
        /// </summary>
        void LoadData(T data);
    }
}
