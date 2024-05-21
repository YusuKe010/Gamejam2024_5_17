using System;
using UnityEngine;

namespace name
{
	///<summary>summary</summary>
	public class pollenMove : MonoBehaviour, IPose
	{
		[SerializeField] private float _moveSpeed = 3f;

		private float _h;
		private float _v;
		private bool _isPose = false;
		private Vector3 _dir;
		private Rigidbody2D _rb;

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if (!_isPose)
			{
				Move();
			}
		}

		
		//移動
		void Move()
		{
			_h = Input.GetAxis("Horizontal");
			_v = Input.GetAxis("Vertical");

			_dir = new Vector3(_h, _v, 0).normalized * _moveSpeed;

			_rb.velocity = _dir;
		}

		public void InPose()
		{
			_isPose = true;
		}

		public void OutPose()
		{
			_isPose = false;
		}
	}
}
