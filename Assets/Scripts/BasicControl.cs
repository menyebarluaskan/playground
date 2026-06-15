using UnityEngine;
using UnityEngine.InputSystem;

public class BasicControl : MonoBehaviour
{
    InputAction moveAction;
    InputAction resetAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World");
        moveAction = InputSystem.actions.FindAction("Player/Move", throwIfNotFound: true);
        resetAction = InputSystem.actions.FindAction("Player/Jump", throwIfNotFound: true);
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction.IsPressed())
        {
            Vector2 inputVector = moveAction.ReadValue<Vector2>();
            float rotationAmount = 90f * Time.deltaTime * 10f;
            transform.Rotate(inputVector.y * rotationAmount, 0, inputVector.x * rotationAmount);
        }
        if (resetAction.IsPressed())
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
