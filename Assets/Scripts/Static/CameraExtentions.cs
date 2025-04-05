using UnityEngine;

public static class CameraExtentions
{

    public static float CalulateVerticalSize(this Camera camera) {
        return camera.orthographicSize;
    }

    public static float CalulateHorizontalSize(this Camera camera) {
        return camera.orthographicSize * camera.aspect;
    }

    /// <summary>
    /// Calculates the distance to the center of the orthographic camera from the center of the camera viewport 
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static float CalulateDistanceToCorner(this Camera camera) {
        var verticalSize = camera.CalulateVerticalSize();
        var horizontalSize = camera.CalulateHorizontalSize();
        return Mathf.Sqrt(verticalSize * verticalSize + horizontalSize + horizontalSize);
    }
}