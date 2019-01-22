using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

    [HideInInspector]
    public float speed;

    public GameObject _BoxUnitychan;
    private Vector3 _tmp;

	void Start () {
	
	}
	
	void Update () {

        this.transform.Rotate(Vector3.up, this.speed * Time.deltaTime);

        _tmp = _BoxUnitychan.transform.position;
        this.transform.position =  new Vector3(_tmp.x + 5 , _tmp.y + 5 , _tmp.z);
	}
}
