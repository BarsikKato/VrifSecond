using Core.Keyboard.Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

namespace Core.Keyboard.Models
{

    /// <inheritdoc  cref="Core.Keyboard.Abstractions.IKeySet"/>
    [CreateAssetMenu(fileName = "KeySet", menuName = "Keyboard/KeySet")]
    public sealed class KeySet : ScriptableObject, IKeySet
#if UNITY_EDITOR
        , IDataLoader<Key[]>
#endif
    {
        [SerializeField] private Key[] keys;

        /// <inheritdoc/>
        public IReadOnlyList<IKey> Keys => keys.Select(x => x as IKey).ToArray();

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

