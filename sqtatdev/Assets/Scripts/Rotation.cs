using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
       public float RotationSpeed1;
       public float RotationSpeed2;

       public float RotationSpeed3;

    void start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotationSpeed1*Time.deltaTime, RotationSpeed2*Time.deltaTime, RotationSpeed3*Time.deltaTime, Space.World);
    }
}
