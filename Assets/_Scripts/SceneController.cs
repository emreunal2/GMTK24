using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set;}
    [SerializeField] Animator transitionAnim;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += SceneManager_SceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_SceneLoaded;
    }

    void SceneManager_SceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        TimeManager.instance.SetTimeScale(TimeManager.TimeScale.Normal);
        GravityManager.instance.SetGravityScale(GravityManager.GravityScale.Normal);

        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            Player.Instance.transform.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else
        {
            Debug.LogWarning("SpawnPoint does not exist");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel()
    {
        StartCoroutine(LoadNextScene());
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadNextScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        transitionAnim.SetTrigger("Start");
    }
}
