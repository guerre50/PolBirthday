using UnityEngine;
using System.Collections;
using Radical;

public class Spin : MonoBehaviour {
	public Vector3 axis;
	public Vector2 velocityRange = new Vector2(-20.0f, 20.0f);
	public bool useAudio = false;
	public Vector2 changeDirectionRange = new Vector2(5.0f, 20.0f);
	
	private SmoothFloat velocity;
	private AudioAnalyzer _audioAnalyzer;
	private int _direction = 1;
	
	void Start () {
		velocity = Random.Range(velocityRange.x, velocityRange.y);
		_audioAnalyzer = AudioAnalyzer.instance;
		_.Wait (Random.Range(changeDirectionRange.x, changeDirectionRange.y)).Done (ChangeDirection);
	}
	
	void Update () {
		if (useAudio) {
			velocity.Value = Mathf.Lerp(velocityRange.x, velocityRange.y, _audioAnalyzer.dbNormalized);
		}
		float spin = velocity*Time.deltaTime*_direction;
		transform.Rotate(axis.x*spin, axis.y*spin, axis.z*spin);
	}
	
	void ChangeDirection() {
		_direction = -_direction;
		_.Wait (Random.Range(changeDirectionRange.x, changeDirectionRange.y)).Done (ChangeDirection);
	}
}
