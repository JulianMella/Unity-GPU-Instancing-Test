using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public int Instances;

    public Mesh mesh;

    public Material[] Materials;
    
    // Double list is because batches are capped to a 1000.
    // If we want 10,000 instances, then we need 10 Batches of a 1000 matrices.
    private List<List<Matrix4x4>> Batches = new List<List<Matrix4x4>>();
    private void RenderBatches()
    {
        foreach (var Batch in Batches)
        {
            Graphics.DrawMeshInstanced(mesh, 0, Materials[0], Batch);
        }
}
    // Update is called once per frame
    void Update()
    {
        RenderBatches();
    }

    private void Start()
    {
        var addedMatrices = 0;

        Batches.Add(new List<Matrix4x4>());
        
        for (int i = 0; i < Instances; i++)
        {
            var randT = new Vector3(Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50));
            var randR = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            var s1 = new Vector3(1, 1, 1);
            if (addedMatrices < 1000)
            {
                Batches[Batches.Count - 1].Add(Matrix4x4.TRS(randT, randR, s1));
                addedMatrices++;
            }
            else
            {
                Batches.Add(new List<Matrix4x4>());
                addedMatrices = 0;
            }
        }
    }
}
