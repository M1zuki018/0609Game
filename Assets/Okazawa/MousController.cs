using UnityEditor.Animations;
using UnityEngine;

public class MousController : MonoBehaviour
{
    Collider2D mousCol;
    public GameObject takinoko;
    Collider2D takinoCol;
    Transform chil;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        mousCol = GetComponent<Collider2D>();
        chil = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ものをつかむ処理");
            mousCol.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ものをはなす処理");
            mousCol.enabled = false;
            if (takinoCol != null)
            {
                takinoCol.enabled = true;
            }
            gameObject.transform.DetachChildren();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "takinoko" && chil.transform.childCount == 0) 
        {
            takinoCol = collision.GetComponent<Collider2D>();
            collision.transform.parent = gameObject.transform;
            collision.enabled = false;
        }
    }
}
