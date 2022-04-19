using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class play : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    private int Trash;
    private int BinCan;
    public Text CountText;
    public Text WinText;
    public Text BinCanHitText;
    public Text TrashText;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count = 0;
        Trash = 0;
        BinCan = 0;
        SetCountText();
        WinText.text="Let's Clean the city";
    }
    void FixedUpdate ()
    {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");
        Vector3 movement= new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement* speed);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle hit"))
        {
            other.gameObject.SetActive(true);
            BinCan = BinCan + 1;
            Trash = 0;
            Debug.Log(BinCan.ToString());
            SetCountText();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pick up"))
        {
            if(Trash<5)
            {            
                other.gameObject.SetActive( false);
                // Destroy(other.gameObject);
                count = count + 1;
                Trash = Trash + 1;
                Debug.Log(count.ToString());
                SetCountText();
            }
        }
        if (other.gameObject.CompareTag("Start"))
        {
            WinText.text="";
        }
        
    }
    void SetCountText()
    {
        BinCanHitText.text="BinCan Hit: " + BinCan.ToString();
        TrashText.text="Trash: " + Trash.ToString();
        CountText.text="Count: " + count.ToString();
        if(count==20)
        {
            if(Trash==0){
                WinText.text="City Cleaned";
            }            
        }
        else
        {
            WinText.text="";
        }
    }
}