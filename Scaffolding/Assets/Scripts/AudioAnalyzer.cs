using UnityEngine;
using System.Collections;
using System.Collections.Generic;
	
public class AudioAnalyzer : Singleton<AudioAnalyzer> {
	private const float REFVALUE = 0.1f;
	private float db;
	private float[] samples = new float[1024];
	
	public float dbNormalized;

	public void Update () {
		audio.GetOutputData(samples, 0);

		float sum = 0;
		for (int i = 0; i < samples.Length; ++i) {
			sum += Mathf.Pow(samples[i], 2);
		}
		
		float rms = Mathf.Sqrt(sum/samples.Length);
		db = 20*Mathf.Log10(rms/0.1f);
 		
		dbNormalized = db/10.0f;
	}
}