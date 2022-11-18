using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggsAumenter : MonoBehaviour
{
  public characterController notificar;
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    notificar.Aumentar += increase;
  }

  void increase() {
    
    gameObject.transform.localScale += new Vector3(0.0001f, 0.0001f, 0.0001f);
  }
}
