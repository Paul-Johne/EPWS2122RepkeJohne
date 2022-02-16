using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARLogic : MonoBehaviour {

    /* Debugging Textview */
    [SerializeField]
    private Text textdebug;

    /* References to Components of scene's AR Session Origin */
    [SerializeField]
    private ARSessionOrigin arSessionOrigin;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    [SerializeField]
    TrackableType trackableType = TrackableType.Planes;
    [SerializeField]
    private ARTrackedImageManager arTrackedImageManager;


    /* Button References to enable/disable them */
    [SerializeField]
    private GameObject buttonPlaceFirework;
    [SerializeField]
    private GameObject buttonIgniteFirework;

    /* DEPRECATED: Placing Gameobject inside of AR Scene */
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    public GameObject placementIndicator;

    private string currentFilePath;
    private GameObject currentFirework;

    private void Start() {
        currentFilePath = Downloader.filePath;
        textdebug.text = $"current filepath: {currentFilePath}";
    }

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

    public void OnPlaceObject() {
        /*
        buttonPlaceFirework.SetActive(false);
        AssetBundle bundle = AssetBundle.LoadFromFile(currentFilePath);

        if (bundle == null) {
            // passiert beim 2. Mal mit selben currentFilePath => LoadFromFile nur 1x pro Appstart?
            textdebug.text = "LoadFromFile didn't work";
            return;
        } else {
            textdebug.text = "Started LoadFromFile..";
            // TODO( KEVIN??? )
            currentFirework = bundle.LoadAllAssets<GameObject>().GetValue(0) as GameObject; //wenn das nicht klappt, mal mit Instantiate() versuchen
            arTrackedImageManager.trackedImagePrefab = currentFirework;
        }

        bundle.Unload(false);
        buttonIgniteFirework.SetActive(true);
        */
    }

    public void OnIgniteObject() {
        //currentFirework.transform.GetChild(1).gameObject.SetActive(true);
        //arTrackedImageManager.trackedImagePrefab.transform.GetChild(1).gameObject.SetActive(true);
        textdebug.text = "BOOM!";
    }
}