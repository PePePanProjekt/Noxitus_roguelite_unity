using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPos;
    public Vector3 worldPos;
    private Plane plane = new Plane(Vector3.down, 0);
    
    void Update()
    {
        screenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (plane.Raycast(ray, out float distance))
        {
            worldPos = ray.GetPoint(distance);
        }
    }

    public Vector3 GetMousePos()
    {
        return worldPos;
    }
}
