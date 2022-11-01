using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;
    BoxCollider2D BC;
    public float score;
    public int coin;
    public Text CoinTxt;
    public Text ScoreTxt;
    public float Highscore;
    private float coldownTime = 2;
    private float NextBoostTime = 0;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        BC = GetComponent<BoxCollider2D>();
        score = 0;
        coin = 0;
        Highscore = PlayerPrefs.GetFloat("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0);
            BC.size = new Vector2(1, 0.6f);
            BC.offset = new Vector2(0, -0.65f);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 1, 0);
            BC.size = new Vector2(1, 1);
            BC.offset = new Vector2(0, -0.5f);
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE : " + score.ToString("F");
            CoinTxt.text = "COIN: " + coin.ToString();

            if (score >= Highscore)
            {
                Highscore = score;
                PlayerPrefs.SetFloat("Highscore", Highscore);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Time.time > NextBoostTime)
            {
                if (coin >= 3)
                {
                    RB.AddForce(Vector2.up * JumpForce * 1.5f);
                    coin = coin - 3;
                    NextBoostTime = Time.time + coldownTime;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            coin++;
        }
    }
}
