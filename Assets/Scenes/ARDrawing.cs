using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARDrawing : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject linePrefab; // Prefab for the drawing line
    private LineRenderer currentLine;
    private List<Vector3> drawnPositions = new List<Vector3>();

    void Start()
    {
        if (raycastManager == null)
        {
            Debug.LogError("ARRaycastManager is not assigned in the Inspector!");
        }

        if (linePrefab == null)
        {
            Debug.LogError("LinePrefab is not assigned! Assign it in the Inspector.");
        }
    }

    void Update()
    {
        Debug.Log("Number of detected planes: " + FindObjectsOfType<ARPlane>().Length); // Debugging detected planes

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            // ✅ Changed from PlaneWithinPolygon → PlaneEstimated to improve drawing accuracy
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneEstimated) && hits.Count > 0)
            {
                Pose hitPose = hits[0].pose;

                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("Touch detected - Starting Drawing");
                    StartDrawing(hitPose);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("Touch moved - Continuing Drawing");
                    ContinueDrawing(hitPose);
                }
            }
        }
    }

    void StartDrawing(Pose hitPose)
    {
        GameObject newLine = Instantiate(linePrefab, hitPose.position, Quaternion.identity);
        currentLine = newLine.GetComponent<LineRenderer>();

        if (currentLine == null)
        {
            Debug.LogError("LineRenderer component missing on linePrefab!");
            return;
        }

        // ✅ Ensures the line stays in world space
        currentLine.useWorldSpace = true;

        // ✅ Set line width to make it more visible
        currentLine.startWidth = 0.02f;
        currentLine.endWidth = 0.02f;

        drawnPositions.Clear();
        drawnPositions.Add(hitPose.position);
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, hitPose.position);

        Debug.Log("Started Drawing at: " + hitPose.position);
    }

    void ContinueDrawing(Pose hitPose)
    {
        if (currentLine == null)
        {
            Debug.LogWarning("No active line. Ignoring touch movement.");
            return;
        }

        if (drawnPositions.Count > 0 && Vector3.Distance(drawnPositions[drawnPositions.Count - 1], hitPose.position) > 0.01f)
        {
            drawnPositions.Add(hitPose.position);
            currentLine.positionCount = drawnPositions.Count;
            currentLine.SetPosition(drawnPositions.Count - 1, hitPose.position);

            Debug.Log("Drawing line at: " + hitPose.position);
        }
    }
}
