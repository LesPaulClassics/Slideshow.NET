using System;
using System.Collections;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ImageItemCollection.
	/// </summary>
	public class ImageItemList : System.Collections.IEnumerable, System.Collections.IList
	{

		private ArrayList _imageItemCollection;

		public ImageItemList()
		{

			_imageItemCollection = new ArrayList();

		}

		public ImageItemList(int capacity)
		{

			_imageItemCollection = new ArrayList(capacity);

		}

		public int AddImageItem(ref ImageItem imageItem)
		{
            if (FindImageItem(imageItem.PathAndFileName) == -1)
            {
                _imageItemCollection.Add(imageItem);

                imageItem.Index = _imageItemCollection.Count - 1;

                return imageItem.Index;
            }
            else
                return -1;
		
		}

        public int FindImageItem(string pathAndFileName)
        {
            for (int i = 0; i < _imageItemCollection.Count; i++)
                if (((ImageItem)_imageItemCollection[i]).PathAndFileName.ToLower() == pathAndFileName.ToLower())
                    return i;
            return -1;
        }

        public void RemoveImageItem(ref ImageItem imageItem)
		{

			_imageItemCollection.Remove(imageItem);

            for (int i = imageItem.Index; i < _imageItemCollection.Count; i++)
            {
                ((ImageItem)_imageItemCollection[i]).Index--;
            }

            imageItem.Index = -1;

		}

		public void RemoveImageItem(int index)
		{

			_imageItemCollection.RemoveAt(index);
            for (int i = index; i < _imageItemCollection.Count; i++)
            {
                ((ImageItem)_imageItemCollection[i]).Index--;
            }

		}

        public ImageItem GetImageItem(int index)
		{

			return (ImageItem) _imageItemCollection[index];
		
		}

		public int Count
		{
			get
			{
				return _imageItemCollection.Count;
			}

		}

        public ImageItemList Copy()
        {
            ImageItemList newList = new ImageItemList(Count);

            newList._imageItemCollection = new ArrayList(_imageItemCollection);

            return newList;
        }

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			
			return _imageItemCollection.GetEnumerator();
		}

		#endregion

        #region IList Members

        public int Add(object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Contains(object value)
        {
            return _imageItemCollection.Contains(value);
        }

        public int IndexOf(object value)
        {
            return _imageItemCollection.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Remove(object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveAt(int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object this[int index]
        {
            get
            {
                return _imageItemCollection[index];
            }
            set
            {
                _imageItemCollection[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsSynchronized
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object SyncRoot
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
