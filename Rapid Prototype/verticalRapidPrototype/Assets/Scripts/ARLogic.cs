using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARLogic : MonoBehaviour {

    /* Debugging Textview */
    [SerializeField]
    private Text textdebug;

    /* Button References to enable/disable them */
    [SerializeField]
    private GameObject buttonPlaceFirework;
    [SerializeField]
    private GameObject buttonIgniteFirework;

    /* TrackedImage Variables */
    [SerializeField]
    private ARSessionOrigin sessionOrigin;
    [SerializeField]
    private XRReferenceImageLibrary xrRefImgLib;
    public GameObject trackedImagePrefab;
    private ARTrackedImageManager trackedImageManager;

    private string currentFilePath;
    private GameObject currentFirework;

    private void Start() {
        currentFilePath = Downloader.filePath;
        textdebug.text = $"current filepath: {currentFilePath}";
    }

    public void OnPlaceObject() {
        /*
        buttonPlaceFirework.SetActive(false);
        AssetBundle bundle = AssetBundle.LoadFromFile(currentFilePath);

        if (bundle == null) {
            textdebug.text = "LoadFromFile didn't work";
            return;
        } else {
            textdebug.text = "Started LoadFromFile..";
            currentFirework = bundle.LoadAllAssets<GameObject>().GetValue(0) as GameObject;
            arTrackedImageManager.trackedImagePrefab = currentFirework;
        }

        bundle.Unload(false);
        buttonIgniteFirework.SetActive(true);
        */
        trackedImageManager = sessionOrigin.gameObject.AddComponent<ARTrackedImageManager>();
        trackedImageManager.referenceLibrary = trackedImageManager.CreateRuntimeLibrary(xrRefImgLib);
        trackedImageManager.requestedMaxNumberOfMovingImages = 1;
        trackedImageManager.trackedImagePrefab = trackedImagePrefab;

        trackedImageManager.enabled = true;

        buttonPlaceFirework.SetActive(false);
        buttonIgniteFirework.SetActive(true);
    }

    private void LoadPrefabFromAsset() {

    }

    public void OnIgniteObject() {
        foreach (var i in trackedImageManager.trackables) {
            i.gameObject.transform.parent.localScale = Vector3.one * 0.05f; // might be buggy
            i.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        }
        textdebug.text = "BOOM!";
    }
}

/* useless code */
/*

[SerializeField]
    private ARSessionOrigin arSessionOrigin;
[SerializeField]
    private ARRaycastManager arRaycastManager;
[SerializeField]
    TrackableType trackableType = TrackableType.Planes;

private Pose placementPose;
private bool placementPoseIsValid = false;
public GameObject placementIndicator;

private void UpdatePlacementPose() {
        var screenCenter = arSessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, trackableType);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid) {
            placementPose = hits[0].pose;

            var cameraForward = arSessionOrigin.camera.transform.forward; // already normalized
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z); //.normalized

            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator() {
        if (placementPoseIsValid) {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else {
            placementIndicator.SetActive(true);
        }
    }

 */