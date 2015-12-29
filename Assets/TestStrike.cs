using UnityEngine;
using System.Collections;

public class TestStrike : MonoBehaviour {

    public Rigidbody bola_;
	public Transform bolaPos;
	public float forcaRemate = 100f;
	public float velRemate = 100f;


    //private Collider test;
	public GameObject target;
	public GameObject target2;
	public GameObject target3;
	private GameObject GoalCollider;
	private GameObject GK_Collider;

    private Vector3 target1_pos;
    private Vector3 target2_pos;
    private Vector3 target3_pos;
    private Vector3 initPos;
	private Quaternion rotInit;

    public float shootStr;
    private static bool canKick;

    private static int goals;
    private static int defs;

    private GameObject testCol;

    public static bool colisao_ = false;

	// Use this for initialization
	void Start ()
	{
        canKick = true;
        goals = 0;
        defs = 0;
		rotInit = bola_.rotation;
		target1_pos = target.transform.position;
		target2_pos = target2.transform.position;
		target3_pos = target3.transform.position;
		initPos = new Vector3(-32f, 0.2f, 4.6f);
        bola_ = GetComponent<Rigidbody>();
		bola_.isKinematic = false;
		bola_.velocity = Vector3.zero;
		bola_.angularVelocity = Vector3.zero;
	}

	void OnTriggerEnter(Collider collider)
	{
        if (collider.gameObject.name == "GK_Collider") {
			Debug.Log ("Colisao com GR!");
			defs += 1;
			goals = goals;
			canKick = false;
			bola_.isKinematic = true;
			bola_.velocity = Vector3.zero;
			bola_.angularVelocity = Vector3.zero;
			transform.position = initPos;
			transform.rotation = rotInit;
			bola_.isKinematic = false;
			canKick = true;
		} else 
		{
			canKick = true;
			bola_.isKinematic = false;
		}
        if (collider.gameObject.name == "GoalCollider")
        {
            Debug.Log("colisao com baliza!");
            goals += 1;
            defs = defs;
			canKick = false;
			bola_.isKinematic = true;
			bola_.velocity = Vector3.zero;
			bola_.angularVelocity = Vector3.zero;
			transform.position = initPos;
			transform.rotation = rotInit;
			bola_.isKinematic = false;
			canKick = true;
		} else 
		{ 
			bola_.isKinematic = true;
			bola_.velocity = Vector3.zero;
			bola_.angularVelocity = Vector3.zero;
			transform.position = initPos;
			transform.rotation = rotInit;
			bola_.isKinematic = false;
			canKick = true;
		}
    }

    // Update is called once per frame
    void Update ()
    {
        if (canKick && Input.GetKeyUp(KeyCode.A))
        {
            //yield return new WaitForSeconds(5.0f);
			bola_.isKinematic = false;
			bolaPos.LookAt(target1_pos);
			bola_.AddForce(bola_.transform.forward * forcaRemate);
        }

		if (canKick && Input.GetKeyUp(KeyCode.S))
        {
            //yield return new WaitForSeconds(5.0f);
			bola_.isKinematic = false;
			bolaPos.LookAt(target2_pos);
			bola_.AddForce(bola_.transform.forward * forcaRemate);
        }  

		if (canKick && Input.GetKeyUp(KeyCode.D))
        {
            //yield return new WaitForSeconds(5.0f);
			bola_.isKinematic = false;
			bolaPos.LookAt(target3_pos);
			bola_.AddForce(bola_.transform.forward * forcaRemate);
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