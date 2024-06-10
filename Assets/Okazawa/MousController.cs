using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MousController : MonoBehaviour
{
    [SerializeField] Color[] m_animation = default;
    BoxCollider2D mousCol;
    SpriteRenderer m_sprite = default;
    int m_animationindex;
    Rigidbody2D m_rb;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "takinoko")
        {
            collision.transform.parent = gameObject.transform;
            collision.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        mousCol = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        this.transform.position = mousePosition;


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Ç‡ÇÃÇÇ¬Ç©Çﬁèàóù");
            mousCol.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ç‡ÇÃÇÇÕÇ»Ç∑èàóù");
            mousCol.enabled = false;
            gameObject.transform.DetachChildren();
        }
    }
}
