using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    public float rotationspeed = 15f;
    float Horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationspeed* Horizontal * Time.deltaTime);
    }
}
