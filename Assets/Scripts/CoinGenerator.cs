using Newtonsoft.Json.Bson;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultuplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateCoin();
    }

    public void GenerateNextCoinWithGap()
    {
        float randomWait = Random.Range(0.1f, 8.2f);
        Invoke("generateCoin", randomWait);
    }

    void generateCoin()
    {
        GameObject SpikeIns = Instantiate(coin,transform.position, transform.rotation);

        SpikeIns.GetComponent<CoinScript>().coinGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {    
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultuplier;
        }
    }
}
