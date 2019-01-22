//using UnityEditor;
//using System.Collections;
//using UnityEngine;

//[CustomEditor(typeof(PosCatch))]
//[CanEditMultipleObjects]
//public class PosNameEditor : Editor
//{
//    private bool foldout1, foldout2;

//    public override void OnInspectorGUI()
//    {

//        PosCatch posCatch = (PosCatch)target;

//        #region Gravity
//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("重力の影響");
//        posCatch.Grv = EditorGUILayout.Toggle(posCatch.Grv);
//        EditorGUILayout.EndHorizontal();
//        #endregion

//        #region Stop
//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("移動0で生成しない");
//        posCatch.Stop = EditorGUILayout.Toggle(posCatch.Stop);
//        EditorGUILayout.EndHorizontal();
//        #endregion

//        #region radius
//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("直径( " + posCatch.LowRad + " / " + posCatch.HighRad + ")");
//        EditorGUILayout.MinMaxSlider(ref posCatch.LowRad, ref posCatch.HighRad, 0.01f, 0.25f);
//        EditorGUILayout.EndHorizontal();
//        #endregion

//        #region Magni
//        float LM = posCatch.LowMag, HM = posCatch.HighMag;

//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("倍率( " + posCatch.LowMag + " / " + posCatch.HighMag + " )");
//        EditorGUILayout.MinMaxSlider(ref LM, ref HM, 1, 500);
//        posCatch.LowMag = Mathf.CeilToInt(LM);
//        posCatch.HighMag = Mathf.CeilToInt(HM);

//        EditorGUILayout.EndHorizontal();
//        #endregion

//        #region Frame
//        float min = 0;
//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("フレーム数" + posCatch.delFrame);
//        EditorGUILayout.MinMaxSlider(ref min, ref posCatch.delFrame, 0, 0.5f);
//        EditorGUILayout.EndHorizontal();
//        #endregion

//        #region　Position

//        foldout1 = EditorGUILayout.Foldout(foldout1, "取得部位");
//        if (foldout1)
//        {
//            GUI.enabled = true;

//            EditorGUILayout.BeginHorizontal();
//            posCatch.LH = EditorGUILayout.Toggle(posCatch.LH,GUILayout.Width(10));
//            //EditorGUILayout.TextField("左手", GUILayout.Width(50));
//            posCatch.LHand = EditorGUILayout.ObjectField(posCatch.LHand, typeof(GameObject), true) as GameObject;
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.BeginHorizontal();
//            posCatch.LS = EditorGUILayout.Toggle(posCatch.LS, GUILayout.Width(10));
//            posCatch.LShould = EditorGUILayout.ObjectField(posCatch.LShould, typeof(Object), true) as GameObject;
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.LabelField("");

//            EditorGUILayout.BeginHorizontal();
//            posCatch.RH = EditorGUILayout.Toggle(posCatch.RH, GUILayout.Width(10));
//            posCatch.RHand = EditorGUILayout.ObjectField(posCatch.RHand, typeof(GameObject), true) as GameObject;
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.BeginHorizontal();
//            posCatch.RS = EditorGUILayout.Toggle(posCatch.RS, GUILayout.Width(10));
//            posCatch.RShould = EditorGUILayout.ObjectField(posCatch.RShould, typeof(GameObject), true) as GameObject;
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.LabelField("");

//            EditorGUILayout.BeginHorizontal();
//            posCatch.HE = EditorGUILayout.Toggle(posCatch.HE, GUILayout.Width(10));
//            posCatch.Head = EditorGUILayout.ObjectField( posCatch.Head, typeof(GameObject), true) as GameObject;
//            EditorGUILayout.EndHorizontal();

//        }
//        #endregion
//    }
//}