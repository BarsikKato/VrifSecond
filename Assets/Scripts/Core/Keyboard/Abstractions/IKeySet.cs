using System.Collections.Generic;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// ����� ������ � ���������.
    /// </summary>
    public interface IKeySet
    {
        /// <summary>
        /// ������ ���� ������ ������� ������.
        /// </summary>
        public IReadOnlyList<IKey> Keys { get; }
    }
}
