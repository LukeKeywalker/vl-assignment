using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform tpp;
    public Transform fpp;

    new public Transform camera;

    bool isFpp = true;

    void Start()
    {
        isFpp = true;
        UpdateCamera();
    }

    void UpdateCamera()
    {
        if (isFpp)
        {
            camera.SetParent(fpp, false);
        }
        else
        {
            camera.SetParent(tpp, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFpp = !isFpp;
            UpdateCamera();
        }    
    }
}
