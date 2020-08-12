using UnityEngine;
using UnityEngine.EventSystems;

public class CameraBehaviour : MonoBehaviour
{
    public Camera mainCamera;
    private float speed = 2f;
    private float zoomSpeed = 0.1f;

    void LateUpdate()
    {
             ////////////// Android için Kontroller ////////////////////
            ////////////// Android için Kontroller ////////////////////

            float pinchAmount = 0;
            if (!EventSystem.current.IsPointerOverGameObject())
             {
                DetectTouchMovement.Calculate();
             }
            
            if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0)
            {
                pinchAmount = DetectTouchMovement.pinchDistanceDelta;
            }
            if (!EventSystem.current.IsPointerOverGameObject()) // bu
            mainCamera.orthographicSize -= pinchAmount * 0.01f;
            if (mainCamera.orthographicSize <= 1)
            {
                mainCamera.orthographicSize = 1;
            }
            else if (mainCamera.orthographicSize >= 10)
            {
                mainCamera.orthographicSize = 10;
            }
            if (!EventSystem.current.IsPointerOverGameObject() && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(-touchDeltaPosition.x * 0.005f, -touchDeltaPosition.y * 0.005f, 0);
            }

            ////////////// PC için Kontroller ////////////////////
            ////////////// PC için Kontroller ////////////////////


            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                mainCamera.orthographicSize += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                mainCamera.orthographicSize -= zoomSpeed;
            }



        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -10, 10),
            Mathf.Clamp(transform.position.y, -10, 10),
            Mathf.Clamp(transform.position.z, -10, 10));
       
    }
    public void ResetCameraPosition()
    {
        transform.position = new Vector3(0, -0, -10f);
        mainCamera.orthographicSize = 5f;
    }
}