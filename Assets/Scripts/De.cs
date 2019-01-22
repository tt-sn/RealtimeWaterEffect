using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class De : MonoBehaviour {

    [Range(3f,7f)]
    public float Timer = 2;

    void Start () {

            Destroy(gameObject , Timer);
    
	}
}
