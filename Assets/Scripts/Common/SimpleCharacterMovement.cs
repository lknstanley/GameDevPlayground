using UnityEngine;

namespace Common
{
    [ RequireComponent( typeof( CharacterController) ) ]
    public class SimpleCharacterMovement : MonoBehaviour
    {
        [ Header( "Movement Config" ) ]

        // Movement speed config
        [ SerializeField ]
        private float movementSpeed = 10.0f;

        [ Header( "Mouse Look Config" ) ]
        
        // Mouse look speed
        [ SerializeField ]
        private float mouseSensitive = 10f;

        private CharacterController _charaController;

        private void Awake()
        {
            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            
            // Get character controller from self
            _charaController = GetComponent< CharacterController >();
        }

        private void Update()
        {
            // Update mouse look rotation
            Vector3 mouseRotate = new Vector3( 
                -Input.GetAxis( "Mouse Y" ), 
                Input.GetAxis( "Mouse X" ), 
                0 ) * mouseSensitive * Time.deltaTime;
            Vector3 currentAngles = transform.eulerAngles;
            currentAngles += mouseRotate;
            transform.eulerAngles = currentAngles;
            
            // Update input for movement
            Vector3 movement = new Vector3( Input.GetAxis( "Horizontal" ), 0, Input.GetAxis( "Vertical" ) );
            Vector3 motion =
                ( Vector3.Scale( transform.right, movement ) + Vector3.Scale( transform.forward, movement ) ) *
                movementSpeed * Time.deltaTime;
            _charaController.Move( motion );
        }
    }
}
