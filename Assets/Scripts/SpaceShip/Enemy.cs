using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = -1f;
    [SerializeField] private float killDistance = -1000f;

    public float Speed { get => speed; set => speed = value; }

    private void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        if (transform.position.y < killDistance)
        {
            Destroy(gameObject);
        }
    }
}
