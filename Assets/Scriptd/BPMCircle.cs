using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMCircle : MonoBehaviour
{
    public SerialHandler serialHandler;

    [SerializeField]
    float pospoX, pospoY;

    public float speed;
    public float radius;
    public float zPosition;
    float x;
    float y;
    float z;


    private TrailRenderer _trailLenderer;

    public float beat;
    public float timer;
    public float bpm;

    // Use this for initialization
    void Start()
    {
        speed = 3.75f;
        radius = 16f;

        zPosition = 0f;

        _trailLenderer = GetComponent<TrailRenderer>();



        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;

    }



    void OnDataReceived(string message)
    {

        float bpnint;

        if (float.TryParse(message, out bpnint))
        {
    
            beat = bpnint;
        }
        else
        {
            //Debug.Log("数値に変換できません");
        }

    }


    // Update is called once per frame
    void Update()
    {
        bpm = 60 / beat;
        Debug.Log(bpm);

        x = pospoX + (radius * Mathf.Sin(Time.time * speed));
        z = zPosition;
        y = pospoY + (radius * Mathf.Cos(Time.time * speed));

        transform.position = new Vector3(x, y, z);


        if (timer > bpm)
        {
            timer -= bpm;
            radius = 8f;
        }
        else
        {
            radius = 16f;
        }

        timer += Time.deltaTime;

    }


}