using System.Collections;
using UnityEngine;

public class MakeWaterDrops : PosName
{

    //private int PartsCounter = 0;             //Parts Management
    [HideInInspector] public Vector3 Delta;

    //位置の差分をとる
    public void DeltaPos(Vector3 PosA,Vector3 PosB)
    {
        Delta = PosA - PosB;
    }

    //生成するobjに力を加える
    public void AdVec(GameObject drops)
    {

        int Highmater = Random.Range(LowMag, HighMag);

        //drops.GetComponent<Rigidbody>().useGravity = true;
        //drops.GetComponent<Rigidbody>().drag = 3;

        drops.GetComponent<Rigidbody>().AddForce(Highmater * Delta);

        if(!Grv)drops.GetComponent<Rigidbody>().useGravity = false;
        
    }

    //make water drops
    public void MakeDrops(Vector3 PosA, Vector3 PosB)
    {
        GameObject drops;

        Debug.Log("This ok");

        DeltaPos(PosA, PosB);


        //float AbDel = Mathf.Abs(Delta.x) + Mathf.Abs(Delta.y) + Mathf.Abs(Delta.z);

        //if (AbDel < 1.0)
        //{
        Water.GetComponent<BouncingBall>().radius = Random.Range(LowRad, HighRad);
        Water.GetComponent<BouncingBall>().radius = Random.Range(LowRad, HighRad);

        //}
        //else if (AbDel < 0.3)
        //{
        //    Water.GetComponent<BouncingBall>().radius = Random.Range(LowRad * 0.7f, HighRad * 0.7f);
        //}
        //else if (AbDel < 0.1)
        //{
        //    Water.GetComponent<BouncingBall>().radius = Random.Range(LowRad * 0.4f, HighRad * 0.4f);
        //}
        //else
        //{
        //    Water.GetComponent<BouncingBall>().radius = Random.Range(LowRad * 0.1f, HighRad * 0.1f);
        //}

        //Debug.Log(Water.GetComponent<BouncingBall>().radius);


        //if (Stop)
        //{
        //    if (Mathf.Abs(Delta.x) + Mathf.Abs(Delta.y) + Mathf.Abs(Delta.z) >= 0.05)
        //    {
        //        drops = Instantiate(Water, new Vector3(PosA.x, PosA.y, PosA.z), Quaternion.identity);
        //        drops.AddComponent<Rigidbody>();
        //        drops.transform.parent = transform;
        //        AdVec(drops);
        //    }

        //}
        //else
        //{
            drops = Instantiate(Water, new Vector3(PosA.x, PosA.y, PosA.z), Quaternion.identity);
            drops.AddComponent<Rigidbody>();
            drops.transform.parent = transform;
            AdVec(drops);
        //}

        //---------------------------------------------
        //
        //  本当は回転も取得して、ベクトルに掛け合わす
        //  計算も必要
        //  （重いかな？）
        //
        //------------------------------------------------

    }
}