using System;
using System.Collections;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ScriptFileCollection.
	/// </summary>
	public class ScriptFileCollection : CollectionBase, IList
	{
		#region Members

		#endregion

		#region Properties

		#endregion

		#region Constructors

		public ScriptFileCollection()
		{

		}

		#endregion

		#region Destructors

		#endregion

		#region Methods

		public bool Load(bool readKeywords)
		{
			try
			{
				//add this collection to the config file, load that, build this, then call this method

				for (int i = 0; i < List.Count; i++)
				{

					((ScriptFile) List[i]).Load(readKeywords);

				}

				return true;

			}
			catch (Exception ex)
			{

				System.Diagnostics.Debug.WriteLine(ex.Message);
				(new TSOP.AppLog()).LogError("failed to load script file collection", ex, "ScriptFileCollection", "Load");
				return false;
		
			}
		}

		public bool Save()
		{

			return true;
		}

		public override string ToString()
		{

			string output = "";
			foreach (ScriptFile sf in InnerList)
			{
				if (output != "")
					output += '|';
				output += sf.PathAndFileName;
			}

			return output;

		}

		public ScriptFile GetScriptByName(string scriptFileName)
		{

			foreach (ScriptFile sf in InnerList)
			{

				if (sf.PathAndFileName == scriptFileName)
					return sf;

			}

			return null;
		}

		#endregion

		#region IList Members

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public ScriptFile this[int index]
		{
			get
			{
				return (ScriptFile) List[index];
			}
			set
			{
				List[index] = value;
			}
		}

		public void Insert(int index, ScriptFile value)
		{
			List.Insert(index, value);
		}

		public void Remove(ScriptFile value)
		{
			List.Remove(value);
		}

		public bool Contains(ScriptFile value)
		{
			return List.Contains(value);
		}

		public int IndexOf(ScriptFile value)
		{
			return List.IndexOf(value);
		}

		public int Add(ScriptFile value)
		{
			return List.Add(value);
		}

		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region ICollection Members

		int System.Collections.ICollection.Count
		{
			get
			{
				return List.Count;
			}
		}

		public void CopyTo(Array array, int index)
		{
			List.CopyTo(array, index);
		}

		#endregion

	}
}
