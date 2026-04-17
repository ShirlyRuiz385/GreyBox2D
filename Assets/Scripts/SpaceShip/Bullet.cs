using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = .1f;
    [SerializeField] private float killDistance = 1000f;

    private void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        if (transform.position.y > killDistance)
        {
            Destroy(gameObject);
        }
    }
}
