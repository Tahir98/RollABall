using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        transform.position = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Space space = new Space();
        Vector3 vec = new Vector3(1,1,0);

        transform.Rotate(vec,3);
    }
}
