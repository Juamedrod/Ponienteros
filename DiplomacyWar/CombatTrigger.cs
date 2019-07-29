using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    Avatar avatar;
    WaitForSeconds waitForSeconds;
    private bool engaging=true;
    Combats combats;

    public float distanceToEngage=15f;
    public GameObject panelCombats;

    private void Awake()
    {
        avatar = GetComponent<Avatar>();
        waitForSeconds = new WaitForSeconds(1);
        panelCombats = GameObject.Find("P_Combats");
        combats = panelCombats.GetComponent<Combats>();
        
    }

    public void ObjetiveLooking()
    {
        engaging = true;
        StartCoroutine(EngageCombat());
    } 

    IEnumerator EngageCombat()
    {
        while (engaging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {                
                if (hit.transform.tag == "EnemyAvatar" && Input.GetMouseButton(0))//ray hit enemy and mouse clicked for 1second at max
                {
                    if (Vector3.Distance(this.transform.position, hit.transform.position) <= distanceToEngage)//enemy at range
                    {
                        combats.enemyAgent = hit.transform.GetComponent<EnemyAvatar>().agent;
                        combats.myAgent = avatar.agent;
                        panelCombats.SetActive(true);
                        engaging = false;

                    }
                    Debug.Log("Not in range");//testing, delete in the future
                }
            }
            yield return waitForSeconds;
        }
        
    }






















}
