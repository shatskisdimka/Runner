using Newtonsoft.Json.Bson;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EagleGenerator : MonoBehaviour
{
    public GameObject eagle;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultuplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateEagle();
    }

    public void GenerateNextEagleWithGap()
    {
        float randomWait = Random.Range(0.1f, 5.2f);
        Invoke("generateEagle", randomWait);
    }

    void generateEagle()
    {
        GameObject SpikeIns = Instantiate(eagle,transform.position, transform.rotation);

        SpikeIns.GetComponent<EagleScript>().eagleGenerator = this;
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
