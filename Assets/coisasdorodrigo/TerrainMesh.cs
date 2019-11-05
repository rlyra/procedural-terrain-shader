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

        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vertices[(int)(Random.value * vertices.Length)].y = 10;
            mesh.vertices = vertices;
            gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        StartCoroutine(naoEhGambiarra());
    }

    IEnumerator naoEhGambiarra()
    {
        GameObject player = GameObject.FindWithTag("Player");
        float posX = player.transform.position.x;//collision.GetContact(0).point.x + size * 0.5f;
        float posZ = player.transform.position.z;//collision.GetContact(0).point.z + size * 0.5f;

        int posXi = (int)((posX + size * 0.5f) / density);
        int posZi = (int)((posZ + size * 0.5f) / density);


        yield return new WaitForSeconds(0.1f);

        float altura = 10;

        changeVertex(posXi - 2, posZi - 2, 1 / altura);
        changeVertex(posXi - 2, posZi - 1, 4 / altura);
        changeVertex(posXi - 2, posZi + 0, 7 / altura);
        changeVertex(posXi - 2, posZi + 1, 4 / altura);
        changeVertex(posXi - 2, posZi + 2, 1 / altura);

        changeVertex(posXi - 1, posZi - 2, 4 / altura);
        changeVertex(posXi - 1, posZi - 1, 16 / altura);
        changeVertex(posXi - 1, posZi + 0, 26 / altura);
        changeVertex(posXi - 1, posZi + 1, 16 / altura);
        changeVertex(posXi - 1, posZi + 2, 4 / altura);

        changeVertex(posXi + 0, posZi - 2, 7 / altura);
        changeVertex(posXi + 0, posZi - 1, 26 / altura);
        changeVertex(posXi + 0, posZi + 0, 28 / altura);
        changeVertex(posXi + 0, posZi + 1, 26 / altura);
        changeVertex(posXi + 0, posZi + 2, 7 / altura);

        changeVertex(posXi + 1, posZi - 2, 4 / altura);
        changeVertex(posXi + 1, posZi - 1, 16 / altura);
        changeVertex(posXi + 1, posZi + 0, 26 / altura);
        changeVertex(posXi + 1, posZi + 1, 16 / altura);
        changeVertex(posXi + 1, posZi + 2, 4 / altura);


        changeVertex(posXi + 2, posZi - 2, 1 / altura);
        changeVertex(posXi + 2, posZi - 1, 4 / altura);
        changeVertex(posXi + 2, posZi + 0, 7 / altura);
        changeVertex(posXi + 2, posZi + 1, 4 / altura);
        changeVertex(posXi + 2, posZi + 2, 1 / altura);

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }

    private void changeVertex(int x, int z, float val)
    {
        if (vertices[(int)(x * (height + 1) + z)].y < val)
        {
            vertices[(int)(x * (height + 1) + z)].y = val;
            //gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}
