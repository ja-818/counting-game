using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Counter counterScript;
    private GameObject idea;
    private Vector3 spawnRange;
    private AudioSource backgroundMusic;

    private bool isGameActive;
    
    private int gameDuration = 45;
    private float spawnDelay;
    private int randomIdeaIndex;
    private int numberOfIdeas;
    private Collider boxCollider;

    public bool level1;
    public bool level2;
    public bool level3;
    public bool level4;

    public string maxCountText;

    [SerializeField] List<GameObject> ideasPrefabsArray;
    [SerializeField] List<Material> colorsArray;
    [SerializeField] TextMeshProUGUI timerText;
    [Space]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelCompleatedScreen;
    [SerializeField] GameObject gameCompleatedScreen;
    // Start is called before the first frame update
    void Start()
    {
        counterScript = GameObject.Find("Box").GetComponent<Counter>();
        boxCollider = GameObject.Find("Box").GetComponent<Collider>();
        backgroundMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counterScript.count == numberOfIdeas && isGameActive)
        {
            if (!level4)
            {
                boxCollider.enabled = false;
                isGameActive = false;
                StopAllCoroutines();
                levelCompleatedScreen.SetActive(true);
                timerText.text = "45";
            }
            else if (level4)
            {
                boxCollider.enabled = false;
                isGameActive = false;
                gameCompleatedScreen.SetActive(true);
                StopAllCoroutines();
                timerText.text = "45";
                backgroundMusic.Stop();
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if(gameDuration == 0 && isGameActive)
        {
            boxCollider.enabled = false;
            isGameActive = false;
            gameOverScreen.SetActive(true);
            StopAllCoroutines();
            timerText.text = "45";
        }
    }

    //Sets the specifications for the difficulty of each level
    void SetLevelParameters()
    {
        if (level1 == true)
        {
            spawnDelay = 0.4f;
            numberOfIdeas = 3;
            maxCountText = " || 3";
             
        }
        if (level2 == true)
        {
            spawnDelay = 0.3f;
            numberOfIdeas = 4;
            maxCountText = " || 4";
        }

        if (level3 == true)
        {
            spawnDelay = 0.2f;
            numberOfIdeas = 5;
            maxCountText = " || 5";
        }

        if (level4 == true)
        {
            spawnDelay = 0.1f;
            numberOfIdeas = 6;
            maxCountText = " || 6";
        }
    }

    //Coroutine to spawn ideas according to level specs
    IEnumerator SpawnManagerRoutine()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnDelay);
            spawnRange = new Vector3(Random.Range(-7, 7), 12, -1);
            randomIdeaIndex = Random.Range(0, numberOfIdeas);
            idea = Instantiate(ideasPrefabsArray[randomIdeaIndex], spawnRange, ideasPrefabsArray[randomIdeaIndex].gameObject.transform.rotation);
            idea.GetComponent<Renderer>().material = colorsArray[Random.Range(0, numberOfIdeas)];
        }
    }

    //Coroutine for reduce the time remaning each second
    IEnumerator TimerRoutine()
    {
        while(gameDuration > 0)
        {
            yield return new WaitForSeconds(1);
            gameDuration--;
            timerText.text = "" + gameDuration;
        }
    }

    //Starts the selected level
    public void StartLevel()
    {
        gameDuration = 45;
        counterScript.count = 0;
        SetLevelParameters();
        counterScript.counterText.text = counterScript.count + maxCountText;
        StartCoroutine(TimerRoutine());
        isGameActive = true;
        StartCoroutine(SpawnManagerRoutine());
        counterScript.RestartValues();
        boxCollider.enabled = true;
    }

    //Resets all the difficulty levels to false
    public void DifficultyToFalse()
    {
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
    }
}
