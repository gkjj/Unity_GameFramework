// -----------------------
// Description:
// -----------------------

using System;
using Object = UnityEngine.Object;

namespace GameFramework
{
	public static class ExceptionHandling
	{
		public static void CheckNullReferenceException(Object obj, string message)
		{
			if (obj == null)
			{
				throw new NullReferenceException(message);
			}
		}
	}
}