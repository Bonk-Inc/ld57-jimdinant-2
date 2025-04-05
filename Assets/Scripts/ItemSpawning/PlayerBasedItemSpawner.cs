using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bonk.StandardLibrary.Numerics;
using UnityEngine;

public class PlayerBasedItemSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float spawnOffset;

    [SerializeField]
    private List<SpawnItem> items;

    [SerializeField]
    private float minDelay, maxDelay;

    [SerializeField]
    private float spawnAngle = 180, angleOffset = 90;

    private OrthographicCameraSizeCalculatorHelper cameraSizeCalculator;

    private float Depth => player.transform.position.y;
    
    private void Awake(){
        cameraSizeCalculator = new OrthographicCameraSizeCalculatorHelper(Camera.main);
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine(){
        while(true) {
            SpawnItem();
            var nextSpawnDelay = Random.Range(minDelay, maxDelay);            
            yield return new WaitForSeconds(nextSpawnDelay);
        }
    }

    private void SpawnItem(){
        var itemToSpawn = GetRandomSpawnItem();
        var spawnPosition = GetSpawnLocation();
        var item = Instantiate(itemToSpawn);
        item.transform.position = spawnPosition;
    }

    private SpawnItem GetRandomSpawnItem() => items
        .Where(item => Depth >= item.MinDepth && Depth < item.MaxDepth )
        .ToList()
        .GetRandomWeighted(item => item.Weight);

    private Vector3 GetSpawnLocation() {
        var distance = GetSpawnDistance();
        var angle = Random.value * spawnAngle + angleOffset;
        var forward = player.transform.up.ToVector2();
        var spawnDirection = forward.Rotate(angle);
        return spawnDirection.normalized.ToVector3(0) * distance;
    }

    private float GetSpawnDistance() => 
        cameraSizeCalculator.CalulateSizeToCameraCorner() + spawnOffset;
    
}
