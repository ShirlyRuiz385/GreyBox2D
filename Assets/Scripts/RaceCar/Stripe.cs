using UnityEngine;

public class Stripe : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private Transform start = null;
    [SerializeField] private Transform end = null;

    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        RaceCarEventManager.OnChangeSpeed += OnChangeSpeed;
    }

    private void OnChangeSpeed(float value)
    {
        speed = -value;
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        if (transform.position.y <= end.position.y)
        {
            transform.position = start.position;
        }
    }
}
