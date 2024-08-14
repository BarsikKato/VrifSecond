using Core.Keyboard.Abstractions;
using System.Collections.Generic;

namespace Core.Keyboard.Providers
{
    public sealed class KeyboardLayoutProvider : IKeyboardLayoutProvider
    {
        private readonly IList<IKeyboardLayout> _layouts;

        public KeyboardLayoutProvider(IList<IKeyboardLayout> layouts) 
        {
            _layouts = layouts;
        }

        public IList<IKeyboardLayout> GetKeyboardLayouts() =>
            _layouts;
    }
}
