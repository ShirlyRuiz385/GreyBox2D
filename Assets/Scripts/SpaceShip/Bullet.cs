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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // mata al enemigo
            Destroy(gameObject);       // destruye la bala
        }
    }
}
