using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefeb;

    [SerializeField]
    private float minDelay;
    [SerializeField]
    private float maxDelay;
    
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(spawnEnemy(Random.Range(minDelay, maxDelay), enemyPrefeb));
    }

    private IEnumerator spawnEnemy(float delay, GameObject enemy)
    {
        yield return new WaitForSeconds(delay);

        var spawnRange = new Vector3(
            Random.Range(-10, 10) + transform.position.x,
            0.5f,
            Random.Range(-10, 10) + transform.position.z);
        Instantiate(enemy, spawnRange, Quaternion.identity);

        StartCoroutine(spawnEnemy(Random.Range(minDelay, maxDelay), enemy));
    }
}
