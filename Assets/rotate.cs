using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rotate : MonoBehaviour
{
    Vector3 add_pos;
    // Start is called before the first frame update
    void Start(){
        add_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, .5f, 0);
        add_pos.y = transform.position.y + (Mathf.Sin(Time.realtimeSinceStartup) * Time.deltaTime);
        transform.position = add_pos;
    }
}
