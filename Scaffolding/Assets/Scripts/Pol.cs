using UnityEngine;
using System.Collections;

public class Pol : MonoBehaviour {
	public Texture2D[] faces;
	public GameObject plane;
	public Vector2 animationPeriod = new Vector2(2.0f, 10.0f);
	
	void Start () {
		_.Wait(Random.Range(animationPeriod.x, animationPeriod.x)).Done(AnimateFace);
		
		// Centering pol
		Vector3 pos = transform.position;
		Vector3 cameraPos = Camera.main.transform.position;
		cameraPos.z = pos.z;
		transform.position = cameraPos;
	}
	
	void AnimateFace() {
		plane.renderer.material.mainTexture = faces[Random.Range(1, faces.Length)];
		_.Wait(0.2f).Done(Idle);
		_.Wait(Random.Range(animationPeriod.x, animationPeriod.x)).Done(AnimateFace);
	}
	
	void Idle() {
		plane.renderer.material.mainTexture = faces[0];	
	}
}
