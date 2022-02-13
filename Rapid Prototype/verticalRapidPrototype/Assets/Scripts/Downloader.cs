using System.Collections;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Downloads the AssetBundle after acquiring the GoogleDrive ID from a QR code.
/// </summary>
public class Downloader : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonStartDownload;
    [SerializeField]
    private GameObject buttonToAR;
    [SerializeField]
    private Text textDebug;

    private string rawDownloadLink = "https://drive.google.com/uc?export=download&id=";
    private string storagePath;

    private void Start() {
        storagePath = Path.Combine(Application.persistentDataPath, "3DModels");
    }

    public async void OnClickDownload() {
        if (!File.Exists(Path.Combine(storagePath, textDebug.text))) {
            await DownloadAssetBundle(textDebug.text);
        } else {
            textDebug.text = "The scanned Firework already exists on your device";
        }

        buttonStartDownload.SetActive(false);
        buttonToAR.SetActive(true);
    }

    private async Task DownloadAssetBundle(string currentID) {
        var downloadLink = $"{rawDownloadLink}{currentID}";
        var taskInspector = new Task<UnityWebRequest>[1];

        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(downloadLink);
        
        taskInspector[0] = StartDownload(request);
        await Task.WhenAll(taskInspector);

        if (taskInspector[0].Result.result == UnityWebRequest.Result.ConnectionError)
            textDebug.text = $"Download failed: {request.error}";
        else
            textDebug.text = "Finished download";
    }

    private async Task<UnityWebRequest> StartDownload(UnityWebRequest request) {
        var operation = request.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.ConnectionError) {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (bundle != null) {
                // TODO(reason: Save on persistentDataPath)
            }
        }
        return request;
    }
}