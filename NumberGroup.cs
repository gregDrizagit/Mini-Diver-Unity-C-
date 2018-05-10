using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[ExecuteInEditMode]
public class NumberGroup : MonoBehaviour
{
	public int m_minDigits = 10;
	public GameObject m_numberPrefab;
	public int m_number;
	public int number
	{
		get
		{
			return m_number;
		}
		set
		{
			if(m_number != value)
			{
				m_number = value;
				UpdateNumberizers();
			}
		}
	}

	[ContextMenu("Set Numbers")]
	public void UpdateNumberizers()
	{
		foreach(var currTrans in GetComponentsInChildren<Transform>(true))
		{
			if(currTrans != transform)
			{
	#if UNITY_EDITOR
				if(!UnityEditor.EditorApplication.isPlaying)
					DestroyImmediate(currTrans.gameObject);
				else
					Destroy(currTrans.gameObject);
	#else
			
	#endif
			}
		}

		List<GameObject> numberSprites = new List<GameObject>();
		if(m_number == 0)
		{
			GameObject newNumber = Instantiate(m_numberPrefab);
			newNumber.GetComponent<Numberizer>().number = 0;
			numberSprites.Add(newNumber);
		}
		else
		{
			int currNumber = m_number;
			while(currNumber > 0)
			{
				int currDigit = currNumber % 10;
				GameObject newNumber = Instantiate(m_numberPrefab);
				numberSprites.Add(newNumber);
				newNumber.GetComponent<Numberizer>().number = currDigit;
				currNumber /= 10;
			}
		}

		for(int i = numberSprites.Count; i < m_minDigits; ++i)
		{
			GameObject emptyDigit = Instantiate(m_numberPrefab);
			numberSprites.Add(emptyDigit);
			emptyDigit.GetComponent<Numberizer>().number = 0;
			emptyDigit.GetComponent<Image>().color = Color.clear;
		}

		numberSprites.Reverse();
		foreach(var numberizer in numberSprites)
		{
			numberizer.transform.SetParent(transform, true);
		}

	}

	public int[] GetIntArray(int num)
	{
		List<int> listOfInts = new List<int>();
		while(num > 0)
		{
			listOfInts.Add(num % 10);
			num = num / 10;
		}
		listOfInts.Reverse();
		return listOfInts.ToArray();
	}
}
