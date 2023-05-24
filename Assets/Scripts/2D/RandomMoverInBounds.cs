using UnityEngine;

namespace Zoo
{
    public class RandomMoverInBounds : MonoBehaviour
    {
        [SerializeField]
        private int _left, _right, _top, _bottom;
        [SerializeField]
        private float _speed;

        private Vector3 _goal;

        private void Start()
        {
            PickGoal();
        }

        private void Update()
        {
            Vector3 direction = _goal - transform.localPosition;
            transform.Translate(direction.normalized * _speed * Time.deltaTime);
            if (direction.magnitude < 5)
                PickGoal();
        }

        private void PickGoal()
        {
            _goal = new Vector2(
                Random.Range(_left, _right),
                Random.Range(_bottom, _top));
        }
    }
}