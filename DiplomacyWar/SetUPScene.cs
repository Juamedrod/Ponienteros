using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SetUPScene : MonoBehaviour
{
    int x = -95;
    int z=-95;
    public GameObject prefab;
    public GameObject parent;

    private void Awake()
    {
        x = -95;
        z = -95;
    }
    private void Update()
    {
        Debug.Log("hey form awake");
        x += 10;
        if (x > 95)
        {
            x = -95;
            z += 10;
        }
        InstantiateObject(x, z);
       
    }
    public void InstantiateObject(int x, int z)
    {
        //Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity, parent.transform);
        GameObject b=(GameObject)PrefabUtility.InstantiatePrefab(prefab,parent.transform);
        b.transform.position = new Vector3(x, 0, z);
    }

}
