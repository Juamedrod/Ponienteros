using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiscovered : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Avatar"))
        {
            enemy.SetActive(true);
        }
    }
}
