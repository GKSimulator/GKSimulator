using UnityEngine;
using System.Collections;

public class TestStrike : MonoBehaviour {

    private Rigidbody bola_;
    private Collider test;
    public GameObject target;
    private Collider target_Col;
    private Collision colisao;
	// Use this for initialization
	void Start ()
    {
        //falta movimento continuo da bola
        bola_ = GetComponent<Rigidbody>();
        //colisao = 
        //target_Col = target.GetComponent<Collider>();
        test = bola_.GetComponent<Collider>();
    }

    void OnTriggerEnter()
    {
      bola_.MovePosition(Vector3.zero);
    }

    void OnTriggerExit()
    {
        bola_.MovePosition(transform.position + transform.forward * (20.0f * Time.deltaTime));
    }

	// Update is called once per frame
	void Update ()
    {
        while(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Space))
        {
            OnTriggerExit();
        }
    }
}