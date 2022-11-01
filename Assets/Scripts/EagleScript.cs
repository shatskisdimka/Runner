using UnityEngine;

public class EagleScript : MonoBehaviour
{
    public EagleGenerator eagleGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * eagleGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            eagleGenerator.GenerateNextEagleWithGap();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
