using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public GameObject frool;

    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float xoff = -gameManager.speedFloor * Time.deltaTime;
        transform.Translate(xoff, 0.0f, 0.0f);


        Vector3 pos = transform.position;
        if (pos.y <= -10.0f)
            Destroy(gameObject);
    }
}
