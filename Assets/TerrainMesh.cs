using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class TerrainMesh : MonoBehaviour
{
    public Gradient gradient;

    public float density = 1;
    public float size = 1;

    int width, height;

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        width = (int)Mathf.Round(size / density);
        height = (int)Mathf.Round(size / density);

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    
    void CreateShape()
    {
        vertices = new Vector3[(1 + width) * (1 + height)];
        
        for(int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                vertices[i * (height + 1) + j] = new Vector3(i * density, 0, j * density);
            }
        }

        triangles = new int[height * width * 6];

        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                triangles[(i * height + j) * 6 + 0] = i * (height + 1) + j;
                triangles[(i * height + j) * 6 + 1] = (i + 1) * (height + 1) + j + 1;
                triangles[(i * height + j) * 6 + 2] = (i + 1) * (height + 1) + j;

                triangles[(i * height + j) * 6 + 3] = i * (height + 1) + j;
                triangles[(i * height + j) * 6 + 4] = i * (height + 1) + j + 1;
                triangles[(i * height + j) * 6 + 5] = (i + 1) * (height + 1) + j + 1;

            }
        }

    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
