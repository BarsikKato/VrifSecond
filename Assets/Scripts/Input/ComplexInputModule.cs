using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public sealed class ComplexInputModule : BaseInputModule
    {
        [SerializeField] private BaseInputModule[] modules;

        public override void Process()
        {
            foreach (BaseInputModule module in modules)
            {
                module.Process();
            }
        }
    }
}
