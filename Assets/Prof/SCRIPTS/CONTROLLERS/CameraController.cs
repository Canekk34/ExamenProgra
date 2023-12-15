using UnityEngine;
using TMPro;

namespace Controles
{


    public class CameraController : MonoBehaviour
    {

        [SerializeField] private float sensitivity = 2f;
        [SerializeField] private float smoothing = 1.5f;

        private Transform gameObjectToRotateWith;

        private Vector2 velocity;
        private Vector2 frameVelocity;

        private void Start()
        {
            StartSettings();
        }

        private void Update()
        {
            RotateCameraWithMouse();
        }

        private void StartSettings()
        {
            if (TryGetComponent(out Transform t))
            {
                gameObjectToRotateWith = GetComponentInParent<MovementController>().transform;
            }
            else
            {
                gameObjectToRotateWith = this.transform;
            }
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void RotateCameraWithMouse()
        {
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); // Consigue el input del mouse
            Vector2 rawFrameVelocity = Vector2.Scale(mouseInput, Vector2.one * sensitivity); // Te da la velocidad a la que se va a mover el mouse
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing); // Smoothear la camara
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90); // Limitar la rotacion de la camara

            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            gameObjectToRotateWith.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }

    }
}