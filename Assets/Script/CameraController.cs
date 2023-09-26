//https://a1026302.hatenablog.com/entry/2020/09/07/190005
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}