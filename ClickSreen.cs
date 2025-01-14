using UnityEngine;

public class ClickSreen : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 GetMousePoint()
    {
        Vector3 getPoint = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                     Input.mousePosition.y, 
                                                                     Input.mousePosition.y));

        return getPoint;
    }
}
