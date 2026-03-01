using UnityEngine;

public class MakeFloor : MonoBehaviour
{
    GameManager gameManager;

    public GameObject floor;
    public GameObject noFloor;

    int spawnFailCount = 0; //3번 이상 공허가 만들어지지 않도록 카운트

    float spawnGap = 3.2f;
    float nextSpawnX = 12.8f;
    GameObject lastSpawned;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        lastSpawned = Instantiate(floor, new Vector3(12.8f, -4.2f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (lastSpawned != null && lastSpawned.transform.position.x <= 9.6f)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(12.8f, -4.2f, 0);

        if (spawnFailCount >=2)
        {
            lastSpawned = Instantiate(floor, pos, Quaternion.identity);
            spawnFailCount = 0;
            return;
        }

        if (Random.value < 0.5f)
        {
            lastSpawned = Instantiate(floor, pos, Quaternion.identity);
            spawnFailCount = 0;
        }
        else
        {
            lastSpawned = Instantiate(noFloor, pos, Quaternion.identity);
            spawnFailCount++;
            gameManager.AddScore();
        }
    }
}
