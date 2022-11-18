using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestsMove : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  private void OnCollisionEnter(Collision collision) {
    
    if (collision.gameObject.tag == "Player") {
      Vector3 fuerzas = (gameObject.transform.position -GameObject.FindWithTag("Player").transform.position) * 100;
      gameObject.GetComponent<Rigidbody>().AddForce(fuerzas);
    }
  }
}
