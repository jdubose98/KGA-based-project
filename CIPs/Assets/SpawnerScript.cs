using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;

    [SerializeField] bool Use1;
    [SerializeField] bool Use2;
    [SerializeField] bool Use3;

    [SerializeField] float lRange = -5;
    [SerializeField] float rRange = 5;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnEnemy", 10, 10);
	}
	
	// Update is called once per frame
	void SpawnEnemy()
    {
        Debug.LogWarning("Should have spawned!");
        int randomValue = Random.Range(1, 3);
        switch (randomValue)
        {
            case 1:
                if (Use1)
                {
                    GameObject enemyClone = Instantiate(enemy1);
                    enemyClone.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(lRange, rRange), gameObject.transform.position.y + Random.Range(lRange, rRange),0);
                }
                break;
            case 2:
                if (Use2)
                {
                    GameObject enemyClone = Instantiate(enemy2);
                    enemyClone.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(lRange, rRange), gameObject.transform.position.y + Random.Range(lRange, rRange), 0);
                }
                break;
            case 3:
                if (Use3)
                {
                    GameObject enemyClone = Instantiate(enemy3);
                    enemyClone.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(lRange, rRange), gameObject.transform.position.y + Random.Range(lRange, rRange), 0);
                }
                break;

        }
    }
}
