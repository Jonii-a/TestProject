//https://qiita.com/Eureka/items/716f4f52b4106419dbec
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string[] textMessage; //テキストの加工前の一行を入れる変数
    static public string[,] Poke_Data; //テキストの複数列を入れる2次元は配列 

    private int rowLength; //テキスト内の行数を取得する変数
    private int columnLength; //テキスト内の列数を取得する変数
    // Start is called before the first frame update
    void Start()
    {
        Initialized();
        //Debug.Log("ビードルのぼうぎょ" + Poke_Data[1, 2]);
    }

    void Initialized()
    {
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("isPoke_Data", typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text;
        textMessage = TextLines.Split('\n'); //

        //行数と列数を取得
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2次配列を定義
        Poke_Data = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split('\t'); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入

            for (int n = 0; n < columnLength; n++)
            {
                Poke_Data[i, n] = tempWords[n]; //2次配列textWordsにカンマごとに分けたtempWordsを代入していく
                //Debug.Log(Poke_Data[i, n]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }
}
