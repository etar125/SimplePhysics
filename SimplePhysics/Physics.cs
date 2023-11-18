// etar125
using System;
using System.Collections.Generic;
using SimplePhysics;

namespace SimplePhysics
{
	public class Physics
	{
		public List<Object> Scene = new List<Object> { };
		
		public Physics() { }
		
		public void AddObject(Object obj) {
			Scene.Add(obj);
		}
		
		public void RemoveObject(Object obj) {
			Scene.Remove(obj);
		}
		
		public void Clear() {
			Scene.Clear();
		}
		
		public void RemoveLast() {
			Scene.RemoveAt(Scene.Count - 1);
		}
		
		public void StartAll() {
			foreach(Object obj in Scene)
				obj.Start();
		}
		
		public void StopAll() {
			foreach(Object obj in Scene)
				obj.Stop();
		}
	}
}