using Core.Keyboard.Abstractions;
using System.Collections.Generic;

namespace Core.Keyboard.Providers
{
    /// <summary>
    /// ѕредоставл€ет список доступных раскладок.
    /// </summary>
    public interface IKeyboardLayoutProvider
    {
        IList<IKeyboardLayout> GetKeyboardLayouts();
    }
}
