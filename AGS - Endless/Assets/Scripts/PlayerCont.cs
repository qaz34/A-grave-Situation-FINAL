using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //Load scene testing Michael added, could lower performance?
public class PlayerCont : Seeable
{
    [Header("Player Setup")]
    [Tooltip("How fast the player will move")]
    public float moveSpeed = 10;
    [Tooltip("Speed when carrying body")]
    public float carrySpeed = 5;
    [Tooltip("Speed of the model turning, only for looks")]
    public float turnSpeed = .5f;
    [Tooltip("Current money")]
    public int moneh;
    [Tooltip("Money being carried on body")]
    public int carryMoneh;
    float baseMoveSpeed;
    public GameObject shovel;
    public GameObject lantern;
    [Header("Sounds")]
    [Tooltip("walk audio")]
    public AudioClip walk;
    [Tooltip("Dig audio")]
    public AudioClip Dig;
    private AudioSource audioSource;

    [Header("Sprint settings")]
    [Tooltip("How fast the player will run")]
    public float sprintSpeed;
    [Tooltip("How fast the player will run with body")]
    public float bodySprintSpeed;
    [Tooltip("Stamina regen per second")]
    public float stamina;
    [Tooltip("How fast the stamina is consumed")]
    public float consumedSpeed;
    [Tooltip("How fast the stamina is consumed with body")]
    public float bodyConsumedSpeed;
    [Tooltip("Stamina regen per second")]
    public float regen;
    [Tooltip("Stamina regen delay in seconds")]
    public float delay;
    [Tooltip("Speed after sprint without stamina")]
    public float noStaminaSpeed;
    private Animator anim;
    float maxStamina;
    bool drained = false;
    float timeDrained;
    private float coinLine = .11f;
    [Header("Coin Throwing")]
    [Tooltip("Coin Prefab")]
    public GameObject coin;
    [Tooltip("throwFrom empty")]
    public GameObject throwFrom;

    [Tooltip("The max force to throw the coin")]
    public float maxThrowForce = 30;
    [Tooltip("How High the coin will be thrown (higher for less)")]
    public float arkAmount = 2;
    [Tooltip("How fast you wind up the throw")]
    public float throwSpeed = 10;
    [Tooltip("How much moving changes the distance (higher for less)"), Range(.1f, 10)]
    public float moveThrow = 1;
    [Tooltip("How far away you can grab coins")]
    public float grabDistance = 2;
    private LineRenderer m_lr;
    private Transform m_camera;
    private bool carrying;
    private IEnumerator routine;
    private Collider triggerObject;
    private GameObject body;
    private IEnumerator lineDraw;
    Vector3 movement, moveDirection;
    private bool digging;
    private bool droppedThisFrame = true;
    private float timeHeld;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        lineDraw = DrawLine();
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        body = GameObject.FindGameObjectWithTag("CarryBody");
        m_lr = GetComponentInChildren<LineRenderer>();
        m_lr.gameObject.SetActive(false);
        body.SetActive(false);
        maxStamina = stamina;
        baseMoveSpeed = moveSpeed;
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            audioSource.volume *= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().sounds;
            moneh = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Money;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        triggerObject = other;
    }
    public void OnTriggerExit(Collider other)
    {
        if (routine != null)
            StopCoroutine(routine);
        triggerObject = null;
        Camera.main.GetComponent<CameraFollow>().reset();
    }
    public void TriggerHandle()
    {
        if (Input.GetButtonDown("Use") && triggerObject.tag == "diggable" && body.activeSelf == false)
        {
            digging = true;
            routine = triggerObject.gameObject.GetComponent<diggable>().dig();
            StartCoroutine(routine);
        }
        else if (Input.GetButtonDown("Use") && triggerObject.tag == "DropOff")
        {
            if (GameObject.FindGameObjectWithTag("Objective").GetComponent<objective>().Complete >= GameObject.FindGameObjectWithTag("Objective").GetComponent<objective>().ObjectiveNum && !body.activeSelf)
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                if (gm.career)
                {
                    gm.Money = moneh;
                    PauseMenu pm = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
                    Time.timeScale = 0;
                    pm.ShowMenu(3);
                }
            }
            else if (body.activeSelf)
            {
                if (GameObject.FindGameObjectWithTag("Objective") != null)
                    GameObject.FindGameObjectWithTag("Objective").SendMessage("Increment");
                if (GameObject.FindGameObjectWithTag("CorpseSpawn") != null)
                    GameObject.FindGameObjectWithTag("CorpseSpawn").SendMessage("MakeBody");

                moneh += carryMoneh;
                carryMoneh = 0;
                moveSpeed = carrySpeed;
                body.SetActive(false);
            }
        }
        else if (triggerObject.gameObject.GetComponent<diggable>() != null)
        {
            if (Input.GetButtonUp("Use") || triggerObject.gameObject.GetComponent<diggable>().percentComplete >= 100)
                digging = false;
        }
        if (Input.GetButtonUp("Use") && routine != null)
        {
            StopCoroutine(routine);
            Camera.main.GetComponent<CameraFollow>().reset();
        }

    }
    public void carry(int value)
    {
        carryMoneh = value;
        carrying = true;
        body.SetActive(carrying);
        moveSpeed = carrySpeed;
    }
    public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
    {
        return (start + startVelocity * time + Physics.gravity * time * time * coinLine);
    }
    IEnumerator DrawLine()
    {
        for (;;)
        {
            List<Vector3> verts = new List<Vector3>();
            Vector3 force = (transform.forward + (transform.up / arkAmount)).normalized;
            float throwAmount = Mathf.Clamp((Time.time - timeHeld) * throwSpeed, 0, maxThrowForce);
            force = force * throwAmount + (movement.normalized * throwAmount) / moveThrow;
            for (float i = 0; i < 3; i += .1f)
                verts.Add(transform.InverseTransformPoint(PlotTrajectoryAtTime(transform.position, force, i)));
            m_lr.SetVertexCount(verts.Count);
            for (var i = 0; i < verts.Count; i++)
                m_lr.SetPosition(i, verts[i]);
            m_lr.gameObject.SetActive(true);
            yield return new WaitForSeconds(.01f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = m_camera.TransformDirection(moveDirection);
        moveDirection.y *= 0;
        movement = moveDirection.normalized * moveSpeed;
        if (Input.GetAxisRaw("Drop") != 0 && moneh > 0 && droppedThisFrame)
        {
            timeHeld = Time.time;
            StartCoroutine(lineDraw);
            droppedThisFrame = false;
        }
        else if (Input.GetAxisRaw("Drop") == 0 && !droppedThisFrame)
        {
            moneh--;
            droppedThisFrame = true;
            GameObject go = Instantiate(coin, throwFrom.transform.position, Random.rotation) as GameObject;
            Physics.IgnoreCollision(go.GetComponent<Collider>(), GetComponent<Collider>(), true);
            Vector3 force = (transform.forward + (transform.up / arkAmount)).normalized;
            float throwAmount = Mathf.Clamp((Time.time - timeHeld) * throwSpeed, 0, maxThrowForce);
            go.GetComponent<Rigidbody>().AddForce(force * throwAmount);
            go.GetComponent<Rigidbody>().AddForce((movement.normalized * throwAmount) / moveThrow);
            StopCoroutine(lineDraw);
            lineDraw = DrawLine();
            m_lr.gameObject.SetActive(false);
        }
        if (triggerObject != null)
            TriggerHandle();
        if (Input.GetButtonDown("Use"))
        {
            var targets = Physics.OverlapSphere(transform.position, grabDistance);
            foreach (var target in targets)
                if (target.tag == "coin")
                    if (!target.GetComponent<CoinGrab>().grabbed)
                    {
                        moneh++;
                        Destroy(target.gameObject);
                        break;
                    }

        }
        if (Input.GetAxis("Sprint") != 0 && !drained && movement.magnitude > 0)
        {
            if (stamina >= consumedSpeed)
            {
                if (body.activeSelf == false)
                {
                    moveSpeed = sprintSpeed;
                }
                else
                {
                    moveSpeed = bodySprintSpeed;
                }
                if (body.activeSelf == false)
                    stamina -= consumedSpeed;
                else
                    stamina -= bodyConsumedSpeed;

                if (stamina < consumedSpeed)
                {
                    stamina = 0;
                    timeDrained = Time.time;
                    drained = true;
                }
            }
            else
            {
                stamina = 0;
                timeDrained = Time.time;
                drained = true;
            }

        }
        else if (stamina < maxStamina && (Input.GetAxis("Sprint") == 0 || drained))
        {
            if (drained)
            {
                if (body.activeSelf == false)
                    moveSpeed = noStaminaSpeed;
                else
                    moveSpeed = carrySpeed;
            }
            else
            {
                if (body.activeSelf == false)
                    moveSpeed = baseMoveSpeed;
                else
                    moveSpeed = carrySpeed;
            }
            if ((Time.time - timeDrained) > delay)
            {
                stamina += regen;
                if (stamina >= maxStamina)
                {
                    drained = false;
                    stamina = maxStamina;
                }
            }
        }
        else
        {
            if (body.activeSelf == false)
                moveSpeed = baseMoveSpeed;
            else
                moveSpeed = carrySpeed;
        }
        if (digging)
        {
            lantern.SetActive(false);
            shovel.SetActive(true);
            moveSpeed = 0;
        }
        else if (body.activeSelf)
        {
            lantern.SetActive(false);
            shovel.SetActive(false);
        }
        else
        {
            lantern.SetActive(true);
            shovel.SetActive(false);
        }
        anim.SetBool("Carry", body.activeSelf);
        anim.SetBool("Digging", digging);
        if (shovel.activeSelf == true)
            shovel.GetComponent<Animator>().SetBool("Digging", digging);
    }
    public override bool Seen(string tag)
    {
        if (tag == "Player")
            return true;
        else
            return false;
    }
    void FixedUpdate()
    {
        Vector3 temp = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;
        if (moveDirection.magnitude > 0)
        {
            if (!digging)
                transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(moveDirection), transform.rotation, turnSpeed);
            anim.SetFloat("Velocity", temp.magnitude);
        }
        else
        {
            if (digging)
            {
                transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(triggerObject.transform.forward * -1), transform.rotation, turnSpeed);
            }
            anim.SetFloat("Velocity", temp.magnitude);
        }
        GetComponent<Rigidbody>().MovePosition(transform.position + movement * Time.deltaTime);

    }
    public void PlayWalk()
    {
        if (walk != null)
        {
            audioSource.clip = walk;
            audioSource.Play();
        }
    }

}