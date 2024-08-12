using System.Collections.Generic;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// ��������� ����������. ������������ �� ���� ����������� ����� ������ � ���������.
    /// </summary>
    public interface IKeyboardLayout
    {
        /// <summary>
        /// ������� �������� ���������.
        /// </summary>
        public string LayoutName { get; }

        /// <summary>
        /// ����� �������� ������ ���������.
        /// </summary>
        public IKeySet KeySet { get; }

        /// <summary>
        /// ����� ����� ��������.
        /// </summary>
        public IEnumerable<int> RowLengths { get; }
    }
}