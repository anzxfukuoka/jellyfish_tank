using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jelly_anim : MonoBehaviour
{

    public float time = 0;

    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Mesh skinnedMesh;

    public float speed = 6f;
    public float step = 6f;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
       
    }

    void Update()
    {
        time += Time.deltaTime;
        skinnedMeshRenderer.SetBlendShapeWeight(0, Mathf.Sin(time * speed) * 50 + 50);
        skinnedMeshRenderer.SetBlendShapeWeight(1, Mathf.Cos(time * speed) * 50 + 50);

        transform.Translate(new Vector3(0, 0, Mathf.Cos(time * speed + Mathf.PI/2) * step + step / 2), Space.Self);
    }
}
