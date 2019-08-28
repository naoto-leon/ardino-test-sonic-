using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using uOSC;

public class SerialLight : MonoBehaviour
{

    public SerialHandler serialHandler;
    public Text text;



    // Use this for initialization
    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    // Update is called once per frame
    void Update()
    {
        //var client = GetComponent<uOscClient>();


        //client.Send("/uOSC/test", message);
        //client.Send("/uOSC/test", 10, "hoge", 1.234f, new byte[] { 1, 2, 3 });
    }

    /*
	 * シリアルを受け取った時の処理
	 */
void OnDataReceived(string message)
    {
        var client = GetComponent<uOscClient>();
        //client.Send("/uOSC/test", 10, "hoge", 1.234f, new byte[] { 1, 2, 3 });

        //client.Send("/uOSC/test", message);

        //var data = message.Split(
        //   new string[] { "\t" }, System.StringSplitOptions.None);
        //if (data.Length < 2) return;


        int i;

        if (int.TryParse(message, out i))
        {
            //Debug.Log(i);
        }
        else
        {
            //Debug.Log("数値に変換できません");
        }

        client.Send("/uOSC/test", i);

        try
        {

            text.text = message; // シリアルの値をテキストに表示
                                 //var angleX = float.Parse(data[0]);
                                 //var angleY = float.Parse(data[1]);
                                 //Debug.Log(data);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }

       
    }
}
