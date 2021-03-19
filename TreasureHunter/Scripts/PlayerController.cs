using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 4.5f;
    [SerializeField]
    private float crouchSpeed = 1.0f;
    [SerializeField]
    private float climbSpeed = 1f;
    [SerializeField]
    private float hangSpeed = 1f;
    [SerializeField, Range(0.1f, 50f)]
    private float angleSpeed = 5.6f;
    private Animator animator;
    public float JumpPower = 4;
    private bool OnGround;
    private Rigidbody rb;
    private bool crouch;
    private bool CanHang;
    private bool CanGrab;
    private bool jump;
    private bool run;
    private bool climbing;
    public bool dead;
    private bool hanging;
    public bool Clear;
    private float power;
    private readonly float epsilon = 0.00001f;
    private new CapsuleCollider collider;
    private Timer timer;
 


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       collider = GetComponent<CapsuleCollider>();
        timer = GetComponent<Timer>();
        CanGrab = false;
        climbing = false;
        collider.center = new Vector3(0, 0.85f, 0);
        collider.radius = 0.4f;
        collider.height = 1.8f;
        dead = false;
        Clear = false;
        hanging = false;
       

}

    // Update is called once per frame
    void Update()
    {
        Vector3 walkDirection = Vector3.zero;

        // 前進
        if (Input.GetKey(KeyCode.W) && !climbing && !crouch && !dead && !hanging && !Clear)
        {
            walkDirection.z += 2;

        }
        //　後退
        if (Input.GetKey(KeyCode.S) && !climbing && !crouch && !dead && !hanging && !Clear)
        {
            walkDirection.z -= 2;

        }
        // 右移動
        if (Input.GetKey(KeyCode.D) && !climbing && !crouch && !dead && !hanging && !Clear)
        {
            walkDirection.x += 2;
        }
        // 左移動
        if (Input.GetKey(KeyCode.A) && !climbing && !crouch && !dead && !hanging && !Clear)
        {
            walkDirection.x -= 2;
        }
        // 移動キー入力をしている方向に振り向く, アニメーション再生
        if (walkDirection.sqrMagnitude > epsilon)
        {
            walkDirection = walkDirection.normalized;
            animator.SetBool("Run", true);
            Quaternion q = Quaternion.LookRotation(walkDirection.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * angleSpeed);
            float speed = walkSpeed * Mathf.Pow(Mathf.Max(0, Vector3.Dot(transform.forward, walkDirection)), power);
            transform.position += Time.deltaTime * transform.forward * speed;
        }
        else
        {
            animator.SetBool("Run", false);
        }
        //　地面に付いててしゃがみ状態じゃないならジャンプ
        if (Input.GetKey(KeyCode.Space) && OnGround && !crouch && !climbing && !dead && !Clear)
        {
          //  print(OnGround);
            animator.SetBool("is_Jumping", true);
            rb.velocity = Vector3.up * JumpPower;
            OnGround = false;
            jump = true;

        }
        else
        {
            animator.SetBool("is_Jumping", false);
            jump = false;
        }

        // しゃがむ
        if (!crouch)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetBool("crouch", true);
                crouch = true;
                // コライダーの大きさを変える
                collider.center = new Vector3(0, 0.6f, 0);
                collider.radius = 0.4f;
                collider.height = 1.3f;
            }
        }
        //しゃがみ状態での操作
        else if (crouch)
        {
            Vector3 crouchDirection = Vector3.zero;
            //もう一度Cキーを押したら立ち上がる
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetBool("crouch", false);
                crouch = false;
                collider.center = new Vector3(0, 0.85f, 0);
                collider.radius = 0.4f;
                collider.height = 1.8f;
            }
            //  前進
            if (Input.GetKey(KeyCode.W) && crouch && !dead && !Clear)
            {
                crouchDirection.z += 1;
                animator.SetBool("is_walking", true);
            }

            //   後退
            if (Input.GetKey(KeyCode.S) && crouch && !dead && !Clear)
            {
                crouchDirection.z -= 1;
                animator.SetBool("is_walking", true);
            }

            //　右移動
            if (Input.GetKey(KeyCode.D) && crouch && !dead && !Clear)
            {
                crouchDirection.x += 1;
                animator.SetBool("is_walking", true);
            }

            // 左移動
            if (Input.GetKey(KeyCode.A) && crouch && !dead && !Clear)
            {
                crouchDirection.x -= 1;
                animator.SetBool("is_walking", true);
            }
            //入力したキーの方向に振り向く　+ アニメーション再生
            if (crouchDirection.sqrMagnitude > epsilon)
            {
               crouchDirection = crouchDirection.normalized;
                animator.SetBool("is_walking", true);
                Quaternion q = Quaternion.LookRotation(crouchDirection.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * angleSpeed);
                float speed = crouchSpeed * Mathf.Pow(Mathf.Max(0, Vector3.Dot(transform.forward, crouchDirection)), power);
                transform.position += Time.deltaTime * transform.forward * speed;
            }
            else
            {
                animator.SetBool("is_walking", false);
            }
        }
        //　掴めるポイントでクライミング状態じゃない場合
        if (CanGrab && !climbing)
        {
             //　スペースを押したらクライミング状態にして重力オフにする
            if (Input.GetKeyDown(KeyCode.Space))
            {
              //  Debug.Log("climbing");
                climbing = true;
                animator.SetBool("climbing", true);
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                // コライダーのサイズを変更
                collider.center = new Vector3(0, 1.0f, 0);
                collider.radius = 0.4f;
                collider.height = 1.3f;
            }

        }
        //  クライミング状態になってたら
        else if (CanGrab && climbing)
        {
            Vector3 climbDirection = Vector3.zero;
            // 再度Spaceを押すと手を離す
            if (Input.GetKeyDown(KeyCode.Space))
            {
            
                climbing = false;
                animator.SetBool("climbing", false);
                rb.useGravity = true;
                //   コライダーサイズを元に戻す
                collider.center = new Vector3(0, 0.85f, 0);
                collider.radius = 0.4f;
                collider.height = 1.8f;
            }
            // 登る
            if (Input.GetKey(KeyCode.W) && climbing)
            {
                transform.position += transform.up * climbSpeed * Time.deltaTime;
                animator.SetBool("climbup", true);
            }
            else
            {
                animator.SetBool("climbup", false);
            }
            //   降る
            if (Input.GetKey(KeyCode.S) && climbing)
            {
                transform.position -= transform.up * climbSpeed * Time.deltaTime;
                animator.SetBool("climbdown", true);
            }
            else
            {
                animator.SetBool("climbdown", false);
            }
            //　右移動
            if (Input.GetKey(KeyCode.D) && climbing)
            {
                transform.position += transform.right * climbSpeed * Time.deltaTime;
                animator.SetBool("climbright", true);
            }
            else
            {
                animator.SetBool("climbright", false);

            }
            // 左移動
            if (Input.GetKey(KeyCode.A) && climbing)
            {
                transform.position -= transform.right * climbSpeed * Time.deltaTime;
                animator.SetBool("climbleft", true);
            }
            else
            {
                animator.SetBool("climbleft", false);

            }

        }
        // ポイントで掴んでいない状態なら
        if (CanHang && !hanging)
        {
            //　Spaceを押したら掴んでいる状態にして重力オフにする
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hanging = true;
                animator.SetBool("hanging", true);
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
            }
        }

        else if (CanHang && hanging)
        {
            Vector3 hangDirection = Vector3.zero;
            //　手を離す
            if (Input.GetKeyDown(KeyCode.Space))
            {
        
                hanging = false;
                animator.SetBool("hanging", false);
                rb.useGravity = true;
            }
            //　 前進
            if (Input.GetKey(KeyCode.W) && hanging)
            {
                hangDirection.z += 3;
            }
            //  後退
            if (Input.GetKey(KeyCode.S) && hanging)
            {
                hangDirection.z -= 3;
            }
            //  右移動
            if (Input.GetKey(KeyCode.A) && hanging)
            {
                transform.position -= transform.right * hangSpeed * Time.deltaTime;
                animator.SetBool("hangleft", true);
            }
            else
            {
                animator.SetBool("hangleft", false);
            }
            //  左移動
            if (Input.GetKey(KeyCode.D) && hanging)
            {
                transform.position += transform.right * hangSpeed * Time.deltaTime;
                animator.SetBool("hangright", true);
            }
            else
            {
                animator.SetBool("hangright", false);
            }
            // 前進後退の時に振り向かせる + アニメーション再生
            if (hangDirection.sqrMagnitude > epsilon)
            {
                hangDirection = hangDirection.normalized;
                animator.SetBool("hangmove", true);
                Quaternion q = Quaternion.LookRotation(hangDirection.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * angleSpeed);
                float speed = hangSpeed * Mathf.Pow(Mathf.Max(0, Vector3.Dot(transform.forward, hangDirection)), power);
                transform.position += Time.deltaTime * transform.forward * speed;
            }
            else
            {
                animator.SetBool("hangmove", false);
            }
        }
              
    }

    void OnTriggerStay(Collider other)
    {
        // 登れるポイントの設定
        if (other.gameObject.tag == "wall")
        {
            CanGrab = true;
        }
        // 掴めるポイントの設定
        if (other.gameObject.tag == "HangingArea")
        {
            CanHang = true;
        }
        // クリア範囲に入ったら動きを止めてクリアタイムの測定をストップさせてクリアシーンに遷移
        if (other.gameObject.tag == "ClearArea")
        {
            Clear = true;
            Timer.count = true;
            animator.SetBool("Clear", true);
            Invoke("GoToGameClear", 5.0f);
        }

        if (other.gameObject.tag == "EndArea")
        {

            transform.position += transform.up * 3f * Time.deltaTime;

            CanGrab = false;
            CanHang = false;
            climbing = false;
          
            animator.SetBool("climbing", false);
            animator.SetBool("climbup", false);
            animator.SetBool("climbdown", false);
            animator.SetBool("climbleft", false);
            animator.SetBool("climbright", false);
            animator.SetBool("hangmove", false);
            animator.SetBool("hangleft", false);
            animator.SetBool("hangright", false);
            animator.SetBool("hanging", false);
            collider.center = new Vector3(0, 0.85f, 0);
            collider.radius = 0.4f;
            collider.height = 1.8f;

        }
        if (other.gameObject.tag == "deathArea")
        {
            dead = true;
            animator.SetBool("dead", true);
            Invoke("GoToGameOver", 5.0f);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            CanGrab = false;
            animator.SetBool("climbing", false);
            rb.useGravity = true;
            climbing = false;
            animator.SetBool("climbup", false);
            animator.SetBool("climbdown", false);
            animator.SetBool("climbleft", false);
            animator.SetBool("climbright", false);
            collider.center = new Vector3(0, 0.85f, 0);
            collider.radius = 0.4f;
            collider.height = 1.8f;
        }
        if (other.gameObject.tag == "HangingArea")
        {
            CanHang = false;
            animator.SetBool("hanging", false);
            rb.useGravity = true;
            hanging = false;
            animator.SetBool("hangmove", false);
            animator.SetBool("hangleft", false);
            animator.SetBool("hangright", false);
            collider.center = new Vector3(0, 0.85f, 0);
            collider.radius = 0.4f;
            collider.height = 1.8f;
        }
    }
 /*   public void TakeDamage(int damage)
    {
        playerhp -= damage;
        if (playerhp <= 0)
        {
            dead = true;
            animator.SetBool("dead", true);
            Invoke("GoToGameOver", 5.0f);
        }
    } */
    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    
    }
    void GoToGameClear()
    {
        SceneManager.LoadScene("GameClearScene");
    }
    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
            {
                OnGround = true;//  Groundedをtrueにする
            }

        }
}
