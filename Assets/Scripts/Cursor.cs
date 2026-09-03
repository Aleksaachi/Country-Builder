using UnityEngine;

public class Cursor : MonoBehaviour
{
    public static Cursor instance;
    Vector3 screenCenter;
    void Awake()
    {
        instance = this;
        SetActive(false);
        screenCenter = new Vector3(Screen.width/2, Screen.height/2, 0);
    }
    void Update()
    {
        Move();
    }
    public static void SetActive(bool active)
    {
        instance.gameObject.SetActive(active);
        instance.Move();
    }
    void Move()
    {
        transform.localPosition = Input.mousePosition - screenCenter;
    }
}
