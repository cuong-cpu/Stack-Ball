using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    private float minY;

    private float Offset;
    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position.y - Target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.position.y < minY)
        {
            minY = Target.position.y;
            transform.position = new Vector3(transform.position.x, minY + Offset, transform.position.z);
        }
        
    }
}
