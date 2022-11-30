using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{
    // Animator for the player
    [SerializeField] private Animator animator;
    // Array of buttons to enable/disable
    [SerializeField] private Button[] buttons;
    // Whether the player is moving
    private bool isAnimating = false;
    // Speed of rotation
    [SerializeField] private float rotationSpeed = 0.5f;

    // Rotate the player for best view
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, rotationSpeed, 0);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -1*rotationSpeed, 0);
        }
    }

    // Animate the animator with the named clip
    public void Animate(string clipName)
    {
        // If not animating, start animating
        if (!isAnimating)
        {
            isAnimating = true;
            animator.Play(clipName);

            // Disable the buttons
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }

            // Wait for the animation to finish
            StartCoroutine(WaitForAnimation());
        }
    }

    // Coroutine to wait for the animation to finish
    public IEnumerator WaitForAnimation()
    {
        // Wait for the animation to finish
        yield return new WaitForSeconds(2.5f);

        // Stop animating
        isAnimating = false;
        
        // Enable the buttons
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
}
