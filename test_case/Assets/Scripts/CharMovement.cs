using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharMovement : MonoBehaviour
{
    Vector3 move;
    Animator charAnim;

    public float velocity = 5, sideVelocity = 15;

    public GameObject finalScreen;
    public Text coinsCounter;
    public GameObject particlePrefab;

    bool end;

    public int coins = 0;

    void Start()
    {
        finalScreen.SetActive(false);
        end = false;

        charAnim = GetComponent<Animator>();

        move = new Vector3(1, 0, 1);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !end)
        {
            float halfSW = Screen.width * 0.5f;
            float delta = Input.mousePosition.x - halfSW;

            Vector3 pos = transform.position;
            pos.x = sideVelocity * (delta / halfSW);

            move.x = pos.x;
            move.z = velocity;
            move *= Time.deltaTime;

            charAnim.SetBool("isRunning", true);
            this.transform.position += move;
        }
        else
            charAnim.SetBool("isRunning", false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            StartCoroutine(NextLevelWaiter());
        }

        if (col.gameObject.tag == "Coin")
        {
            coins++;

            GameObject prt = (GameObject)Instantiate(particlePrefab, transform.position, particlePrefab.transform.rotation);

            Destroy(prt, prt.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
            Destroy(col.gameObject);

            coinsCounter.text = coins.ToString();
        }
    }

    IEnumerator NextLevelWaiter ()
    {
        yield return new WaitForSeconds(1.5f);
        
        charAnim.SetBool("isRunning", false);
        end = true;
        finalScreen.SetActive(true);
    }
}
