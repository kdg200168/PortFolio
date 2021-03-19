using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    [SerializeField]
    private float walkSpeed = 10f;  //歩く速度
    [SerializeField, Range(0.1f, 50f)]
    private float angleSpeed = 5.6f;　//旋回速度
    private readonly float epsilon = 0.00001f;
    public float jumppower;　   //ジャンプ力
    public float forwardtime;
    public float lefttime;      //制限時間
    public float leftjumptime;      //制限時間
    public float righttime;     //制限時間
    public float rightjumptime;     //制限時間
    public float power ;
    float inputHorizontal;　     //ADキー
    float inputVertical;        //WSキー
    float moveSpeed = 10f;      //移動速度
    public int leftjumpcount;　//ジャンプ制限
    public int rightjumpcount; //ジャンプ制限
    public bool ground;        //床判定
    public bool forwardwall;   //前壁判定
    public bool leftwall;      //左壁判定
    public bool rightwall;     //右壁判定
    public bool forwardwallrun; //前壁キック状態判定
    public bool leftwallrun;   //左壁走り状態判定
    public bool rightwallrun;  //右壁走り状態判定
    public  bool left;         //カメラ時計移動フラグ
    public  bool right;        //カメラ反時計移動フラグ
    Vector3 moveDir;
    Vector3 leftDir;
    Vector3 rightDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
        GetComponent<Timer>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        moveDir = this.gameObject.transform.rotation * new Vector3(0f, 10.0f, 4.0f).normalized;
        leftDir = this.gameObject.transform.rotation * new Vector3(-3.0f, 5.0f, 1.5f).normalized;
        rightDir = this.gameObject.transform.rotation * new Vector3(3.0f, 5.0f, 1.5f).normalized;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
      //    Debug.Log(rb.velocity.magnitude);
     //   Debug.Log("ground");
      //  Debug.Log(left);
      //  Debug.DrawRay(transform.position, this.gameObject.transform.rotation * new Vector3(0f, 1.0f, 1.0f), Color.red, 2f);
      //  Debug.DrawRay(transform.position, this.gameObject.transform.rotation * new Vector3(-1.0f, 1.0f, 1f), Color.red, 1f);
     //   Debug.DrawRay(transform.position, this.gameObject.transform.rotation * new Vector3(1.0f, 1.0f, 1f), Color.red, 1f);
        Wallrun();
        Jump();
    }

    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定

        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        if (rb.velocity.magnitude < 5.0f)
        {
            //   rb.AddForce(new Vector3(inputVertical, 0, inputHorizontal) + moveSpeed * moveForward * 2);

            rb.AddForce(new Vector3(inputVertical, jumppower, inputHorizontal) + moveSpeed * moveForward);
        }

        // キャラクターの向きを進行方向に
        if (moveForward.sqrMagnitude > epsilon)
        {
            moveForward = moveForward.normalized;
            anim.SetBool("Run", true);
            anim.SetFloat("speed", 10f, 0.01f, Time.deltaTime);
            Quaternion q = Quaternion.LookRotation(moveForward.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * angleSpeed);
            float speed = walkSpeed * Mathf.Pow(Mathf.Max(0, Vector3.Dot(transform.forward, moveForward)), power);
            transform.position += Time.deltaTime * transform.forward * speed;
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetFloat("speed", 0f);
        }
    }

    void Jump()
    {
        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            jumppower = 40f;
            anim.SetBool("jump", true);
            rb.AddForce( new Vector3(0, jumppower, 0),ForceMode.Impulse);
        }
        else
        {
            jumppower = 0f;
            anim.SetBool("jump", false);
        }
        //落下判定
        if (!ground && !rightwallrun && !leftwallrun && !forwardwallrun)
        {
            //   rb.useGravity = true;
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("fall", false);
        }
    }

    void Wallrun()
    {
        int mask = 1 << 8;
        RaycastHit hit;
        //前壁処理
     /*   if (!forwardwallrun)
        {
            forwardtime = 0f;

            if (Input.GetKeyDown(KeyCode.Space) && forwardwall)
            {

                forwardwallrun = true;
                anim.SetBool("wallflip", true);
                rb.useGravity = false;
            }
        }
        else if (forwardwallrun)
        {
            forwardtime += Time.deltaTime;

            if (forwardtime > 1.0f && forwardwallrun)
            {
                rightjumpcount++;
                forwardwallrun = !forwardwallrun;
                anim.SetBool("wallflip", false);
                rb.useGravity = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && forwardwallrun)
            {
                //leftjumpcount++;
                forwardwallrun = false;
                rb.useGravity = true;
                rb.AddForce(moveDir, ForceMode.Impulse);
                anim.SetBool("wallflip", false);
                anim.SetBool("jump", true);
            }
        } */
        //　左壁走り　処理
        if (!leftwallrun && leftjumpcount < 1)
        {
            lefttime = 0f;
           left = false;
            if (Input.GetKeyDown(KeyCode.Space) && leftwall)
            {
                leftwallrun = true;
                anim.SetBool("leftwallrun", true);
                rb.useGravity = false;
            }
        }
        else if (leftwallrun)
        {
            lefttime += Time.deltaTime;
            if (lefttime > 1.3f && leftwallrun)
            {
                leftjumpcount++;
                leftwallrun = !leftwallrun;
                anim.SetBool("leftwallrun", false);
                rb.useGravity = true;

            }
            //   rb.useGravity = false;
            //  anim.SetBool("wallrun", true);
            if (Input.GetKeyDown(KeyCode.Space) && leftwall)
            {
                leftjumpcount++;
                leftwallrun = false;
                rb.useGravity = true;
                Quaternion q = Quaternion.LookRotation(leftDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, angleSpeed /2 );
                rb.AddForce(leftDir, ForceMode.Impulse);
        
                anim.SetBool("leftwallrun", false);
                anim.SetBool("jump", true);
                left = true;       
            }
        }
        if (left)
        {
            leftjumptime += Time.deltaTime;
            if (leftjumptime > 1.0f)
            {
                left = false;
            }
        }else if(!left)
        {
            leftjumptime = 0f;
        }
        // 右壁走り処理
        if (!rightwallrun && rightjumpcount < 1)
        {
            righttime = 0f;
            right = false;
            if (Input.GetKeyDown(KeyCode.Space) && rightwall)
            {

                rightwallrun = true;
                anim.SetBool("rightwallrun", true);
                rb.useGravity = false;
            }
        }
        else if (rightwallrun)
        {
            righttime += Time.deltaTime;

            if (righttime > 1.3f && rightwallrun)
            {
                rightjumpcount++;
                rightwallrun = !rightwallrun;
                anim.SetBool("rightwallrun", false);
                rb.useGravity = true;
            }
            //   rb.useGravity = false;
            //  anim.SetBool("wallrun", true);
            if (Input.GetKeyDown(KeyCode.Space) && rightwall)
            {
                rightjumpcount++;
                rightwallrun = false;
                rb.useGravity = true;
                rb.AddForce(rightDir, ForceMode.Impulse);
                Quaternion q = Quaternion.LookRotation(rightDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, angleSpeed / 2);
                anim.SetBool("rightwallrun", false);
                anim.SetBool("jump", true);
                right = true;
            }
        }
        if (right)
        {
            rightjumptime += Time.deltaTime;
            if (rightjumptime > 1.0f)
            {
                right = false;
            }
        }
        else if (!right)
        {
            rightjumptime = 0f;
        }
        //前のみ壁判別
      /*  if (Physics.Raycast(transform.position, transform.transform.forward + transform.transform.up, out hit, 1.5f, mask)
            && Physics.Raycast(transform.position, -transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && Physics.Raycast(transform.position, transform.transform.right + transform.transform.forward, out hit, 1.5f, mask))
        {

            Vector3 n = hit.normal;
            float h = Mathf.Abs(Vector3.Dot(-moveDir, n));
            Vector3 r = moveDir + 2 *  n * h;
            moveDir = r;
          //  Debug.Log(moveDir);
            Debug.DrawRay(hit.point,moveDir, Color.green, 2f);
        //    Debug.Log("forwardwallhit");
            forwardwall = true;

            if (moveDir.x >= 500)
            {
                moveDir.x = 500;
            }
            else if (moveDir.x <= 500)
            {
                moveDir.x = -500;
            }
            if (moveDir.y >= 500)
            {
                moveDir.y = 500;
            }
            else if (moveDir.y <= -500)
            {
                moveDir.y = -500;
            }
            if (moveDir.z >= 500)
            {
                moveDir.z = 500;
            }
            else if (moveDir.z <= -500)
            {
                moveDir.z = -500;
            }
        }
        else
        {
            moveDir = this.gameObject.transform.rotation * new Vector3(0f, 1.0f, 1.0f); ;
            forwardwall = false;
            anim.SetBool("wallflip", false);
        } */
        // 左壁判別
        if (Physics.Raycast(this.transform.position, -this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && !Physics.Raycast(this.transform.position, this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && (Physics.Raycast(this.transform.position, -this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            || Physics.Raycast(this.transform.position, this.transform.transform.forward + transform.transform.up, out hit, 1.5f, mask)))
        {
            Vector3 n = hit.normal ;
            float h = Mathf.Abs(Vector3.Dot(-leftDir, n));
            Vector3 r = leftDir + 2 * n * h;
            leftDir = r;
          //  Debug.Log("lefthit");
            leftwall = true;
         //   leftjumpcount = 0;
            rightjumpcount = 0;
            Debug.DrawRay(hit.point,leftDir, Color.blue, 2f);
        //    Debug.Log(leftDir);

            if (leftDir.x >= 600)
            {
                leftDir.x = 600;
            }
            else if (leftDir.x <= -600)
            {
                leftDir.x = -600;
            }
            if (leftDir.y >= 600)
            {
                leftDir.y = 600;
            }
            else if (leftDir.y <= -600)
            {
                leftDir.y = -600;
            }
            if (leftDir.z >= 600)
            {
                leftDir.z = 600;
            }
            else if (leftDir.z <= -600)
            {
                leftDir.z = -600;
            }
        }
        else
        {
            leftDir = this.gameObject.transform.rotation * new Vector3(-1.0f, 1.0f, 1.0f).normalized;
            leftwall = false;
            leftwallrun = false;
            anim.SetBool("leftwallrun", false);
            

        }
        // 右壁判別
        if (Physics.Raycast(this.transform.position, transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && !Physics.Raycast(this.transform.position, -this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && (Physics.Raycast(this.transform.position, this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            || Physics.Raycast(this.transform.position, this.transform.transform.forward + transform.transform.up, out hit, 1.5f, mask)))
        {

            Vector3 n = hit.normal;
            float h = Mathf.Abs(Vector3.Dot(-rightDir, n));
            Vector3 r = rightDir + 2 * n * h;
            rightDir = r;
         //   Debug.Log("righthit");
            rightwall = true;
            leftjumpcount = 0;
         //   rightjumpcount = 0;

            //   Debug.DrawRay(hit.point, rightDir, Color.yellow, 2f);
            if (rightDir.x >= 600)
            {
                rightDir.x = 600;
            }
            else if (rightDir.x <= -600)
            {
                rightDir.x = -600;
            }
            if (rightDir.y >= 600)
            {
                rightDir.y = 600;
            }
            else if (rightDir.y <= -600)
            {
                rightDir.y = -600;
            }
            if (rightDir.z >= 600)
            {
                rightDir.z = 600;
            }
            else if (rightDir.z <= -600)
            {
                rightDir.z = -600;
            }
        }
        else
        {
            rightDir = this.gameObject.transform.rotation * new Vector3(1.0f, 1.0f, 1.0f).normalized;
            rightwall = false;
            rightwallrun = false;
            anim.SetBool("rightwallrun", false);
  
            //   rb.useGravity = true;
        }
        //前左右壁に当たってなかったら重力付与
        if (!Physics.Raycast(this.transform.position, this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && !Physics.Raycast(this.transform.position, -this.transform.transform.right + transform.transform.forward, out hit, 1.5f, mask)
            && !Physics.Raycast(this.transform.position, this.transform.transform.forward + transform.transform.up, out hit, 1.5f, mask))
        {
            rb.useGravity = true;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            ground = true;
            rightjumpcount = 0;
            leftjumpcount = 0;
        }
 
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            ground = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal")
        {
            Timer.count = true;
            FadeManager.Instance.LoadScene("ClearScene", 1f);
        }
    }

}