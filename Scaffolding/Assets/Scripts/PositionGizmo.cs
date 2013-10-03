using UnityEngine;
using System.Collections;

public class PositionGizmo : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.DrawSphere(transform.position, 0.1f);	
	}
}
