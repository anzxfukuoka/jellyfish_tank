using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject jellyPrefab;

    public Vector3 rotAngle;

    public Vector3 rotSpeed;

    public float spawnDelay = 1f;

    public Vector3 spawnRect;

    public GameObject[] jellyList;

    float upperEdge;
    float lowerEdge;

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(0.6f, 0, 0.8f, 0.4f);
        Gizmos.DrawCube(transform.position + spawnRect/2, spawnRect);
    }

    // Start is called before the first frame update
    void Start()
    {
        lowerEdge = transform.position.y;
        upperEdge = transform.position.y + spawnRect.y;

        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < jellyList.Length; i++)
        {
            Vector3 position = new Vector3(Random.Range(transform.position.x , transform.position.x + spawnRect.x), Random.Range(transform.position.y, transform.position.y + spawnRect.y), Random.Range(transform.position.z, transform.position.z + spawnRect.z));

            GameObject j = Instantiate(jellyPrefab, position, Quaternion.Euler(rotAngle));
            jellyList[i] = j;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotAngle += rotSpeed;

        for (int i = 0; i < jellyList.Length; i++)
        {
            jellyList[i].transform.rotation = Quaternion.Euler(rotAngle);

            if (jellyList[i].transform.position.y > upperEdge)
                jellyList[i].transform.position = new Vector3(jellyList[i].transform.position.x, lowerEdge, jellyList[i].transform.position.z);

            if (jellyList[i].transform.position.y < lowerEdge)
                jellyList[i].transform.position = new Vector3(jellyList[i].transform.position.x, upperEdge, jellyList[i].transform.position.z);
        }
    }
}
