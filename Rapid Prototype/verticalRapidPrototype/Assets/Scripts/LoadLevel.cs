using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    [SerializeField] 
    private Animator transition;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void OnStartCam() {
        LoadNewScene("qrReading");
    }

    public void OnBackButton() {
        LoadNewScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnToAR() {
        LoadNewScene("arZone");
    }

    private void LoadNewScene(string nextScene) {
        StartCoroutine(LoadingScene(nextScene));
    }

    private void LoadNewScene(int nextSceneIndex) {
        StartCoroutine(LoadingScene(nextSceneIndex));
    }

    IEnumerator LoadingScene<T>(T scene) {
        AsyncOperation asyncLoadScene;

        transition.SetTrigger("sceneLoading");

        if (scene is string)
            asyncLoadScene = SceneManager.LoadSceneAsync(scene as string);
        else if (scene is int) {
            int index = (int)(object)scene;
            asyncLoadScene = SceneManager.LoadSceneAsync(Convert.ToInt32(scene));
        } else {
            throw new Exception("LoadingScene<T>() only accepts string or int");
        }

        asyncLoadScene.allowSceneActivation = false;

        yield return new WaitForSecondsRealtime(2f); // temporary solution
        asyncLoadScene.allowSceneActivation = true;

        while (!asyncLoadScene.isDone) {
            yield return null;
        }

        transition.SetTrigger("sceneLoaded");

        yield return new WaitForSecondsRealtime(2f); // temporary solution
        Destroy(gameObject);
    }
}