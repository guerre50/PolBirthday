using UnityEngine;
using System.Collections;
using Radical;

public class MasterCube : MonoBehaviour {
	private AudioAnalyzer _audioAnalyzer;
    private SmoothFloat _scale;
	private float _maxScale;
	
	public Color a;
	public Color b;
	
	void Start () {
		_audioAnalyzer = AudioAnalyzer.instance;
		_scale = 0.0f;
		_scale.Duration = 0.1f;
		_scale.Ease = EasingType.Sine;
		_scale.Mode = SmoothingMode.slerp;
		_maxScale = Random.Range(10.0f, 30.0f);
	}
	
	void Update () {
		float dbNormalized = _audioAnalyzer.dbNormalized;
		
		_scale.Value = Mathf.Lerp(0.0f, _maxScale, dbNormalized);
		transform.localScale = Vector3.one*_scale;
	 	renderer.material.color = Color.Lerp(b, a, dbNormalized);
	}
}
