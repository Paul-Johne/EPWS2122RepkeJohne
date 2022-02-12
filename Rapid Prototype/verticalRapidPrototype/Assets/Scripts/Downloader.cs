using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Downloads the AssetBundle after acquiring the GoogleDrive-id from an QR code.
/// </summary>
public class Downloader : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonStartDownload;
    [SerializeField]
    private Text textDebug;

    private string GD_DownloadLink = "https://drive.google.com/uc?export=download&id=";

    private string assetBundleGD_ID;

    private IEnumerator GetAssetBundle(string link)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(link);
        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Network Error!");
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if(bundle != null)
            {
                string rootAssetBundlePath = bundle.GetAllAssetNames()[0];
                Debug.Log(rootAssetBundlePath);
                Debug.Log("Download completed!");
            }
            else
            {
                Debug.Log("Not a valid AssetBundle");
            }
        }
    }

    private void DownloadAssetBundle()
    {
        assetBundleGD_ID = textDebug.text;
        Debug.Log(assetBundleGD_ID);
        string assetBundleLink = GD_DownloadLink + assetBundleGD_ID;
        Debug.Log(assetBundleLink);
        StartCoroutine(GetAssetBundle(assetBundleLink));
    }

    public void OnClickDownload()
    {
        DownloadAssetBundle();

        buttonStartDownload.SetActive(false);
    }
}
