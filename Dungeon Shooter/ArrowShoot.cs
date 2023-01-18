using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f;
    public float shootDelay = 0.25f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    bool inAttack = false;
    GameObject bowObj;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire3")))
        {
            Attack();
        }

        float bowZ = -1;
        PlayerController plmv = GetComponent<PlayerController>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            bowZ = 1;
        }

        bowObj.transform.rotation = Quaternion.Euler(0, 0, plmv.angleZ);
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }

    public void Attack()
    {
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows -= 1;
            inAttack = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;
            Rigidbody2D body = arrowObj.GetComponent<Rigidbody2D>();
            body.AddForce(v, ForceMode2D.Impulse);
            Invoke("StopAttack", shootDelay);

            SoundManager.soundManager.SEPlay(SEType.Shoot);
        }
    }

    public void StopAttack()
    {
        inAttack = false;
    }
}
