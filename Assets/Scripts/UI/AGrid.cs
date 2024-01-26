using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public abstract class AGrid : MonoBehaviour
	{
		[Tooltip("Rect Transform контента сетки.")] [SerializeField]
		protected RectTransform content;

		[Tooltip("Элемент сетки.")] [SerializeField]
		protected GameObject elementGrid;
		
		protected List<GameObject> GridElements = new ();
		
		public abstract void Fill();
		
		protected GameObject InstantiateElement()
		{
			var elem = Instantiate(elementGrid, content.transform);
			
			elem.transform.localPosition = Vector3.zero;
			elem.transform.localRotation = Quaternion.identity;
			elem.transform.localScale = Vector3.one;
			
			GridElements.Add(elem);
			
			return elem;
		}
		
		protected GameObject InstantiateElement(GameObject elem)
		{
			var newElem = Instantiate(elem, content.transform);
			
			newElem.transform.localPosition = Vector3.zero;
			newElem.transform.localRotation = Quaternion.identity;
			newElem.transform.localScale = Vector3.one;
			
			GridElements.Add(newElem);
			
			return newElem;
		}
		
		protected void Clear()
		{
			foreach (Transform child in content.transform)
				Destroy(child.gameObject);
			
			GridElements?.Clear();
		}
	}
}