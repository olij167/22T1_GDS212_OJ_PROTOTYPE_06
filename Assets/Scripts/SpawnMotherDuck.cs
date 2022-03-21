using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMotherDuck : MonoBehaviour
{
    public GameObject motherDuckPrefab, lostDuckling;
    [HideInInspector] public GameObject motherDuck;

    public List<Transform> motherDuckSpawnPointList;
    void Start()
    {
        motherDuck = Instantiate(motherDuckPrefab, motherDuckSpawnPointList[Random.Range(0, motherDuckSpawnPointList.Count)]);
        motherDuck.transform.parent = null;
        lostDuckling.SetActive(true);
    }
}
