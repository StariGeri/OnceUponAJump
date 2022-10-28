using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float distance_to_spawn  = 100f;
    [SerializeField]private List<Transform> LevelPartList;
    [SerializeField]private Transform LevelPart0;
    [SerializeField]private GameObject player;
    private Vector3 lastEndingBlock;
    private Vector3 distance = new Vector3(5,3,0);
    private Transform lastLevelPartTransform;
    private void Awake()
    {
        lastEndingBlock = LevelPart0.Find("ending_block").position;
    }
    
 
    private void Update()
    {
        if(Vector3.Distance(player.transform.position,lastEndingBlock) < distance_to_spawn)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = LevelPartList[Random.Range(0,LevelPartList.Count)];
        lastLevelPartTransform= SpawnLevelPart(chosenLevelPart,lastEndingBlock - distance);
        lastEndingBlock = lastLevelPartTransform.Find("ending_block").position;
    }
    private Transform SpawnLevelPart(Transform LevelPart,Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart,spawnPosition,Quaternion.identity);
        return levelPartTransform;
    }
}
