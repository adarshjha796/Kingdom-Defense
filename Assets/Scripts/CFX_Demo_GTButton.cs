using System;
using UnityEngine;

public class CFX_Demo_GTButton : MonoBehaviour
{
	public Color NormalColor = new Color32(128, 128, 128, 128);

	public Color HoverColor = new Color32(128, 128, 128, 128);

	public string Callback;

	public GameObject Receiver;

	private Rect CollisionRect;

	private bool Over;

	private void Awake()
	{
		this.CollisionRect = base.GetComponent<GUITexture>().GetScreenRect(Camera.main);
	}

	private void Update()
	{
		if (this.CollisionRect.Contains(UnityEngine.Input.mousePosition))
		{
			base.GetComponent<GUITexture>().color = this.HoverColor;
			if (Input.GetMouseButtonDown(0))
			{
				this.OnClick();
			}
		}
		else
		{
			base.GetComponent<GUITexture>().color = this.NormalColor;
		}
	}

	private void OnClick()
	{
		this.Receiver.SendMessage(this.Callback);
	}
}
