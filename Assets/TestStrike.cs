using UnityEngine;
using System.Collections;

public class TestStrike : MonoBehaviour {

    private Rigidbody bola_;
    private Collider test;
    public GameObject target;
    private Collider target_Col;
    private Collision col_;

    public static bool colisao = false;

	// Use this for initialization
	void Start ()
    {
        //falta movimento continuo da bola
        bola_ = GetComponent<Rigidbody>();
        target_Col = GetComponent<Collider>();
    }

    void OnCollisionExit(GameObject col)
    {
        if (col.tag == "Field")
        {
            colisao = false;
        }
    }

    void OnCollisionEnter(GameObject col)
    {
        if (col.tag == "GoalCollider")
        {
            colisao = true;
        } 
    }

    // Update is called once per frame
    void Update ()
    {
        if (!colisao && Input.GetKey(KeyCode.A))
        {
            bola_.MovePosition(transform.position + transform.forward * (-20.0f * Time.deltaTime));
        }
        else
        {
            bola_.MovePosition(transform.position + transform.forward * (0.0f * Time.deltaTime));
        }
    }
}