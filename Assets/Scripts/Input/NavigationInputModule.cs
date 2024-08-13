using BNG;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Input
{
    [RequireComponent(typeof(VRUISystem))]
    public class NavigationInputModule : BaseInputModule
    {
        [SerializeField] private VRUISystem vrUiSystem;
        [SerializeField] private InputActionReference moveActionReference;
        [SerializeField] private InputActionReference selectActionReference;

        private readonly Dictionary<Vector2, MoveDirection> _moveDirections = new()
        {
            { Vector2.down, MoveDirection.Down },
            { Vector2.up, MoveDirection.Up },
            { Vector2.right, MoveDirection.Right },
            { Vector2.left, MoveDirection.Left },
        };

        protected override void OnEnable()
        {
            base.OnEnable();
            moveActionReference.action.Enable();
            selectActionReference.action.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            moveActionReference.action.Disable();
            selectActionReference.action.Disable();
        }

        protected override void Awake()
        {
            base.Awake();
            moveActionReference.action.performed += OnMoveActionPerformed;
            selectActionReference.action.performed += OnSelectActionPerformed;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            moveActionReference.action.performed -= OnMoveActionPerformed;
            selectActionReference.action.performed -= OnSelectActionPerformed;
        }

        public override void Process() { }

        private void OnMoveActionPerformed(InputAction.CallbackContext context)
        {
            Vector2 navigationInput = context.ReadValue<Vector2>();
            if (navigationInput == Vector2.zero)
                return;

            MoveDirection moveDirection = 
                _moveDirections.TryGetValue(navigationInput, out var value) ? value : MoveDirection.None;

            AxisEventData axisEventData = new AxisEventData(eventSystem)
            {
                moveDir = moveDirection
            };

            GameObject lastSelectedElement = GetLastSelectedElement();
            ExecuteEvents.Execute(
                lastSelectedElement, axisEventData, ExecuteEvents.moveHandler);
        }

        private void OnSelectActionPerformed(InputAction.CallbackContext context)
        {
            GameObject lastSelectedElement = GetLastSelectedElement();
            ExecuteEvents.Execute(
                lastSelectedElement, new PointerEventData(eventSystem), ExecuteEvents.pointerClickHandler);
        }

        private GameObject GetLastSelectedElement()
        {
            GameObject lastSelectedElement = eventSystem.currentSelectedGameObject;
            if (lastSelectedElement == null)
                lastSelectedElement = vrUiSystem.ReleasingObject;

            return lastSelectedElement;
        }
    }
}

