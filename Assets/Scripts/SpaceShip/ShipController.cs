using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform spawnPoint = null;

    private Vector2 vector = Vector2.zero;

    public void OnMove(InputValue value)
    {
        vector = value.Get<Vector2>();
    }

    public void OnFire()
    {
        Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
    }

    private void Update()
    {
        float h = vector.x;
        float v = vector.y;
        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -8.5f, 8.5f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(clampedX, clampedY, 0);
    }
}
