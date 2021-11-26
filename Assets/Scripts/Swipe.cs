using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool canSwipe = false;
    public bool MoveByTouch;
    private Vector3 _mouseStartPos, PlayerStartPos;
    [Range(0f, 100f)] public float maxAcceleration;
    private Vector3 move;
    Transform target;

    //private GameObject hittingObject;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0f, 1f) * Time.deltaTime*5;

        if (canSwipe)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 30))
                {
                    if (hit.transform.gameObject)
                    {
                        Plane plane = new Plane(Vector3.up, 0f);
                        float Distance;

                        if (plane.Raycast(ray, out Distance))
                        {
                            _mouseStartPos = ray.GetPoint(Distance);
                            PlayerStartPos = transform.position;
                        }

                        MoveByTouch = true;
                        Debug.Log("Cube");
                    }

                }



                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);



            }
            else if (Input.GetMouseButtonUp(0))
            {
                MoveByTouch = false;
            }

            if (MoveByTouch)
            {
                Plane plane = new Plane(Vector3.up, 0f);
                float Distance;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                if (plane.Raycast(ray, out Distance))
                {
                    var newray = ray.GetPoint(Distance);
                    move = newray - _mouseStartPos;
                    var controller = PlayerStartPos + move;

                    //controller.x = Mathf.Clamp(controller.x, -3.43f, 5.41f);

                    var TargetNewPos = target.position;

                    TargetNewPos.x = Mathf.MoveTowards(TargetNewPos.x, controller.x, 80f * Time.deltaTime);
                    //TargetNewPos.z = Mathf.MoveTowards(TargetNewPos.z, 1000f, 10f * Time.deltaTime);

                    target.position = TargetNewPos;

                    var PlayerNewPos = transform.position;

                    PlayerNewPos.x = Mathf.MoveTowards(PlayerNewPos.x, controller.x, 15 * Time.deltaTime);
                    //PlayerNewPos.z = Mathf.MoveTowards(PlayerNewPos.z, 1000f, 10f * Time.deltaTime);
                    transform.position = PlayerNewPos;
                    //hittingObject.transform.position = PlayerNewPos;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
