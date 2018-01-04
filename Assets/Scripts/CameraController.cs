using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float panBorderThickness = 50f;
    private bool doMovement = true;

    public float minYValue = 40f;
    public float maxYValue = 220f;

    // Update is called once per frame
    void Update () {
        if (!doMovement)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))   // If you press Escape, you toggle camera movement.
            doMovement = !doMovement;

        // Mouse Position depends on the resolution.
        // *Normalise this by dividing by screen height?
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);   // Forward = Vector3 0f,0f,1f;
            // Translate doesn't do any physics checks. It just moves it.
            // Moving Forward LOCALLY depends on rotation. but WORLD makes the movement relative to the world.
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);

        Vector3 scrollPosition = transform.position;    // Equal to our current position.


        scrollPosition.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        scrollPosition.y = Mathf.Clamp(scrollPosition.y, minYValue, maxYValue);

        transform.position = scrollPosition;
    }
}
