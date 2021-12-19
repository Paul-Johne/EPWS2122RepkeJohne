using UnityEngine;
using UnityEngine.UI;
using ZXing;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class QRScanning : MonoBehaviour {

    [SerializeField]
    private RawImage _camImage;
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;
    [SerializeField]
    private RectTransform _scanArea;
    [SerializeField]
    private Text _output;
    [SerializeField]
    private GameObject toAR;

    private bool _isCamAvailable;
    private WebCamTexture _camTexture;

    private void Start() {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);
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
        _aspectRatioFitter.aspectRatio = ratio;
        // rotation of raw image
        int orientation = -_camTexture.videoRotationAngle;
        // Z-Roll
        _camImage.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
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
                                                (int)_scanArea.rect.width, 
                                                (int)_scanArea.rect.height);
                break;
            }
        }
        // starting camera on the back
        if (_camTexture != null) {
            _isCamAvailable = true;
            _camTexture.Play();
            _camImage.texture = _camTexture;
            _camImage.color = new Color(255, 255, 255, 255);
            _output.text = "Ready";
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
                _output.text = res.Text;
                toAR.SetActive(true);
            } else {
                _output.text = "Camera didn't recognize QR Code";
            }
        } catch {
            _output.text = "Try Block failed";
        }
    }
}