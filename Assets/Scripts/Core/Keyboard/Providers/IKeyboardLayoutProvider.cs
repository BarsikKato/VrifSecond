using Core.Keyboard.Abstractions;
using System.Collections.Generic;

namespace Core.Keyboard.Providers
{
    /// <summary>
    /// Предоставляет список доступных раскладок.
    /// </summary>
    public interface IKeyboardLayoutProvider
    {
        IList<IKeyboardLayout> GetKeyboardLayouts();
    }
}
