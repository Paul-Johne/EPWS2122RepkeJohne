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

    private AndroidCameraLIB camFunctions;

    private bool torchActive;

    private void Start() {
        /* Code for Android Version */
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);

        camFunctions = new AndroidCameraLIB();
#endif
    }

    private void OnDestroy() {
        camFunctions.deactivateTorch();
        torchActive = false;
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

        /* Updates video if flipped */
        // Set aspectRatio
        float ratio = (float)_camTexture.width / (float)_camTexture.height;
        aspectRatioFitter.aspectRatio = ratio;
        // Rotation of raw image
        int orientation = -_camTexture.videoRotationAngle;
        // Z-Roll
        camImage.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    private void SetCamera() {
        // Trying to access cameras
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

        // Starting back camera
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
            textDebug.text = "Scanning failed";
        }
    }

    /* Turns on the Torch of the mobile device if available */
    public void OnClickTorch() {
#if PLATFORM_ANDROID
        if (!torchActive) {
            camFunctions.activateTorch();
            torchActive = true;
        } else {
            camFunctions.deactivateTorch();
            torchActive = false;
        }
#endif
    }
}