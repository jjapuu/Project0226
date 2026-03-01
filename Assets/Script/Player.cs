using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    float xmin = -8.0f;
    float xmax = 8.0f;

    bool isGrounded = false; //플레이어가 바닥에 있는지 여부를 나타내는 변수
    Rigidbody2D rb; //플레이어의 Rigidbody2D 컴포넌트를 저장하는 변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>(); //GameManager 스크립트를 찾아서 참조를 저장
        rb = GetComponent<Rigidbody2D>(); //플레이어의 Rigidbody2D 컴포넌트를 가져와서 저장
    }

    // Update is called once per frame
    void Update()
    {

        // 입력에 따라 플레이어 이동
        float xoff = Input.GetAxis("Horizontal") * gameManager.speedPlayer * Time.deltaTime; //수평 입력을 받아서 플레이어의 이동 오프셋을 계산
        Vector3 moveOffset = new Vector3(xoff, 0.0f, 0.0f); //플레이어의 이동 오프셋을 계산

        if (Input.GetKey(KeyCode.Space)&& isGrounded)
        {
            jumpPlayer();
        }
        transform.Translate(Vector3.left * gameManager.speedFloor * Time.deltaTime);

        // 경계값 제한
        Vector3 newPos = transform.position + moveOffset;
        newPos.x = Mathf.Clamp(newPos.x, xmin, xmax);

        transform.position = newPos; //플레이어의 위치를 업데이트

        // 플레이어가 화면 밖으로 나가면 EndScene으로 이동
        if (transform.position.y < -6.0f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) //충돌한 객체가 "Floor" 태그를 가진 경우
        {
            isGrounded = true; //플레이어가 바닥에 있다고 설정
        }
    }

    private void jumpPlayer()
    {
        rb.AddForce(Vector2.up * gameManager.GetJumpPower(), ForceMode2D.Impulse); //플레이어의 Rigidbody2D에 점프 힘을 추가하여 점프를 수행
        isGrounded = false; //점프 후에는 플레이어가 바닥에 있지 않다고 설정

    }
}
