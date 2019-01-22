using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemanage : MonoBehaviour {

    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    bool count;

    public GameObject meta;


    void Start()
    {
        minute = 0;
        seconds = 0f;
        count = false;
    }

    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 2f && count == false)
        {
            count = true;

            meta.transform.localScale = new Vector3(
                meta.transform.localScale.x * 5,
                meta.transform.localScale.y * 5,
                meta.transform.localScale.z * 5
                );

            Debug.Log("P");
        }

    }
}
