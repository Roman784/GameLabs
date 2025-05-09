using UnityEngine;

public class Target : MonoBehaviour
{
    private int _score;
    private float _moveSpeed;
    private Vector3 _positionToMove;

    [SerializeField] private CrashingTarget _crashingTarget;
    [SerializeField] private AudioClip _crashingSound;

    public void Init(int score, float moveSpeed, Vector3 positionToMove)
    {
        _score = score;
        _moveSpeed = moveSpeed;
        _positionToMove = positionToMove;
    }

    private void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, _positionToMove) < 0.2f)
            Destroy(gameObject);
    }

    public void TakeHit()
    {
        ScoreCounter.Instance.Increase(_score);

        Destroy();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positionToMove, _moveSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        Instantiate(_crashingTarget, transform.position, transform.rotation);
        SoundPlayer.Instance.Play(_crashingSound, transform.position);

        Destroy(gameObject);
    }
}
