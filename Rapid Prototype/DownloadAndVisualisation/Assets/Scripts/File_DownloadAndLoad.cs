using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public struct QR_Data {
    public string objID;
    public string mtlID;
}

public class File_DownloadAndLoad : MonoBehaviour {
    public Text debug;
    public GameObject model;

    [SerializeField] private string rawDriveURL = "https://drive.google.com/uc?export=download&id=";
    private QR_Data vulcan_000;

    void Start() {
        setQR_Data(vulcan_000, "19dsvFQ-aR3OPttZDdPtKKz4C09OGUIL-", "10VLomNAhdQasyOavIcTH6nQEEyCCDm9X");

        StartCoroutine(downloadData(vulcan_000));
    }

    void setQR_Data(QR_Data data, string objID, string mtlID) {
        data.objID = objID;
        data.mtlID = mtlID;
    }

    IEnumerator downloadData(QR_Data data) {
        debug.text = "Downloading 3D-Model..";

        UnityWebRequest requestOBJ = UnityWebRequest.Get(rawDriveURL + data.objID);
        UnityWebRequest requestMTL = UnityWebRequest.Get(rawDriveURL + data.mtlID);

        // receiving data..
        yield return requestOBJ.Send();
        yield return requestMTL.Send();

        if (requestOBJ.isNetworkError | requestMTL.isNetworkError) {
            debug.text = "Download failed..";
        } else {
            debug.text = "Eh..download successful..?";
        }
    }
}