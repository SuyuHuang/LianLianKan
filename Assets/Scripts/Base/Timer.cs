using System.Collections;
using System.Collections.Generic;
using Scripts;
using Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

public class Timer : SingleTemplate<Timer>
{

	private Slider _slider;


	public float SliderValue
	{
		get
		{
			if (!_slider)
			{
				_slider = GetComponent<Slider>();
			}
			return _slider.value;
		}
		set { _slider.value = value; }
	}



	// Use this for initialization
	void Start()
	{
		_slider = GetComponent<Slider>();
	}

	private void Update()
	{
		if (BattleManager.level != 0)
		{
			if ((GameManager.IsPause == false) && (GameManager.IsOver == false))
			{
				_slider.value -= 0.0001f;

			}

			if (_slider.value <= 0) GameManager.IsOver = true;
		}
        else
        {
			if ((GameManager.IsPause == false) && (GameManager.IsOver == false))
			{
				_slider.value -= 0.0001f;

			}
		}
	}
}
