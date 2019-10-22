using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        CriarCubos();
    }

    // Update is called once per frame
    void Update()
    {
        /*testeLeve();
        testeMedio();
        testePesado();*/
    }

    void CriarCubos()
    {
        for(int i = 0; i < 2048; i++)
        {
            GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            esfera.AddComponent<Rigidbody>();
        }
    }

    void testeLeve()
    {
        for(int i = 0; i < 100; i++)
        {
            Debug.Log(i);
        }
    }
    void testeMedio()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
        }
    }
    void testePesado()
    {
        for (int i = 0; i < 1000; i++)
        {
            Debug.Log(i);
        }
    }
}
