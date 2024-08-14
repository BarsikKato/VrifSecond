using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    /// <summary>
    /// Шаблонный класс для кнопок в UI.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class ButtonView : MonoBehaviour
    {
        [SerializeField] protected Button button;

        protected virtual void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();

        #if UNITY_EDITOR

        protected virtual void OnValidate()
        {
            button ??= GetComponent<Button>();
        }

        #endif
    }
}
