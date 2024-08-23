using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;

    private Vector3 origin;
    float fov;
    private float startingAngle;

    private bool playerDetected;

    private void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        origin = Vector3.zero;
        startingAngle = 0f;
        playerDetected = false;
    }

    private void Update()
    {

        Vector3 raycastOrigin = transform.position;

        float raycastAngle = transform.eulerAngles.z;

        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int trianglesIndex = 0;
        int vertexIndex = 1;

        bool playerNotDetected = true;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;

            RaycastHit2D raycast = Physics2D.Raycast(raycastOrigin, UtilsClass.GetVectorFromAngle(raycastAngle), viewDistance);

            if (raycast.collider == null)
            {
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                if (raycast.collider.CompareTag("Player"))
                {
                    playerNotDetected = false;
                }
                vertex = transform.InverseTransformPoint(raycast.point);
                
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[trianglesIndex] = 0;
                triangles[trianglesIndex + 1] = vertexIndex - 1;
                triangles[trianglesIndex + 2] = vertexIndex;

                trianglesIndex += 3;
            }

            vertexIndex++;

            angle -= angleIncrease;
            raycastAngle -= angleIncrease;
        }

        playerDetected = !playerNotDetected;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(float aimDirection)
    {
        this.startingAngle = aimDirection - fov / 2f + 180;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        this.startingAngle = UtilsClass.GetAngleFromVector(aimDirection) - fov / 2f + 180;
    }

    /**
    * Retorna se o player está no campo de visão
    *
    */
    public bool IsPlayerDetected()
    {
        return playerDetected;
    }
}
