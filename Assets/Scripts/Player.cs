using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction moveAction;

    private Collider playerCollider;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float upperLimit = 4.25f;
    [SerializeField] private float lowerLimit = -4.25f;

    private void Awake()
    {
        InputActions = Instantiate(InputActions);
        moveAction = InputActions.FindActionMap("PongPlayer").FindAction("Move");
        playerCollider = GetComponent<Collider>();
    }

    void OnEnable()
    {
        moveAction.Enable();
    }
    
    void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        float axis = moveAction.ReadValue<float>();
        Vector3 position = transform.position;
        position.y += axis * speed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, lowerLimit, upperLimit);    
        transform.position = position;
    }
}
