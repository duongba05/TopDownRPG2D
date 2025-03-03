using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string SceneTransitionName;

    private float waitToLoadTime = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            SceneManagement.Instance.SetTransitionName(SceneTransitionName);
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }
    private IEnumerator LoadSceneRoutine()
    {
        while(waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
