using UnityEngine;
using System.Collections;

public class Logic : MonoBehaviour {
	public GameObject masterCubePrefab;
	public int numberCubes;
	
	private Vector3 _bottomLeft;
	private Vector3 _topRight;
	
	void Start () {
		_bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
		_topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		_bottomLeft.z = Camera.main.transform.position.z + (Camera.main.farClipPlane - Camera.main.nearClipPlane)/2;
		_topRight.z = Camera.main.transform.position.z + Camera.main.farClipPlane;
		
		for(int i = 0; i < numberCubes; ++i) {
			Instantiate(masterCubePrefab, RandomPosition(), transform.rotation);	
		}
	}
	
	Vector3 RandomPosition() {
		return new Vector3(Random.Range(_bottomLeft.x, _topRight.x), Random.Range(_bottomLeft.y, _topRight.y), Random.Range(_bottomLeft.z, _topRight.z));
	}
}
