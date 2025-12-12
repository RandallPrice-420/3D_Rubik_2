using UnityEngine;
 

public class InitCameraControl : MonoBehaviour
{
    public GameObject CameraControl;



    private const string CameraControlName = "MainCameraControl";



    private void Start()
    {
        GameObject mainCamera = GameObject.Find(CameraControlName);

        if (mainCamera == null)
        {
            GameObject gameObject = Instantiate(CameraControl);
            gameObject.name       = CameraControlName;
        }

    }   // Start()


}   // InitCameraControl
