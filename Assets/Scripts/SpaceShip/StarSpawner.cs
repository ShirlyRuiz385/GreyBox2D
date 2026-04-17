using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 5)] private float starSpeed = 1f;
    [SerializeField, Range(0, 5)] private float enemySpeed = 1f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxDelay = 5f;
    [SerializeField] private float maxEnemyDelay = 5f;
    [SerializeField] private Star starPrefab = null;
    [SerializeField] private Enemy enemyPrefab = null;

    private int direction = 1;
    private float currentDelay = 0f;
    private float currentEnemyDelay = 0f;


    void Start()
    {
        direction = 1;
        currentDelay = 0;
        currentEnemyDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction > 0 && transform.position.x > 9.5f)
        {
            direction = -1;
        }

        if (direction < 0 && transform.position.x < -9.5f)
        {
            direction = 1;
        }

        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * direction), transform.position.y, transform.position.z);
        currentDelay -= Time.deltaTime;
        if (currentDelay < 0f)
        {
            Instantiate(starPrefab, transform.position, Quaternion.identity);
            starPrefab.Speed = -starSpeed;
            currentDelay = Random.Range(0, maxDelay);
        }

        currentEnemyDelay -= Time.deltaTime;
        if (currentEnemyDelay < 0f)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyPrefab.Speed = -enemySpeed;
            currentEnemyDelay = Random.Range(0, maxEnemyDelay);
        }
    }
}
