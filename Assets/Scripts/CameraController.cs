using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float panBorderThickness = 50f;
    private bool doMovement = true;

    public float minYValue = 10f;
    public float maxYValue = 80f;

    private float minXValue = -5f;
    private float maxXValue = 100f;
    private float minZValue = -50f;
    private float maxZValue = 55f;

    // Update is called once per frame
    void Update () {
        if (!doMovement)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))   // If you press Escape, you toggle camera movement.
            doMovement = !doMovement;

        // Mouse Position depends on the resolution.
        // *Normalise this by dividing by screen height?
        if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) && transform.position.z < maxZValue)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);   // Forward = Vector3 0f,0f,1f;   
        //transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);   // Forward = Vector3 0f,0f,1f;
        // Translate doesn't do any physics checks. It just moves it.
        // Moving Forward LOCALLY depends on rotation. but WORLD makes the movement relative to the world.

        if ((Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) && transform.position.z > minZValue)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        if ((Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) && transform.position.x > minXValue)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) && transform.position.x < maxXValue)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 scrollPosition = transform.position;
        /*
         scrollPosition.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
         scrollPosition.y = Mathf.Clamp(scrollPosition.y, minYValue, maxYValue);
          * */
        scrollPosition += transform.forward * (scroll * 100);
        scrollPosition.x = Mathf.Clamp(scrollPosition.x, minXValue, maxXValue);
        scrollPosition.y = Mathf.Clamp(scrollPosition.y, minYValue, maxYValue);
        scrollPosition.z = Mathf.Clamp(scrollPosition.z, minZValue, maxZValue);

        transform.position = scrollPosition;
    }
}
