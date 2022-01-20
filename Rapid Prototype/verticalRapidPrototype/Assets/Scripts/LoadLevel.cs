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

        /* Callback wenn Szene geladen ist */
        asyncLoadScene.completed += (AsyncOperation it) => {
            Debug.Log("Fertig");
            transition.SetTrigger("sceneLoaded");
        };

        asyncLoadScene.allowSceneActivation = false;

        /* hier warten auf Animation fertig geladen */
        while (!(transition.GetCurrentAnimatorStateInfo(0).IsName("WipeFade_Start") && transition.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 - 1e-6)) {
            yield return null;
        }

        asyncLoadScene.allowSceneActivation = true;

        while (!(transition.GetCurrentAnimatorStateInfo(0).IsName("WipeFade_End") && transition.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 - 1e-6)) {
            yield return null;
        }

        Destroy(gameObject);
    }
}