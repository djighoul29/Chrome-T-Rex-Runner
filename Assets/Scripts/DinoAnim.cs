using UnityEngine;

public class DinoAnim : MonoBehaviour
{
    [SerializeField] 
    private DinoMover _dinoMover;
    [SerializeField] 
    private Animator _anim;
    private float animSpeed = 1f;
    public float AnimSpeed { get { return animSpeed; } }
    void Update()
    {
        if (transform.position.y >= _dinoMover.PosY)
            _anim.speed = 0;
        else _anim.speed = animSpeed;
    }
}
