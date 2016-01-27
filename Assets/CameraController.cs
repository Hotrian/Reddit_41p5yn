using UnityEngine;

[RequireComponent(typeof(Camera) ,typeof(Rigidbody2D))]
public class CameraController : MonoBehaviour
{
    [Range(1f, 128f)]
    public float zoomScale = 1f;

    private float lastPixelWidth = 0f;
    private float lastPixelHeight = 0f;
    private Camera myCamComponent;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myCamComponent = gameObject.GetComponent<Camera>();
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Resize the game camera
    void Update()
    {
        var tVar = Screen.height / (2f * zoomScale);
        if (myCamComponent.orthographicSize != tVar || lastPixelWidth != myCamComponent.pixelWidth || lastPixelHeight != myCamComponent.pixelHeight)
        {
            myCamComponent.orthographicSize = tVar;
            lastPixelWidth = myCamComponent.pixelWidth;
            lastPixelHeight = myCamComponent.pixelHeight;
        }
    }

    // Keep running without the player if necessary
    void FixedUpdate()
    {
        if (!myRigidbody.isKinematic) // If we are kinematic we are attached to something
        {
            myRigidbody.velocity = new Vector2(PlayerController.runSpeed, 0f); // Move at the player's normal run speed if we aren't attached to one
        }
    }

    /// <summary>
    /// Parent the CameraController to a given PlayerController.
    /// </summary>
    /// <param name="control">The PlayerController to attach to.</param>
    public void attachCamera(PlayerController control)
    {
        gameObject.transform.parent = control.gameObject.transform;
        if (myRigidbody == null)
        {
            myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
        myRigidbody.isKinematic = true;
    }

    /// <summary>
    /// Parent the CameraController to a given CameraControllerNoYAxisFollow.
    /// </summary>
    /// <param name="control">The CameraControllerNoYAxisFollow to attach to.</param>
    public void attachCamera(CameraControllerNoYAxisFollow control)
    {
        gameObject.transform.parent = control.gameObject.transform;
        if (myRigidbody == null)
        {
            myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
        myRigidbody.isKinematic = true;
    }

    /// <summary>
    /// Detach the CameraController which will cause it to move on it's own instead of following a PlayerController.
    /// </summary>
    public void detachCamera()
    {
        gameObject.transform.parent = null;
        if (myRigidbody == null)
        {
            myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
        myRigidbody.isKinematic = false;
    }
}
