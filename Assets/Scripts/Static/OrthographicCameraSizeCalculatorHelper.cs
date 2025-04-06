using Bonk.StandardLibrary.Numerics;
using UnityEngine;

public class OrthographicCameraSizeCalculatorHelper
{

    private Camera camera;
    private float lastCalculatedToCorner;

    private float aspect, size;

    public OrthographicCameraSizeCalculatorHelper(Camera camera) {
        this.camera = camera;
        RecalculateDistanceToCorner();
    }

    public float CalulateSizeToCameraCorner(){
        if(OrthographicSizesChanged())
            RecalculateDistanceToCorner();

        return lastCalculatedToCorner;
    }

    private void RecalculateDistanceToCorner(){
        aspect = camera.aspect;
        size = camera.orthographicSize;
        lastCalculatedToCorner = camera.CalulateDistanceToCorner();
    }

    private bool OrthographicSizesChanged(){
        return aspect != camera.aspect || size != camera.orthographicSize;
    }

    public Vector2 GetViewportCenter() =>
        camera.transform.position.ToVector2();

}