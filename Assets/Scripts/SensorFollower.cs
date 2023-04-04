using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorFollower : MonoBehaviour
{

    public GameObject[] Sensors;
    private int currentSensorIndex;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentSensorIndex = 0;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Sensors[currentSensorIndex].transform.position, transform.position) < .1f)
        {
            currentSensorIndex++;
            if(currentSensorIndex >= Sensors.Length)
            {
                currentSensorIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Sensors[currentSensorIndex].transform.position, Time.deltaTime*speed);
    }
}
