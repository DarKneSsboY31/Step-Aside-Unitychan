using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //CarPrefabを入れる
    public GameObject CarPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject cornPrefab;

    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //アイテム発生場所 a
    private int a = -210;
    //アイテム発生場所 b
    private int b = -160;
    //アイテム発生場所 c
    private int c = -110;
    //アイテム発生場所 d
    private int d = -60;
    //アイテム発生場所 e
    private int e = -10;
    //アイテム発生場所 f
    private int f = 40;
    //アイテム発生場所 g
    private int g = 90;


    //アイテム呼び出し関数の作成
    private void ItemGenerate(int Now, int Next) {
        for (int i = Now; i < Next; i += 15)　　//ある地点からある地点の間でアイテムを一定間隔に生成
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(CarPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }


    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //スタート時にaからbの位置にアイテムを生成
        ItemGenerate(a, b);
        }

    // Update is called once per frame
    void Update()
    {
        
        if (unitychan.transform.position.z > a && unitychan.transform.position.z < a + 0.5f)       //場所aを通り過ぎた場合、bからcの位置でアイテム生成
        {
            ItemGenerate(b, c);
  
        }else if (unitychan.transform.position.z > b && unitychan.transform.position.z < b + 0.5f) //場所bを通り過ぎた場合、cからdの位置でアイテム生成
        {
            ItemGenerate(c, d);
        }
        else if (unitychan.transform.position.z > c && unitychan.transform.position.z < c + 0.5f) //場所cを通り過ぎた場合、dからeの位置でアイテム生成
        {
            ItemGenerate(d, e);
        }
        else if (unitychan.transform.position.z > d && unitychan.transform.position.z < d + 0.5f) //場所dを通り過ぎた場合、eからfの位置でアイテム生成
        {
            ItemGenerate(e, f);
        }
        else if (unitychan.transform.position.z > e && unitychan.transform.position.z < e + 0.5f) //場所eを通り過ぎた場合、fからgの位置でアイテム生成
        {
            ItemGenerate(f, g);
        }
        else if (unitychan.transform.position.z > f && unitychan.transform.position.z < f + 0.5f) //場所fを通り過ぎた場合、gからgoalPosの位置でアイテム生成
        {
            ItemGenerate(g, goalPos);
        }

    }
}
