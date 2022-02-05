using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Counter counterScript;
    private GameObject idea;
    private Vector3 spawnRange;

    private bool isGameActive = true;
    private bool completedLevel;
    private bool failedLevel;
    private bool level1;
    private bool level2;
    private bool level3;
    private bool level4 = true;
    private int gameDuration = 60;
    private float spawnDelay;
    private int randomIdeaIndex;
    private int numberOfIdeas;

    [SerializeField] List<GameObject> ideasPrefabsArray;
    [SerializeField] List<Material> colorsArray;
    // Start is called before the first frame update
    void Start()
    {
        SetLevelParameters();
        StartCoroutine(SpawnManagerRoutine());
        StartCoroutine(TimerRoutine());
        counterScript = GameObject.Find("Box").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counterScript.count == 5)
        {
            isGameActive = false;
            completedLevel = true;
        }
        else if(gameDuration == 0)
        {
            isGameActive = false;
            failedLevel = true;
        }
    }

    void SetLevelParameters()
    {
        if (level1 == true)
        {
            spawnDelay = 0.4f;
            numberOfIdeas = 3;
            
        }

        if (level2 == true)
        {
            spawnDelay = 0.3f;
            numberOfIdeas = 4;
        }

        if (level3 == true)
        {
            spawnDelay = 0.2f;
            numberOfIdeas = 5;
        }

        if (level4 == true)
        {
            spawnDelay = 0.1f;
            numberOfIdeas = 6;
        }
    }

    IEnumerator SpawnManagerRoutine()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnDelay);
            spawnRange = new Vector3(Random.Range(-10, 10), 12, -1);
            randomIdeaIndex = Random.Range(0, numberOfIdeas);
            idea = Instantiate(ideasPrefabsArray[randomIdeaIndex], spawnRange, Quaternion.identity);
            idea.GetComponent<Renderer>().material = colorsArray[Random.Range(0, numberOfIdeas)];
        }
    }

    IEnumerator TimerRoutine()
    {
        while(gameDuration != 0)
        {
            yield return new WaitForSeconds(1);
            gameDuration--;
        }
    }
}
