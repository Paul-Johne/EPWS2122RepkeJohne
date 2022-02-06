using UnityEngine;
using UnityEngine.UI;
using ZXing;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class QRScanning : MonoBehaviour {

    [SerializeField]
    private RawImage camImage;
    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;
    [SerializeField]
    private RectTransform scanArea;
    [SerializeField]
    private Text textDebug;
    [SerializeField]
    private GameObject buttonToAR;

    private bool _isCamAvailable;
    private WebCamTexture _camTexture;

    private AndroidJavaClass unityActivity;
    private AndroidJavaClass toastClass;
    private AndroidJavaObject toast;

    private void Start() {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);

        unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        toastClass = new AndroidJavaClass("android.widget.Toast");
#endif
    }

    private void Update() {
        UpdateCameraRender();
    }

    private void UpdateCameraRender() {
        if (!_isCamAvailable) {
            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
                SetCamera();
            return;
        }

        // set aspectRatio
        float ratio = (float)_camTexture.width / (float)_camTexture.height;
        aspectRatioFitter.aspectRatio = ratio;
        // rotation of raw image
        int orientation = -_camTexture.videoRotationAngle;
        // Z-Roll
        camImage.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    private void SetCamera() {
        // trying to access cameras
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            _isCamAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++) {
            if (!devices[i].isFrontFacing) {
                _camTexture = new WebCamTexture(devices[i].name, 
                                                (int)scanArea.rect.width, 
                                                (int)scanArea.rect.height);
                break;
            }
        }

        // starting camera on the back
        if (_camTexture != null) {
            _isCamAvailable = true;
            _camTexture.Play();
            camImage.texture = _camTexture;
            camImage.color = new Color(255, 255, 255, 255);
            textDebug.text = "Ready";
        }
    }

    public void OnClickScan() {
        Scan();
    }

    private void Scan() {
        try {
            IBarcodeReader qrReader = new BarcodeReader();
            Result res = qrReader.Decode(_camTexture.GetPixels32(), _camTexture.width, _camTexture.height);
            if (res != null) {
                textDebug.text = res.Text;
                buttonToAR.SetActive(true);
            } else {
                textDebug.text = "Camera didn't recognize QR Code";
            }
        } catch {
            textDebug.text = "Try Block failed";
        }
    }

    /* Turns on the Torch of the mobile device if available */
    public void OnClickTorch() {
#if PLATFORM_ANDROID
        object[] toastParams = new object[3];

        // Setup for Toast.makeText()
        toastParams[0] = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
        toastParams[1] = "Camera torch was activated";
        toastParams[2] = toastClass.GetStatic<int>("LENGTH_LONG"); // Toast.LENGTH_LONG

        toast = toastClass.CallStatic<AndroidJavaObject>("makeText", toastParams);
        toast.Call("show");

        // More logic..
#endif
    }
}