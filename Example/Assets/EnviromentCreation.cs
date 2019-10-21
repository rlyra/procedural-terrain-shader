using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentCreation : MonoBehaviour
{
    public GameObject terrainTile;
    public int terrainWidth;
    public int terrainHeight;

    void Start()
    {
        float startPointW = terrainWidth / -2.0f;
        float startPointH = terrainHeight / -2.0f;

        for(int i = 0; i < terrainWidth; i++)
        {
            for (int j = 0; j < terrainHeight; j++)
            {
                Instantiate(terrainTile, new Vector3(startPointW + i, 0, startPointH + j), Quaternion.identity);
            }
        }
    }
}
