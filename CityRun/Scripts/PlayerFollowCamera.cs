// PlayerFollowCamera.cs
using UnityEngine;

// プレイヤー追従カメラ
public class PlayerFollowCamera : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPos;

    void Start()
    {
        targetObj = GameObject.Find("Male_01_V02");
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;


        if (targetObj.GetComponent<PlayerController>().left == true)
        {
            transform.RotateAround(targetPos, Vector3.up, 0.35f);
        }
        if (targetObj.GetComponent<PlayerController>().right == true)
        {
            transform.RotateAround(targetPos, Vector3.down, 0.35f);
        }
        // マウスの左クリックを押している間
        if (Input.GetMouseButton(0))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 900f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            //   transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 500f);

        }
        if(Input.GetKey(KeyCode.Q))
        {
         
            transform.RotateAround(targetPos, Vector3.up, Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.E))
        {

            transform.RotateAround(targetPos, Vector3.down, Time.deltaTime * 100f);
        }
    }
}