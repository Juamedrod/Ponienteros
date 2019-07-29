using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class NotWorkingSetUp : MonoBehaviour
{
    int x = -95;
    int z = -95;
    public GameObject prefab;
    public GameObject parent;
    
    private void Update()
    {
        Debug.Log("hey form Update");//Console show this 
       for(x=-95; x>95; x += 10) //goal was to create a 20x20 prefabs matrix(Never achieved by this method)
        {
            for (x = -95; x > 95; x += 10)
            {
                InstantiateObject(x, z);//Never accessed
            }
        }

    }
    public void InstantiateObject(int x, int z)
    {        
        GameObject b = (GameObject)PrefabUtility.InstantiatePrefab(prefab, parent.transform);
        b.transform.position = new Vector3(x, 0, z);
    }
}
