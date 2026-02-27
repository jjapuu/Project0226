using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float speedBack = 2.0f;
    public float speedPlayer = 4.0f;
    public float jumpPlayer = 7.0f;
    public float speedFloor = 2.0f;


    public float GetJumpPower()
    {
        return jumpPlayer;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

}
