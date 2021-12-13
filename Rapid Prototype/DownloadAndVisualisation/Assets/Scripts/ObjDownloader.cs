using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Threading.Tasks;

struct QR_Data {
    public string name;
    public string objID;
    public string mtlID;
}

/// <summary>
/// Chains ObjLoader.cs after attempting to download the file.
/// </summary>
public class ObjDownloader : MonoBehaviour {
    /* public properties are seen in the inspector */
    public Text debug;
    public string insertObjectName;

    public readonly string rawDriveURL = "https://drive.google.com/uc?export=download&id=";
    private string filePath;

    private QR_Data vulcan_000;
    private ObjLoader objLoaderScript;

    async void Start() {
        filePath = $"{Application.persistentDataPath}/3DModels/";
        print(filePath);
        SetQR_Data(ref vulcan_000, insertObjectName, "19dsvFQ-aR3OPttZDdPtKKz4C09OGUIL-", "10VLomNAhdQasyOavIcTH6nQEEyCCDm9X");

        if (System.IO.File.Exists($"{Application.persistentDataPath}/3DModels/{insertObjectName}")) {
            print("Download to: " + filePath);
            await DownloadData(vulcan_000);
        } else {
            debug.text = "The file was found on your device.";
        }
        // starts ObjLoader Start()
        objLoaderScript = GetComponent<ObjLoader>();
        ObjLoader.filePath = filePath;
        objLoaderScript.enabled = true;
    }

    void SetQR_Data(ref QR_Data data, string name, string objID, string mtlID) {
        data.name = name;
        data.objID = objID;
        data.mtlID = mtlID;
    }

    private async Task<UnityWebRequest> StartCommunicationFor(UnityWebRequest request) {
        var operation = request.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();
        return request;
    }

    private async Task DownloadData(QR_Data data) {
        debug.text = "Downloading 3D-Model..";

        // creating HTTP GET requests
        UnityWebRequest requestOBJ = UnityWebRequest.Get($"{rawDriveURL}{data.objID}");
        requestOBJ.downloadHandler = new DownloadHandlerFile($"{filePath}{data.name}.obj");
        UnityWebRequest requestMTL = UnityWebRequest.Get($"{rawDriveURL}{data.mtlID}");
        requestMTL.downloadHandler = new DownloadHandlerFile($"{filePath}{data.name}.mtl");

        var tasks = new Task<UnityWebRequest>[2];

        // receiving data..
        tasks[0] = StartCommunicationFor(requestOBJ);
        tasks[1] = StartCommunicationFor(requestMTL);

        // waiting for both webrequests to finish
        await Task.WhenAll(tasks);
        print("Passed [ Task.WhenAll(tasks) ]");

        if (tasks[0].Result.result == UnityWebRequest.Result.ConnectionError | 
            tasks[1].Result.result == UnityWebRequest.Result.ConnectionError) {
            debug.text = "Download failed";
            print(requestOBJ.error + requestMTL.error);
        } else {
            debug.text = "Download successful";
            print($"OBJ: {requestOBJ.result} | MTL: {requestMTL.result}");
        }
    }
}