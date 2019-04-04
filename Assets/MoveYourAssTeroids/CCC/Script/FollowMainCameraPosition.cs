using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCameraPosition : FollowTransformPosition
{
    protected override Transform CheckForValidePointToFollow()
    {
        if (Camera.main != null)
            return Camera.main.transform;
        if (Camera.allCamerasCount > 0)
            return Camera.allCameras[0].transform;
        return null;
    }
}
