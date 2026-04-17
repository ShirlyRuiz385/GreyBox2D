using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaceCarController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private float speedDecay = 1f;

    private Vector2 vector = Vector2.zero;
    private float currentSpeed = 0f;
    private bool isSpeedingUp = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        vector = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        currentSpeed = 0f;
        isSpeedingUp = false;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSpeedingUp = true;
        }

        if (context.canceled)
        {
            isSpeedingUp = false;
        }
    }

    private void Update()
    {
        float h = vector.x;
        float v = vector.y;
        transform.Translate(new Vector3(h, v, 0) * currentSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(clampedX, clampedY, 0);

        if (isSpeedingUp)
        {
            currentSpeed += speed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= speedDecay * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        RaceCarEventManager.ChangeSpeed(currentSpeed);
    }
}
