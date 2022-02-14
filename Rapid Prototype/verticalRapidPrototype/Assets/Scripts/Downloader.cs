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

        if (!Directory.Exists(storagePath)) {
            Directory.CreateDirectory(storagePath);
            textDebug.text = "Directory for fireworks was created";
        }
    }

    public async void OnClickDownload() {
        string scannedID = textDebug.text;

        if (!File.Exists(Path.Combine(storagePath, scannedID) + ".unity3d")) {
            buttonStartDownload.SetActive(false);
            await DownloadAssetBundle(scannedID);
        } else {
            textDebug.text = "The scanned Firework already exists on your device";
        }

        buttonToAR.SetActive(true);
    }

    private async Task DownloadAssetBundle(string currentID) {
        var downloadLink = $"{rawDownloadLink}{currentID}";
        var taskInspector = new Task<UnityWebRequest>[1];

        UnityWebRequest request = UnityWebRequest.Get(downloadLink);

        taskInspector[0] = StartDownload(request, currentID);
        await Task.WhenAll(taskInspector);

        if (taskInspector[0].Result.result != UnityWebRequest.Result.Success)
            textDebug.text = $"Download failed: {request.error}";
        else
            textDebug.text = "Finished download";
    }

    private async Task<UnityWebRequest> StartDownload(UnityWebRequest request, string fileName) {
        var filePath = Path.Combine(storagePath, fileName) + ".unity3d";
        request.downloadHandler = new DownloadHandlerBuffer();
        
        var operation = request.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        if (request.result == UnityWebRequest.Result.Success) {
            File.WriteAllBytes(filePath, request.downloadHandler.data);
        }
        return request;
    }
}