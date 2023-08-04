using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_light2 : MonoBehaviour
{
      public GameObject Player_Death;
      Transform pos2;
      void Start()
      {
          pos2 = GameObject.FindGameObjectWithTag("FinalBoss2").GetComponent<WJ_BossPart2>().EYE2;
          Destroy(gameObject, 1.5f);
      }
      
      // Update is called once per frame
      void Update()
      {
          transform.position = pos2.position;
      }
      
      private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.tag == "Player")
          {
              Instantiate(Player_Death, transform.position, Quaternion.identity);
              Destroy(collision.gameObject);
          }
      }
  
}
