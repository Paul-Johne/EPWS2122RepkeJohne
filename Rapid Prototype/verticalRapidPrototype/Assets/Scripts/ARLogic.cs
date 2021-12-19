using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARLogic : MonoBehaviour {

    public GameObject placementIndicator;
    public GameObject objectToPlace;

    [SerializeField]
    private ARSessionOrigin arSessionOrigin;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    [SerializeField]
    TrackableType trackableType = TrackableType.Planes; // default
    [SerializeField]
    private GameObject buttonIgniteFirework;
    
    private Pose placementPose; // describes position and rotation in world space
    private bool placementPoseIsValid = false;

    private GameObject loadedFirework;

    private void Update() {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementPose() {
        var screenCenter = arSessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, trackableType);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid) {
            placementPose = hits[0].pose;

            var cameraForward = arSessionOrigin.camera.transform.forward; // already normalized
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z); //.normalized;

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
        if (placementPoseIsValid && Input.GetTouch(0).phase == TouchPhase.Ended) {
            Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
            gameObject.SetActive(false);
            buttonIgniteFirework.SetActive(true);
        }*/
        loadedFirework = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        buttonIgniteFirework.SetActive(true);
    }

    public void OnIgniteObject() {
        loadedFirework.transform.GetChild(1).gameObject.SetActive(true);
    }
}