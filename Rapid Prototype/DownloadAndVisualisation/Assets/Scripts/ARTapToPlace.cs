using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour {

    public GameObject placementIndicator;
    public GameObject objectToPlace;

    [SerializeField]
    private ARSessionOrigin arSessionOrigin;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    [SerializeField]
    TrackableType trackableType = TrackableType.Planes; // default
    
    private Pose placementPose; // describes position and rotation in world space
    private bool placementPoseIsValid = false;

    void Update() {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            PlaceObject();
    }

    private void UpdatePlacementPose() {
        var screenCenter = arSessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, trackableType);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid) {
            placementPose = hits[0].pose;

            var cameraForward = arSessionOrigin.camera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

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

    void PlaceObject() {
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }
}