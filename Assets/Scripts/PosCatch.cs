using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCatch : MakeWaterDrops {

    
    void LateStart()
    {

        //this.transform.localScale = new Vector3(4, 4, 4);
    }

    void Update () {

        //Convert localPos to WorldPos
        //_LHand   =   LHand.transform.position;
        //_RHand   =   RHand.transform.position;
        //_LShould = LShould.transform.position;
        //_RShould = RShould.transform.position;
        //_pHead   =    Head.transform.position;
        //_pHead = Head.transform.position;


        if (LHand != null && RHand != null)
        {
            _LHand = LHand.transform.position;
            _RHand = RHand.transform.position;
        }
            TimeCounter += Time.deltaTime;

        if ((TimeCounter > delFrame) && LHand != null && RHand != null)
        {
            //Position to pointer
            if (_LHand == null && LH) { _Pos[0,Counter] = _Pos[0,Counter - 1]; } else { _Pos[0,Counter] = _LHand; };
            if (_RHand == null && RH) { _Pos[1,Counter] = _Pos[1,Counter - 1]; } else { _Pos[1,Counter] = _RHand; };
            //if (_LShould == null && LS) { _Pos[2, Counter] = _Pos[2, Counter - 1]; } else { _Pos[2, Counter] = _LShould; };
            //if (_RShould == null && RS) { _Pos[3, Counter] = _Pos[3, Counter - 1]; } else { _Pos[3, Counter] = _RShould; };
            //if (_pHead == null && HE) { _Pos[4, Counter] = _Pos[4, Counter - 1]; } else { _Pos[4, Counter] = _pHead; };

            if (++Counter > 10) Counter = 1;
            TimeCounter = 0;

            if (LH) MakeDrops(_LHand, _Pos[0, Counter]);
            if (RH) MakeDrops(_RHand, _Pos[1, Counter]);
            //if (LS) MakeDrops(_LShould, _Pos[2, Counter]);
            //if (RS) MakeDrops(_RShould, _Pos[3, Counter]);
            //if (HE) MakeDrops(_pHead, _Pos[4, Counter]);

        }
        


    }
}
