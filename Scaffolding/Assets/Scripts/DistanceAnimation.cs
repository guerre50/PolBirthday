using UnityEngine;
using System.Collections;
using Radical;

public class DistanceAnimation : MonoBehaviour {
	private AudioAnalyzer _audioAnalyzer;
	private SmoothFloat _distance;
	private Vector3 _originalPosition;
	public float maxDistance;
	
	void Start () {
		_distance = 0.0f;
		_audioAnalyzer = AudioAnalyzer.instance;
		_originalPosition = transform.position;
	}
	
	void Update () {
		_distance.Value = Mathf.Lerp(0.0f, maxDistance, _audioAnalyzer.dbNormalized);
		transform.position = _originalPosition - Vector3.forward*_distance;
	}
	
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(maxDistance, maxDistance, maxDistance));	
	}
}
