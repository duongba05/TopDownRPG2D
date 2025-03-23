using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabs;
    public GameObject bossPrefab;
    private float spawnRange = 7f;
    private int enemyCount = 0;
    public int maxWave = 5;
    public int wave = 5;
    public TextMeshProUGUI waveText;
    private int displayWave = 1;
    private bool bossSpawned = false;

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

        if (enemyCount == 0)
        {
            if (displayWave < maxWave)
            {
                displayWave++;
                wave++;
                StartCoroutine(ShowWaveText());
                SpawnEnemyWave(wave);
            }
            else if (!bossSpawned)
            {
                bossSpawned = true;
                StartCoroutine(ShowBossText());
                SpawnBoss();
            }
        }
    }

    private void SpawnEnemyWave(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(prefabs, EnemyPosSpawn(), prefabs.transform.rotation);
        }
    }

    private void SpawnBoss()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bossPrefab, EnemyPosSpawn(), prefabs.transform.rotation);
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

    private IEnumerator ShowBossText()
    {
        waveText.text = "BOSS STAGE!";
        waveText.color = Color.red;
        waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        waveText.gameObject.SetActive(false);
        waveText.color = Color.white;
    }

    private void UpdateWaveText()
    {
        waveText.text = "Stage " + displayWave;
    }
}
