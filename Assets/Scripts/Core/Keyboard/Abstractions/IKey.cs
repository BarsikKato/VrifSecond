using System.Collections.Generic;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// Клавиша с символом на клавиатуре.
    /// </summary>
    public interface IKey
    {
        /// <summary>
        /// Символ клавиши.
        /// </summary>
        public char Symbol { get; }

        /// <summary>
        /// Вложенные клавиши.
        /// </summary>
        public IReadOnlyCollection<IKey> Subkeys { get; }
    }
}
