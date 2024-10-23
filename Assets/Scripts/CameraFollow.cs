using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformをセット
    public float smoothSpeed = 0.125f; // カメラ移動のスムーズさ

    private Vector3 offset; // カメラのオフセット

    void Start()
    {
        // カメラとプレイヤーの初期位置の差分（オフセット）を記録
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // プレイヤーのX座標のみ追従し、YとZはそのまま
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

        // スムーズにカメラを移動
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }

}
