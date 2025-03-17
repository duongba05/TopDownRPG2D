using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Thêm thư viện UI

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabs;
    public TextMeshProUGUI waveText; // Thêm biến Text UI
    private float spawnRange = 7f;
    private int enemyCount = 0;
    public int wave = 5;  // Giữ nguyên số quái đầu tiên là 5
    public int maxWave = 8;
    private int displayWave = 1; // Hiển thị wave bắt đầu từ 1

    void Start()
    {
        UpdateWaveText();
        SpawnEnemyWave(wave);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0 && displayWave < maxWave)
        {
            displayWave++; // Tăng wave hiển thị
            wave++; // Tăng số quái thực tế
            StartCoroutine(ShowWaveText()); // Hiển thị thông báo wave
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
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private IEnumerator ShowWaveText()
    {
        waveText.text = "Wave " + displayWave;
        waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // Hiển thị 2 giây
        waveText.gameObject.SetActive(false);
    }

    private void UpdateWaveText()
    {
        waveText.text = "Wave " + displayWave;
    }
}
