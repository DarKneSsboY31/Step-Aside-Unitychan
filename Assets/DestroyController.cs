using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour {

    //Unityちゃんを定義
    private GameObject unitychan;
    
	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

	}
	
	// Update is called once per frame
	void Update () {
        //Unityちゃんのz軸がオブジェクトのz軸を超えた場合、オブジェクトを消す。
        if (unitychan.transform.position.z  > this.transform.position.z + 5.0f ) {
            Destroy(gameObject);
        }
	}
}
