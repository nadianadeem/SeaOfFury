﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMaker : MonoBehaviour
{
    public int Dimension = 10;
    public float UVScale;
    public Octave[] Octaves;

    protected MeshFilter MeshFilter;

    protected Mesh Mesh;
    Mesh meshToCollide;

    
    // Start is called before the first frame update
    void Start()
    {
        Mesh = new Mesh();
        Mesh.name = gameObject.name;

        Mesh.vertices = GenerateVerts();
        Mesh.uv = GenerateUVs();
        Mesh.triangles = GenerateTries();

        Mesh.RecalculateNormals();
        Mesh.RecalculateBounds();

        MeshFilter = gameObject.AddComponent<MeshFilter>();
        MeshFilter.mesh = Mesh;

    }

    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(Dimension + 1) * (Dimension + 1)];

        for (int x = 0; x <= Dimension; x++)
        {
            for (int z = 0; z <= Dimension; z++)
            {
                verts[index(x, z)] = new Vector3(x, 0, z);
            }
        }

        return verts;
    }

    private int index(int x, int z)
    {
        return x * (Dimension + 1) + z;
    }

    private int[] GenerateTries()
    {
        var tries = new int[Mesh.vertices.Length * 6];

        for (int x = 0; x < Dimension; x++)
        {
            for (int z = 0; z < Dimension; z++)
            {
                tries[index(x, z) * 6 + 0] = index(x, z);
                tries[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                tries[index(x, z) * 6 + 2] = index(x + 1, z);
                tries[index(x, z) * 6 + 3] = index(x, z);
                tries[index(x, z) * 6 + 4] = index(x, z + 1);
                tries[index(x, z) * 6 + 5] = index(x + 1, z + 1);
            }
        }

        return tries;
    }

    private Vector2[] GenerateUVs()
    {
        var uvs = new Vector2[Mesh.vertices.Length];

        for (int x = 0; x <= Dimension; x++){

            for (int z = 0; z <= Dimension;z++){

                var vec = new Vector2((x / UVScale) % 2, (z / UVScale % 2));
                uvs[index(x, z)] = new Vector2(vec.x <= 1 ? vec.x : 2 - vec.x, vec.y <= 1? vec.y : 2 - vec.y);
            }
        }
        
        return uvs;
    }

    public float getHeight(Vector3 position){
        var scale = new Vector3(1 / transform.lossyScale.x, 0, 1 / transform.lossyScale.z);
        var localPos = Vector3.Scale((position - transform.position), scale);

        var p1 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Floor(localPos.z));
        var p2 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Ceil(localPos.z));
        var p3 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Floor(localPos.z));
        var p4 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Ceil(localPos.z));

        p1.x = Mathf.Clamp(p1.x, 0, Dimension);
        p1.z = Mathf.Clamp(p1.z, 0, Dimension);
        p2.x = Mathf.Clamp(p2.x, 0, Dimension);
        p2.z = Mathf.Clamp(p2.z, 0, Dimension);
        p3.x = Mathf.Clamp(p3.x, 0, Dimension);
        p3.z = Mathf.Clamp(p3.z, 0, Dimension);
        p4.x = Mathf.Clamp(p4.x, 0, Dimension);
        p4.z = Mathf.Clamp(p4.z, 0, Dimension);

        var max = Mathf.Max(Vector3.Distance(p1, localPos), Vector3.Distance(p2, localPos), Vector3.Distance(p3, localPos), Vector3.Distance(p4, localPos));
        var dist = (max - Vector3.Distance(p1, localPos)) + (max - Vector3.Distance(p2, localPos)) + (max - Vector3.Distance(p3, localPos)) + (max - Vector3.Distance(p4, localPos)+ Mathf.Epsilon);

        var height = Mesh.vertices[index(Convert.ToInt32(p1.x), Convert.ToInt32(p1.z))].y * (max - Vector3.Distance(p1, localPos)) 
                    + Mesh.vertices[index(Convert.ToInt32(p2.x), Convert.ToInt32(p2.z))].y * (max - Vector3.Distance(p2, localPos)) 
                    + Mesh.vertices[index(Convert.ToInt32(p3.x), Convert.ToInt32(p3.z))].y * (max - Vector3.Distance(p3, localPos)) 
                    + Mesh.vertices[index(Convert.ToInt32(p4.x), Convert.ToInt32(p4.z))].y * (max - Vector3.Distance(p4, localPos));
        
        return height * transform.lossyScale.y / dist;
    }

    // Update is called once per frame
    void Update()
    {
        MeshCollider collider = gameObject.GetComponent<MeshCollider>();
        collider.sharedMesh = Mesh;

        var verts = Mesh.vertices;

        for (int x = 0; x <= Dimension; x++)
        {
            for (int z = 0; z <= Dimension; z++)
            {
                var y = 0f;

                for (int o = 0; o < Octaves.Length; o++)
                {
                    if (Octaves[o].alternate)
                    {
                        var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x) / Dimension, (z * Octaves[o].scale.y) / Dimension) * Math.PI * 2f;
                        float perlFloat = (float)perl;
                        y += Mathf.Cos(perlFloat + Octaves[o].speed.magnitude * Time.time) * Octaves[o].height;
                    }
                    else
                    {
                        var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x + Time.time * Octaves[o].speed.x) / Dimension, (z * Octaves[o].scale.y + Time.time * Octaves[o].speed.y) / Dimension) - 0.5f;
                        float perlFloat = (float)perl;
                        y += perlFloat * Octaves[o].height;
                    }
                }
                verts[index(x, z)] = new Vector3(x, y, z);
            }
        }

        Mesh.vertices = verts;
        Mesh.RecalculateNormals();
    }

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;
    }
}
