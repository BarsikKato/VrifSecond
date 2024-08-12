using Core.Keyboard.Abstractions;
using System.Collections.Generic;

namespace Core.Keyboard.Providers
{
    /// <summary>
    /// ������������� ������ ��������� ���������.
    /// </summary>
    public interface IKeyboardLayoutProvider
    {
        IList<IKeyboardLayout> GetKeyboardLayouts();
    }
}
