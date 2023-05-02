using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smoothTime = 2f;
    public string doorTag = "Door";
    public KeyCode openDoorKey = KeyCode.E;

    private Transform doorTransform;
    private Quaternion doorOpenQuaternion;
    private Quaternion doorCloseQuaternion;
    private bool doorOpen = false;

    void Start()
    {
        doorTransform = null;
        doorOpenQuaternion = Quaternion.Euler(0f, doorOpenAngle, 0f);
        doorCloseQuaternion = Quaternion.Euler(0f, doorCloseAngle, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(openDoorKey) && doorTransform != null)
        {
            doorOpen = !doorOpen;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(doorTag))
        {
            Debug.Log("XYN");
            doorTransform = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(doorTag))
        {
            doorTransform = null;
        }
    }

    void FixedUpdate()
    {
        if (doorTransform != null)
        {
            Quaternion targetRotation = doorOpen ? doorOpenQuaternion : doorCloseQuaternion;
            doorTransform.localRotation = Quaternion.Slerp(doorTransform.localRotation, targetRotation, smoothTime * Time.deltaTime);
        }
    }
}