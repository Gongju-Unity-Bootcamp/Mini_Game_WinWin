using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaSpawner : MonoBehaviour
{
    public GameObject jengaPrefab;
    public int jengaLayers = 5;

    private void Start()
    {
        CreateJengaStack();
    }
    void Update()
    {

    }

    void CreateJengaStack()
    {
        for (int index = 0; index < jengaLayers; ++index)
        {
            GameObject jenga = Instantiate(jengaPrefab, new Vector3(0, index, 0), Quaternion.identity);

            jenga.transform.parent = transform;
        }
    }
}
