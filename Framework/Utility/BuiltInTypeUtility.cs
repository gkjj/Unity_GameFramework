using System.Collections;

namespace GameFramework.Utility
{
	/// <summary>
	/// 内置类型工具
	/// </summary>
	public static class BuiltInTypeUtility
	{
		/// <summary>
		/// 判断列表不为null且在index索引有意义
		/// </summary>
		/// <param name="list">此list</param>
		/// <param name="index">索引</param>
		/// <returns>列表不为null且在index索引有意义</returns>
		public static bool CanUseIListWithIndex(this IList list,int index)
		{
			if (list != null && list.Count > index && list[index] != null)
				return true;
			return false;
		}

	}
}