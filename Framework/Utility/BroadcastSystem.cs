using System;
using System.Collections.Generic;

namespace GameFramework.Utility
{
	public struct BroadcastInfo
	{
		private object _from;
		private object _info;
	}


	public delegate void CallBack(BroadcastInfo info);
	///<summary>
	/// 泛型广播系统,广播系统应该被用于具有唯一性的地方
	///</summary>
	public class BroadcastSystem<T> where T:Enum
	{
		private readonly Dictionary<T, CallBack> _eventTable=new Dictionary<T, CallBack>();
		public void AddListener(T key, CallBack callBack)
		{
			if (callBack == null)
			{
				throw new Exception($"{key}不能注册空回调");
			}

			CallBack d;
			if(_eventTable.TryGetValue(key,out d))
			{
				d += callBack;
				_eventTable[key] = d;
			}
			else
			{
				_eventTable[key] = callBack;
			}
		}

		public void RemoveListener(T key, CallBack callBack)
		{
			
		}

		public void SendMessage(T key, object info)
		{
			
		}
	}
}
