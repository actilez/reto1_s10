using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCherry : MonoBehaviour
{
    public GameObject cherry;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = cherry.transform.position + new Vector3(0, 2, -5);
        transform.LookAt(cherry.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
