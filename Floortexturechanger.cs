using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
// GoogleARCore.HelloAR;

public class PlaneVisualizationManager : MonoBehaviour {
   
    /// A prefab for tracking and visualizing detected planes.
    
    public GameObject TrackedPlanePrefab;

    private List<TrackedPlane> _newPlanes = new List<TrackedPlane>();
    
	// Update is called once per frame
	void Update ()
	{
		Session.GetTrackables<TrackedPlane>(_newPlanes, TrackableQueryFilter.New);

	    
	    foreach (var curPlane in _newPlanes)
	    {
            
	        var planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
	            transform);
	        planeObject.GetComponent<TrackedPlaneVisualizer>().Initialize(curPlane);

	        // Apply a random color and grid rotation.
	        planeObject.GetComponent<Renderer>().material.SetColor("_GridColor", new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
	        planeObject.GetComponent<Renderer>().material.SetFloat("_UvRotation", Random.Range(0.0f, 360.0f));
	    }
    }
}
