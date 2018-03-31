using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// xuanrantuozhan 
/// </summary>
public static class RendererExtensions {

	public static bool IsVisibleForm (this Renderer renderer, Camera camera)
	{ 
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes (camera);
		return GeometryUtility.TestPlanesAABB (planes, renderer.bounds);
	}

}
