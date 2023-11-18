// etar125
using System;
using System.Drawing;
using System.ComponentModel;
using SimplePhysics;
using System.Threading;

namespace SimplePhysics
{
	public class Object
	{
		public Point Location;
		public Size Size;
		public int Weight;
		public Physics Main;
		public string Name;
		BackgroundWorker bw = new BackgroundWorker();
		
		public Object() { }
		
		public Object(Point loc, Size siz, int wei, Physics mai, string nam)
		{
			Location = loc;
			Size = siz;
			Weight = wei;
			Main = mai;
			Name = nam;
		}
		
		public void Gravity()
		{
			
			Location.Y += 1;
			if(InterectsWithAny()) {
				Location.Y -= 1; Console.WriteLine("Minus");
			}
		}
		
		public void Start()
		{
			if(Weight != 0) {
				bw.DoWork += (object sender, DoWorkEventArgs e) =>
				{
					while(true)
					{
						Gravity();
						Thread.Sleep(10000 / Weight);
					}
				};
				bw.RunWorkerAsync();
			}
		}
		
		public void Stop() {
			bw.CancelAsync();
		}
		
		public bool InterectsWith(Object obj) {
			return new Rectangle(Location, Size).IntersectsWith(new Rectangle(obj.Location, obj.Size));
		}
		
		public bool InterectsWithAny() {
			foreach(Object obj in Main.Scene) {
				if(obj != (Object)this){
					if(new Rectangle(Location, Size).IntersectsWith(new Rectangle(obj.Location, obj.Size)))
						return true;
				}
			}
			return false;
		}
		
		public Object InterectsWithWhat() {
			foreach(Object obj in Main.Scene) {
				if(new Rectangle(Location, Size).IntersectsWith(new Rectangle(obj.Location, obj.Size)))
					return obj;
			}
			return null;
		}
	}
}
