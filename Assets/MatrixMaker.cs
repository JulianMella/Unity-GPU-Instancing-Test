using System.Collections.Generic;
using UnityEngine;

public class MatrixMaker : MonoBehaviour
{
    public Vector3 position, rotation, scale;
    public Material material;  
    public Mesh mesh;
    private Matrix4x4 _matrix;
    private List<Matrix4x4> _matrices = new List<Matrix4x4>();

    void Start()
    {
        _matrix = Matrix4x4.TRS(position, Quaternion.Euler(rotation), scale);
        _matrices.Add(_matrix);
    }


    public void Update()
    {
        Graphics.DrawMeshInstanced(mesh, 0, material, _matrices);
    }
}
