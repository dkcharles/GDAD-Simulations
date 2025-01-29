using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class LifeGameManager : MonoBehaviour
{
    // Singleton instance
    public static LifeGameManager Instance { get; private set; }

    public GameObject foxPrefab;
    public GameObject rabbitPrefab;
    public GameObject foodPrefab;

    public Transform groundPlane;

    public int initialFoxCount = 5;
    public int initialRabbitCount = 10;
    public int initialFoodCount = 20;
    public int foodSpawnCount = 5;
    public float minFoodSpawnInterval = 5f;
    public float maxFoodSpawnInterval = 15f;
    public float foxSpawnInterval = 60f;
    public int maxFoxes = 10;
    public float rabbitSpawnInterval = 30f;
    public int maxRabbits = 20;
    public string csvFilename = "simulation_data.csv"; // Name of the CSV file

    private bool fileWritten = false;

    private int foxCount = 0;
    private int rabbitCount = 0;
    private List<DataRecord> dataRecords = new List<DataRecord>(); // Store data records
    private float dataRecordInterval = 1f; // Time between recording data
    private float timer = 0f;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnInitialPopulation();
        StartCoroutine(ManageFoodSpawns());
        StartCoroutine(ManageFoxSpawns());
        StartCoroutine(ManageRabbitSpawns());
    }

    void Update()
    {
        // Record data periodically
        timer += Time.deltaTime;
        if (timer >= dataRecordInterval)
        {
            RecordData();
            timer = 0f;
        }

        // Check if all foxes or all rabbits have died
        if ( (foxCount == 0 || rabbitCount == 0) && !fileWritten)
        {
            SaveDataToCSV();
            // Optionally stop the simulation or reset the game here
            Debug.Log("Simulation data saved to CSV. All foxes or rabbits have died.");
            fileWritten = true;
            // You might want to add code here to stop the simulation, 
            // reset the game, or load a new scene, etc.
            // For example, to stop the simulation:
            // Time.timeScale = 0; // This will pause the game
            // Or to reload the scene (make sure the scene is in your build settings):
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SpawnInitialPopulation()
    {
        SpawnObjects(foxPrefab, initialFoxCount);
        SpawnObjects(rabbitPrefab, initialRabbitCount);
        SpawnObjects(foodPrefab, initialFoodCount);
    }

    void SpawnObjects(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bounds groundBounds = groundPlane.GetComponent<Renderer>().bounds;

            float randomX = Random.Range(groundBounds.min.x, groundBounds.max.x);
            float randomZ = Random.Range(groundBounds.min.z, groundBounds.max.z);

            Vector3 spawnPosition = new Vector3(randomX, groundBounds.max.y + prefab.transform.localScale.y / 2, randomZ);

            GameObject newObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

            if (prefab == foxPrefab)
            {
                foxCount++;
            }
            else if (prefab == rabbitPrefab)
            {
                rabbitCount++;
            }
        }
    }

    IEnumerator ManageFoodSpawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFoodSpawnInterval, maxFoodSpawnInterval));
            SpawnObjects(foodPrefab, foodSpawnCount);
        }
    }

    IEnumerator ManageFoxSpawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(foxSpawnInterval);

            if (foxCount < maxFoxes)
            {
                SpawnFox();
            }
        }
    }

    IEnumerator ManageRabbitSpawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(rabbitSpawnInterval);

            if (rabbitCount < maxRabbits)
            {
                SpawnRabbit();
            }
        }
    }

    void SpawnFox()
    {
        Bounds groundBounds = groundPlane.GetComponent<Renderer>().bounds;
        float randomX = Random.Range(groundBounds.min.x, groundBounds.max.x);
        float randomZ = Random.Range(groundBounds.min.z, groundBounds.max.z);
        Vector3 spawnPosition = new Vector3(randomX, groundBounds.max.y + foxPrefab.transform.localScale.y / 2, randomZ);

        Instantiate(foxPrefab, spawnPosition, Quaternion.identity);
        foxCount++;
        Debug.Log("New fox born! Total foxes: " + foxCount);
    }

    void SpawnRabbit()
    {
        Bounds groundBounds = groundPlane.GetComponent<Renderer>().bounds;
        float randomX = Random.Range(groundBounds.min.x, groundBounds.max.x);
        float randomZ = Random.Range(groundBounds.min.z, groundBounds.max.z);
        Vector3 spawnPosition = new Vector3(randomX, groundBounds.max.y + rabbitPrefab.transform.localScale.y / 2, randomZ);

        Instantiate(rabbitPrefab, spawnPosition, Quaternion.identity);
        rabbitCount++;
        Debug.Log("New rabbit born! Total rabbits: " + rabbitCount);
    }

    public void DecrementFoxCount()
    {
        foxCount--;
        Debug.Log("Fox died! Total foxes: " + foxCount);
    }

    public void DecrementRabbitCount()
    {
        rabbitCount--;
        Debug.Log("Rabbit died! Total rabbits: " + rabbitCount);
    }

    void RecordData()
    {
        int foodCount = GameObject.FindGameObjectsWithTag("Food").Length;
        dataRecords.Add(new DataRecord(Time.time, foodCount, foxCount, rabbitCount));
    }

        public string csvFolderName = "SimulationData"; // Name of the folder to store CSV files

    void SaveDataToCSV()
    {
        // Create a StringBuilder to store the CSV content
        StringBuilder csvContent = new StringBuilder();

        // Add header row
        csvContent.AppendLine("Time,Food Count,Fox Count,Rabbit Count");

        // Add data rows
        foreach (DataRecord record in dataRecords)
        {
            csvContent.AppendLine(record.ToString());
        }

        // Get the path to the project's parent directory (one level above Assets)
        string projectParentDirectory = Directory.GetParent(Application.dataPath).FullName;

        // Create the folder if it doesn't exist
        string folderPath = Path.Combine(projectParentDirectory, csvFolderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Generate a unique filename with a timestamp
        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string uniqueFilename = $"{Path.GetFileNameWithoutExtension(csvFilename)}_{timestamp}{Path.GetExtension(csvFilename)}";

        // Combine the folder path and the unique filename
        string filePath = Path.Combine(folderPath, uniqueFilename);

        // Write the content to a CSV file
        File.WriteAllText(filePath, csvContent.ToString());

        Debug.Log("Data saved to: " + filePath);

        // Clear the data records
        dataRecords.Clear();
    }
}

// Data structure to hold the recorded data
public struct DataRecord
{
    public float time;
    public int foodCount;
    public int foxCount;
    public int rabbitCount;

    public DataRecord(float time, int foodCount, int foxCount, int rabbitCount)
    {
        this.time = time;
        this.foodCount = foodCount;
        this.foxCount = foxCount;
        this.rabbitCount = rabbitCount;
    }

    // Convert the record to a CSV format string
    public override string ToString()
    {
        return $"{time},{foodCount},{foxCount},{rabbitCount}";
    }
}