using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Core.Keyboard.Models
{
    /// <summary>
    /// Набор клавиш с символами.
    /// </summary>
    [CreateAssetMenu(fileName = "KeySet", menuName = "Keyboard/KeySet")]
    public sealed class KeySet : ScriptableObject
#if UNITY_EDITOR
        , IDataLoader<Key[]>
#endif
    {
        [SerializeField] private Key[] keys;

        /// <summary>
        /// Список всех клавиш данного набора.
        /// </summary>
        public IReadOnlyCollection<Key> Keys => keys;

#if UNITY_EDITOR
        /// <summary>
        /// Позволяет загрузить набор из текстового файла.
        /// </summary>
        void IDataLoader<Key[]>.LoadData(Key[] data)
        {
            keys = data;
        }
#endif
    }
}

