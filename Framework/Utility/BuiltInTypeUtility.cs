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
		/// <summary>
		/// 判断字典不为null，key不为null，且字典中有key
		/// </summary>
		/// <param name="dictionary">被判断的字典</param>
		/// <param name="key">查找字典的key</param>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <returns></returns>
		public static bool CanUseDictionaryWithKey<TKey,TValue>(this IDictionary<TKey,TValue> dictionary,TKey key)
		{
			if (dictionary != null && key != null && dictionary.ContainsKey(key))
				return true;
			return false;
		}
}
