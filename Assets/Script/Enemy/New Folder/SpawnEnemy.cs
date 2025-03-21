using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabs;
    private float spawnRange = 7f;
    private int enemyCount = 0;
    public int maxWave = 5;
    public int wave = 5;  
    public TextMeshProUGUI waveText; 
    private int displayWave = 1; 

    void Awake()
    {
        StartCoroutine(ShowWaveText());
        UpdateWaveText();
        SpawnEnemyWave(wave);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None).Length;
        Debug.Log($"EnemyCount:{enemyCount}");
        if (enemyCount == 0 && displayWave < maxWave)
        {
            displayWave++; 
            wave++; 
            StartCoroutine(ShowWaveText()); 
            SpawnEnemyWave(wave);
        }
    }

    private void SpawnEnemyWave(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(prefabs, EnemyPosSpawn(), prefabs.transform.rotation);
        }
    }

    private Vector3 EnemyPosSpawn()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator ShowWaveText()
    {
        waveText.text = "Stage " + displayWave;
        waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        waveText.gameObject.SetActive(false);
    }

    private void UpdateWaveText()
    {
        waveText.text = "Stage " + displayWave;
    }
}
