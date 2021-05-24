using UnityEngine;

public class DinoAnim : MonoBehaviour
{
    [SerializeField] private DinoMover dinoMover;
    [SerializeField] private Animator anim;
    private float animSpeed = 1f;
    private void Update()
    {
        if (transform.position.y >= dinoMover.PosY)
            anim.speed = 0;
        else anim.speed = animSpeed;
    }
}
