using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
  private float velocity = 2;
  private bool canTP = true;
  private bool isDead = false;
  public delegate void mensaje();
  public event mensaje Aumentar;
  public float life = 100;
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    float horSpeed = horizontal * velocity;
    float verSpeed = vertical * velocity;
    gameObject.transform.Translate(horSpeed, 0, verSpeed);

    if (Input.GetKey("t") && canTP) {
      canTP = false;
      int posX = Random.Range(-5, 5);
      int posZ = Random.Range(-5, 5);
      Vector3 newPos = new Vector3(posX, 1, posZ);
      gameObject.transform.position = newPos;
    } 
    if (!isDead){
      if (life > 0){
        GameObject[] spider = GameObject.FindGameObjectsWithTag("Spider");
        for (int i = 0; i < spider.Length; i++) {
          float distancia = Vector3.Distance(spider[i].transform.position, gameObject.transform.position);
          if (distancia < 3f) {
            life -= 0.1f;
            Debug.Log("Vida restante:" + life);
          } 
        }
      } else {
        isDead = true;
        Debug.Log("El Player ha muerto");
      }
    }
    
  }

  private void OnCollisionEnter(Collision colission) {
    if (colission.gameObject.tag == "Plane") {
      canTP = true;
    }
    if (colission.gameObject.tag == "Cofre") {
      Aumentar();
    }
  }
}
