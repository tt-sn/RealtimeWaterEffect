using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChase : MonoBehaviour {

    public GameObject Body;
    private Vector3 _Body;

	void Update () {

        _Body = Body.transform.position;

        transform.position = _Body;

	}
}
