using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour {

    //Unityちゃんを定義
    private GameObject unitychan;
    //CarPrefabを定義
    public GameObject CarPrefab;
    //coinPrefabを定義
    public GameObject coinPrefab;
    //cornPrefabを定義
    public GameObject cornPrefab;

	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //CarPrefabのオブジェクトを取得
        this.CarPrefab = GameObject.Find("CarPrefab");
        //coinPrefabのオブジェクトを取得
        this.coinPrefab = GameObject.Find("coinPrefab");
        //cornPrefabのオブジェクトを取得
        this.cornPrefab = GameObject.Find("TrafficConePrefab");

	}
	
	// Update is called once per frame
	void Update () {
        //Unityちゃんのz軸がオブジェクトのz軸を超えた場合、オブジェクトを消す。
        if (unitychan.transform.position.z  > this.transform.position.z + 5.0f ) {
            Destroy(gameObject);
        }
	}
}
