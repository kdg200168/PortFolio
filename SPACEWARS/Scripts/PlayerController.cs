using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    float intervalTime;
    public float maxSpead = 100; //最大速度
    public float accel; //加速
    public float brake; //減速
    public  float movespeed = 50; //現在のスピード
    private float minSpeed = 0; //最低速度 マイナスになりすぎないように

    // speedを制御する
    public float speed = 10;
    public float moveForceMultiplier;

    // 水平移動時に機首を左右に向けるトルク
    public float yawTorqueMagnitude = 30.0f;

    // 垂直移動時に機首を上下に向けるトルク
    public float pitchTorqueMagnitude = 60.0f;

    // 水平移動時に機体を左右に傾けるトルク
    public float rollTorqueMagnitude = 30.0f;

    // バネのように姿勢を元に戻すトルク
    public float restoringTorqueMagnitude = 100.0f;

    private Vector3 Player_pos;
    private new Rigidbody rigidbody;
    // bullet prefab
    public GameObject bullet;
    public GameObject bullet2;
  //  public GameObject bullet3;
    bool test;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        // バネ復元力でゆらゆら揺れ続けるのを防ぐため、angularDragを大きめにしておく
        rigidbody.angularDrag = 20.0f;
    }
    void Start()
    {
        //最低速度の割り出し（必要に応じて適当に設定）
        minSpeed = maxSpead * (float)0.2 * -1;
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //前進
        //shiftを押したら加速処理
        if (maxSpead >= movespeed)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //加速
                movespeed = movespeed + accel;
              //  Debug.Log("accel");
            }
        }


        //controllを押したら減速処理
        if (minSpeed <= movespeed)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                movespeed = movespeed - brake;
                if (movespeed < 50)
                {
                    movespeed = 50;
                }

              //  Debug.Log("brake");
            }
            // space キーが押された時

                intervalTime += Time.deltaTime;
                if (Input.GetKey("space"))
                {
                    if (intervalTime >= 0.2f)
                    {
                        intervalTime = 0.0f;
                        Instantiate(bullet, new Vector3(transform.position.x-1, transform.position.y, transform.position.z),this.transform.rotation);
                        Instantiate(bullet2, new Vector3(transform.position.x+1, transform.position.y, transform.position.z), this.transform.rotation);
                }
            }
        }

        //this.transform.Translate(0, 0, speed);
        this.transform.position += transform.forward * movespeed * Time.deltaTime;
            // xとyにspeedを掛ける
            rigidbody.AddForce(x * speed, y * speed, 0);

            Vector3 moveVector = Vector3.zero;

            rigidbody.AddForce(moveForceMultiplier * (moveVector - rigidbody.velocity));

            // プレイヤーの入力に応じて姿勢をひねろうとするトルク
            Vector3 rotationTorque = new Vector3(-y * pitchTorqueMagnitude, x * yawTorqueMagnitude, -x * rollTorqueMagnitude);

            // 現在の姿勢のずれに比例した大きさで逆方向にひねろうとするトルク
            Vector3 right = transform.right;
            Vector3 up = transform.up;
            Vector3 forward = transform.forward;
            Vector3 restoringTorque = new Vector3(forward.y - up.z, right.z - forward.x, up.x - right.y) * restoringTorqueMagnitude;

            // 機体にトルクを加える
            rigidbody.AddTorque(rotationTorque + restoringTorque);

        }
    }