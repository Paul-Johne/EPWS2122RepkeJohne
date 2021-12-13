using UnityEngine;
using UnityEngine.UI;
using Dummiesman;

public class ObjLoader : MonoBehaviour {
    public Button loadButton;
    public Canvas parent;

    // ugly but necessary
    public static string filePath;

    private GameObject loadedModel;

    private void OnEnable() {
        print("ObjLoader was startet..");
        placeButtonOnCanvas();
    }

    private void placeButtonOnCanvas() {
        Instantiate<Button>(loadButton, parent.transform);
    }

    public void OnButtonClicked() {
        print($"Data from {filePath} will be loaded");

        // Buttons is using prefab which doesn't know filePath etc.
        var parent = GameObject.Find("[ OBJ_DownloadAndLoad ]").GetComponent<ObjLoader>();

        if (loadedModel == null) {
            loadedModel = Instantiate<GameObject>(
                new OBJLoader().Load($"{filePath}TSF_3DM_vulcan000.obj"),
                parent.transform);

            loadedModel.transform.localScale *= 40;
        }
    }
}