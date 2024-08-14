using System.Collections.Generic;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// ������� � �������� �� ����������.
    /// </summary>
    public interface IKey
    {
        /// <summary>
        /// ������ �������.
        /// </summary>
        public char Symbol { get; }

        /// <summary>
        /// ��������� �������.
        /// </summary>
        public IReadOnlyCollection<IKey> Subkeys { get; }
    }
}
