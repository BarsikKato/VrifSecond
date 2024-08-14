using System.Collections.Generic;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// Набор клавиш с символами.
    /// </summary>
    public interface IKeySet
    {
        /// <summary>
        /// Список всех клавиш данного набора.
        /// </summary>
        public IReadOnlyList<IKey> Keys { get; }
    }
}
