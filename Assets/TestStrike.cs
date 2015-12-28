using UnityEngine;
using System.Collections;

public class TestStrike : MonoBehaviour {

    private Rigidbody bola_;
    //private Collider test;
	public GameObject target;
	public GameObject target2;
	public GameObject target3;
	private GameObject GoalCollider;
	private GameObject GK_Collider;
    //private Collider gkCol_;
    private Vector3 target1_pos;
    private Vector3 target2_pos;
    private Vector3 target3_pos;
    private Vector3 initPos;
    public float shootStr;
    private static bool canKick;

    private static int goals;
    private static int defs;

    private GameObject testCol;

    public static bool colisao_ = false;

	// Use this for initialization
	void Start ()
    {
        //falta movimento continuo da bola
        canKick = true;
        goals = 0;
        defs = 0;
        bola_ = GetComponent<Rigidbody>();
        target1_pos = target.transform.position;
		target2_pos = target2.transform.position;
        target3_pos = target3.transform.position;
        initPos = new Vector3(-32f, 0.2f, 4.6f);
    }

	void OnColliderEnter(Collider GoalCollider)
	{
        Debug.Log("colisao com baliza!");
        goals += 1;
        defs = defs;
        transform.position = initPos;
    }

	void OnTriggerEnter(Collider GK_Collider)
	{
        Debug.Log("Colisao com GK!");
		defs += 1;
		goals = goals;
        transform.position = initPos;
    }
    // Update is called once per frame
    void Update ()
    {
        // bola_.AddForce(new Vector3(0.0f, 0.0f, 0.0f));
        if (canKick && Input.GetKey(KeyCode.A))
        {
            //yield return new WaitForSeconds(5.0f);
            transform.position = Vector3.MoveTowards(transform.position, target1_pos, Time.deltaTime * shootStr);
            transform.LookAt(target1_pos);
        }

        if (canKick && Input.GetKey(KeyCode.S))
        {
            //yield return new WaitForSeconds(5.0f);
            transform.position = Vector3.MoveTowards(transform.position, target2_pos, Time.deltaTime * shootStr);
            transform.LookAt(target2_pos);
        }  

        if (canKick && Input.GetKey(KeyCode.D))
        {
            //yield return new WaitForSeconds(5.0f);
            transform.position = Vector3.MoveTowards(transform.position, target3_pos, Time.deltaTime * shootStr);
            transform.LookAt(target3_pos);
        }

    }
    public class Timer
    {
        int startTime;
        int stopTime;
        bool isRunning = false;
        public Timer(){}
        public int getTime()
        {
            if(isRunning)
            {
                return (int)Time.time-startTime;
            }
            else
            {
                return stopTime-startTime;
            }
        }
        public void startTimer()
        {
            startTime = (int)Time.time;
            isRunning = true;
            Debug.Log("Timer Start");
        }
        public void stopTimer()
        {
            if(isRunning)
            {
                stopTime = (int)Time.time;
                isRunning = false;
                Debug.Log("Stopped Timer at "+getTime()+" seconds.");
            }
        }
    }
}