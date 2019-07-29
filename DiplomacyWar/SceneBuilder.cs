using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    public Vector3[] spawnPositions;
    public Vector3[] spawnEnemyPositions;
    public GameObject agentPrefab;
    public GameObject enemyPrefab;
    public int numberOfEnemiesToSpawn;

    bool[] alreadyAssignedPosition;
    GenerateRandomAgent randomAgent;

    private void Start()
    {
        randomAgent = GetComponent<GenerateRandomAgent>();
        alreadyAssignedPosition = new bool[80];
        for(int i=0; i < alreadyAssignedPosition.Length; i++)
        {
            alreadyAssignedPosition[i] = false;
        }
        InitializeEnemyArrayPositions();
        Initialize();
    }

    public void Initialize()
    {
        int positionTracker=0;
        int[] positionsToAssign = new int[GameManager.gameManager.agentsToCombat.Count];
        int factorOfIncrement = 20 / GameManager.gameManager.agentsToCombat.Count;
        numberOfEnemiesToSpawn = GameManager.gameManager.agentsToCombat.Count + GameManager.gameManager.difficultyDiplo;//calculate number of enemies to spawn
                
        //Spawn my Agents
        for (int i=0; i< GameManager.gameManager.agentsToCombat.Count; i++)
        {
            positionsToAssign[i] = i * factorOfIncrement;
        }
        int y = 0;

        foreach (DiplomacyAgent a in GameManager.gameManager.agentsToCombat)
        {
            GameObject g = new GameObject();
            g = Instantiate(agentPrefab);
            g.transform.position = spawnPositions[positionsToAssign[y]];
            g.transform.gameObject.GetComponent<Avatar>().agent = a;
            y++;
        }

        y = 0;
        //Spawn enemies
        for(int i=0; i < numberOfEnemiesToSpawn; i++)
        {
            GameObject g = new GameObject();
            g = Instantiate(enemyPrefab);
            g.gameObject.GetComponent<EnemyAvatar>().agent = GetComponent<GenerateRandomAgent>().agentsPool[i];
            positionTracker = Random.Range(0, spawnEnemyPositions.Length);
            while (alreadyAssignedPosition[positionTracker])
            {
                positionTracker = Random.Range(0, spawnEnemyPositions.Length);
            }
            alreadyAssignedPosition[positionTracker] = true;
            g.transform.position = spawnEnemyPositions[Random.Range(0, spawnEnemyPositions.Length)];

        }
    }

    public void InitializeEnemyArrayPositions()
    {
        spawnEnemyPositions = new Vector3[80];
        int a = -95;
        int b = 95;
     
        for(int y=0; y<80; y++)
        {
            spawnEnemyPositions[y] = new Vector3(a,0,b);
            a += 10;
            if (a == 105)
            {
                a = -95;
                b -= 10;
            }
        }
            


    }

}
