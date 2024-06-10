using UnityEngine;

public class MousController : MonoBehaviour
{
    Collider2D mousCol;

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
        mousCol = GetComponent<Collider2D>();
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
