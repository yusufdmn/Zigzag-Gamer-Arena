using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    enum WayType{
        horizontal, 
        vertical
    };


    [System.Serializable]
    public class Pool{
         public int tag;
         public GameObject prefab;
         public int size;
    }
    
#region  Variables

    [SerializeField] GameObject[] horizontal_horizontal_ways;
    [SerializeField] GameObject[] horizontal_vertical_ways;
    [SerializeField] GameObject[] vertical_horizontal_ways;
    [SerializeField] GameObject[] vertical_vertical_ways;
    [SerializeField] Transform previousWay; 

    private GameObject nextWay;
    private Vector3 generatePoint;
    private WayType nextWayType;
    private WayType previousWayType;
    private WayType currentWayType;
    
    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> poolDictionary;

#endregion


    void Start(){     
        currentWayType = WayType.vertical;  
        previousWayType = WayType.vertical;

        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach(Pool pool in pools){
            Queue<GameObject> wayPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++){
                GameObject way = Instantiate(pool.prefab);
                way.SetActive(false);
                wayPool.Enqueue(way);
            }

            poolDictionary.Add(pool.tag, wayPool);
        }

        for (int i = 0; i < 40; i++)
        {
            GenerateWay();
        }

    }


#region  Functions

    public void GenerateWay(){
        int wayTypeSelection;

        if(currentWayType == WayType.horizontal){
            wayTypeSelection = Random.Range(0,2);
        }
        else{
            wayTypeSelection = Random.Range(2,4);
        }
        
        DecideWayType(wayTypeSelection);
        generatePoint = CalculatePosition();

        nextWay.transform.position = generatePoint;
        nextWay.transform.rotation = Quaternion.identity;

        previousWay = nextWay.transform;
        previousWayType = currentWayType;
        currentWayType = nextWayType;
    }

    GameObject SpawnFromPool(int tag){
        GameObject newSpawn = poolDictionary[tag].Dequeue();
        newSpawn.SetActive(false);
        newSpawn.SetActive(true);
        poolDictionary[tag].Enqueue(newSpawn);
        return newSpawn;
    }


    private void DecideWayType(int index){  // Put the next way prefab inside "nextWay"

        // NEW BLOCK TYPE TO GENERATE
        switch(index){  // H - H
            case 0:
                nextWay = SpawnFromPool(0);
                currentWayType = WayType.horizontal;
                nextWayType = WayType.horizontal;  
                break;
            case 1:  // H - V
                nextWay = SpawnFromPool(1);
                currentWayType = WayType.horizontal;
                nextWayType = WayType.vertical;  
                break;
            case 2:  // V - H
                nextWay = SpawnFromPool(2);
                currentWayType = WayType.vertical;
                nextWayType = WayType.horizontal;  
                break;
            default:  // V - V
                nextWay = SpawnFromPool(3);
                currentWayType = WayType.vertical;
                nextWayType = WayType.vertical;  
                break;
        }
    }



    private Vector2 CalculatePosition(){
        Vector2 wayPosition;

        if(previousWayType == WayType.horizontal){
            if(currentWayType == WayType.horizontal){
                wayPosition = PositionCalculator.Calculate_Horizontal_Horizontal_Pos(nextWay, previousWay);
            }
            else{
                wayPosition = PositionCalculator.Calculate_Horizontal_Vertical_Pos(nextWay, previousWay);
            }
        }
        else{
            if(currentWayType == WayType.horizontal){
                wayPosition = PositionCalculator.Calculate_Vertical_Horizontal_Pos(nextWay, previousWay);
            }
            else{
                wayPosition = PositionCalculator.Calculate_Vertical_Vertical_Pos(nextWay, previousWay);
            }
        }
        return wayPosition;
    }

#endregion

}