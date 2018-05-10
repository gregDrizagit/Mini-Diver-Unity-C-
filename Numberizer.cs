using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]
[ExecuteInEditMode]
public class Numberizer : MonoBehaviour
{
	[Range(0, 9)]
	public int m_number;

	public Sprite[] m_numberSprites;
	public int number
	{
		set
		{
			m_number = Mathf.Clamp(value, 0, 9);
			SetNumberSprite();
		}
	}

	[ContextMenu("Set Number")]
	private void SetNumberSprite()
	{
		image.sprite = m_numberSprites[m_number];
	}

	private Image m_image;
	public Image image
	{
		get
		{
			if(m_image == null)
			{
				m_image = GetComponent<Image>();
				if(m_image == null)
					m_image = gameObject.AddComponent<Image>();
			}
			return m_image;
		}
	}

	public void Update()
	{

	}
}
