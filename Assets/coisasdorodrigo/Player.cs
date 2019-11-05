using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity = 10;
    public float angularVelocity = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(gameObject.transform.forward * velocity * Time.deltaTime);

        gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime, 0));
    }
}
