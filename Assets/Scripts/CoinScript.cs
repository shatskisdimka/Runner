using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinGenerator coinGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * coinGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            coinGenerator.GenerateNextCoinWithGap();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
