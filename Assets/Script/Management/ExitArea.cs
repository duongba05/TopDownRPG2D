using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // ten scene tiep theo 
    [SerializeField] private string sceneTransitionName; // ten hieu ung chuyen canh 
    private float waitToLoadTime = 1f;
    private SpawnEnemy spawnEnemy;

    private void Start()
    {
        spawnEnemy = GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.GetComponent<PlayerController>() && spawnEnemy.wave == spawnEnemy.maxWave )
        if (other.gameObject.GetComponent<PlayerController>())
        {
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
