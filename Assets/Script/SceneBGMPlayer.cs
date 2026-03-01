using UnityEngine;

public class SceneBGMPlayer : MonoBehaviour
{
    public AudioClip bgmjump; // 재생할 BGM 클립
    public AudioClip bgmStart;
    public AudioClip bgmGame;
    public AudioClip bgmEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        string scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        //씬에 따라 BGM 재생
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StartScene")
        {
            AudioSource.PlayClipAtPoint(bgmStart, transform.position, 0.4f);
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene")
        {
            AudioSource.PlayClipAtPoint(bgmGame, transform.position, 1.0f);
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "EndScene")
        {
            AudioSource.PlayClipAtPoint(bgmEnd, transform.position, 0.4f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //점프시 점프 사운드 재생
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(bgmjump, transform.position, 0.6f);
        }
    }

}
