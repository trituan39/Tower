using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceUI : MonoBehaviour
{
	public GameObject ui;

    private TowerPlace target;

    public void SetTarget(TowerPlace _target)
	{
		target = _target;

		target.GetBuildPosition();

		ui.SetActive(true);
	}
	public void Hide()
	{
		ui.SetActive(false);
	}
}
