using Core.Keyboard.Abstractions;
using Core.Keyboard.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Keyboard.Views
{
    public sealed class KeyboardLayoutView : MonoBehaviour
    {
        [SerializeField] private Transform layoutKeysRoot;
        [SerializeField] private SymbolKeyButtonView symbolKeyPrefab;
        [SerializeField] private Transform layoutKeysRowPrefab;

        [Inject] private readonly IKeyboardController _keyboardController;
        [Inject] private readonly DiContainer _diContainer;

        // Нужен для того, чтобы не инстансить
        // весь набор кнопок при смене раскалдки
        private readonly List<SymbolKeyButtonView> _layoutKeysPool = new();
        private readonly List<Transform> _layoutKeysRows = new();

        private void Awake()
        {
            _keyboardController.KeyboardLayoutChanged += KeyboardController_KeyboardLayoutChanged;
        }

        private void OnDestroy()
        {
            _keyboardController.KeyboardLayoutChanged -= KeyboardController_KeyboardLayoutChanged;
        }

        private void KeyboardController_KeyboardLayoutChanged(IKeyboardLayout layout)
        {
            ChangeLayoutKeys(layout);
        }

        private void ChangeLayoutKeys(IKeyboardLayout layout)
        {
            IReadOnlyList<IKey> keys = layout.KeySet.Keys;
            if (_layoutKeysPool.Count < keys.Count)
            {
                AddItemsToPool(keys.Count - _layoutKeysPool.Count);
            }

            IEnumerator<int> rowLengthsEnumerator = layout.RowLengths.GetEnumerator();
            int currentRow = -1;
            int currentRowFreeSpace = 0;
            ClearRows();
            for (int i = 0; i < _layoutKeysPool.Count; i++)
            {
                SymbolKeyButtonView view = _layoutKeysPool[i];
                if (i >= keys.Count)
                {
                    view.gameObject.SetActive(false);
                    continue;
                }

                if (currentRowFreeSpace == 0)
                {
                    currentRow++;
                    MoveRowLengthsEnumerator(rowLengthsEnumerator);
                    currentRowFreeSpace = rowLengthsEnumerator.Current;
                }

                Transform rowTransform = GetCurrentRowTransform(currentRow);
                view.transform.SetParent(rowTransform, false);
                // Фикс странного бага со скейлом.
                view.transform.localScale = Vector3.one;
                currentRowFreeSpace--;

                view.SetSymbol(keys[i].Symbol);
                view.gameObject.SetActive(true);
            }
        }

        private void AddItemsToPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var symbolKeyView = _diContainer
                    .InstantiatePrefabForComponent<SymbolKeyButtonView>(symbolKeyPrefab);

                _layoutKeysPool.Add(symbolKeyView);
            }
        }

        private void MoveRowLengthsEnumerator(IEnumerator<int> rowLengthsEnumerator)
        {
            if (!rowLengthsEnumerator.MoveNext())
            {
                rowLengthsEnumerator.Reset();
                rowLengthsEnumerator.MoveNext();
            }
        }

        private Transform GetCurrentRowTransform(int currentRow)
        {
            if (currentRow == _layoutKeysRows.Count)
            {
                Transform row = Instantiate(layoutKeysRowPrefab, layoutKeysRoot, false);
                row.localScale = Vector3.one;
                _layoutKeysRows.Add(row);
            }

            return _layoutKeysRows[currentRow];
        }

        private void ClearRows()
        {
            while (_layoutKeysRows.Count != 0)
            {
                Transform lastRow = _layoutKeysRows[_layoutKeysRows.Count - 1];
                _layoutKeysRows.Remove(lastRow);
                lastRow.DetachChildren();

                Destroy(lastRow.gameObject);
            }
        }
    }
}

