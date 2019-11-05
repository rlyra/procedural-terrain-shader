using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentCreation : MonoBehaviour
{
    public GameObject player;
    public GameObject terrainTile;
    public int terrainWidth;
    public int terrainHeight;

    void Start()
    {

        float startPointW = terrainTile.GetComponent<TerrainMesh>().size * -0.5f;
        float startPointH = terrainTile.GetComponent<TerrainMesh>().size * -0.5f;

        for(int i = 0; i < terrainWidth; i++)
        {
            for (int j = 0; j < terrainHeight; j++)
            {
                Instantiate(terrainTile, new Vector3(startPointW + i, 1, startPointH + j), Quaternion.identity);
            }
        }

        GameObject players = Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
    }
}
