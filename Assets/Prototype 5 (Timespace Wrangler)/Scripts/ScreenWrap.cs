using System;
using UnityEngine;

// A component to attach to each prefab-object that could potentially screen-wrap.
public class ScreenWrap : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        // First, attach a FindMyKeys variable to this object
        // (in the form of a translation from this object's world-position to a viewport-point).
        
        Vector2 findMyKeys = _camera.WorldToViewportPoint(transform.position);  //implicitly: (this.GameObject.transform.position)
        
        // (Why "FindMyKeys"? Because its only job is to locate the object onto which it is attached.)

        // Then, track FindMyKeys. If it exits the viewport's bounds ( > 1 or < 0 ), zap it to the opposite side.
        if (findMyKeys.x > 1.0f)
        {
            findMyKeys.x = 0.0f;
        }
        if (findMyKeys.x < 0.0f)
        {
            findMyKeys.x = 1.0f;
        }
        if (findMyKeys.y > 1.0f)
        {
            findMyKeys.y = 0.0f;
        }
        if (findMyKeys.y < 0.0f)
        {
            findMyKeys.y = 1.0f;
        }

        // Finally, assign the attached object's transform's position to copy the values of the FindMyKeys but
        // translated back from a Viewport-Point to a World-Point.
        transform.position = _camera.ViewportToWorldPoint(findMyKeys);
    }
}
