using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : MonoBehaviour
{
    public DiplomacyAgent agent;
    public GameObject panelDisplayEnemy;
    public ShowEnemyStats showEnemyStats;
    FloorManagement floorManagement;
    

    void Awake()
    {
        showEnemyStats = FindObjectOfType<ShowEnemyStats>();
        panelDisplayEnemy = showEnemyStats.gameObject;
        floorManagement = FindObjectOfType<FloorManagement>();
    }

    private void Start()
    {
        foreach (FloorControl f in floorManagement.floorControls)
        {
            if (f.transform.position == transform.position)
            {
                f.occupied = true; ;
            }
        }
    }

    private void OnMouseDown()
    {
        panelDisplayEnemy.SetActive(true);
        if (agent!=null)showEnemyStats.ShowFromMouseOver(agent);
    }

    private void Update()
    {
        if (agent.diplomacyStrength <= 0)
        {
            GameManager.gameManager.enemiesDestroyed++;
            Destroy(this.gameObject);
        }

    }

    public void DestroyAgent()
    {
        Destroy(this.gameObject);
    }
}
