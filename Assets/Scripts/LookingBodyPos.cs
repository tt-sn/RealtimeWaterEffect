using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingBodyPos : MonoBehaviour {


    //Metaballsのオブジェクトをアタッチする
    [SerializeField] GameObject MetaB;


    [SerializeField] GameObject L,R;

    void Start()
    {

            MetaB = GameObject.Find("Metaballs");

    }
    	
	// Update is called once per frame
	void Update () {
		
        if(GameObject.Find("HandLeft") != null)
        {
            L = GameObject.Find("HandLeft");
            MetaB.GetComponent<PosCatch>().LHand = L;
        }
        if (GameObject.Find("HandRight") != null)
        {
            R = GameObject.Find("HandRight");
            MetaB.GetComponent<PosCatch>().RHand = R;
        }

        


    }
}
