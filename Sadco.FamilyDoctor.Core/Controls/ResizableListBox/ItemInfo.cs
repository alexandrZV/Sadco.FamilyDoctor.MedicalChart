// ////////////////////////////////////////////////////////////////////////////
//
//  $RCSfile: ItemInfo.cs,v $
//
//  $Revision: 1.1 $
//
//  Last change:
//    $Author: Robert $
//    $Date: 2004/07/28 10:42:08 $
//
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
//
//  Original Code from Christian Tratz (via www.codeproject.com).
//  Changed by R. Lelieveld, SimVA GmbH.
//
// ////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;

namespace Sadco.FamilyDoctor.Core.Controls.ResizableListBox
{
	/// <summary>
	/// This class provides more informations about the items in the listbox.
	/// </summary>
	public class ItemInfo
	{
		/// <summary>
		/// Height of the item.
		/// </summary>
		private int _iHeight;

        /// <summary>
		/// Top of the item.
		/// </summary>
		private int _Top;

        /// <summary>
        /// Height of the item.
        /// </summary>
        public int Top {
            get { return _Top; }
            set {
                _Top = value;
            }
        }

        /// <summary>
        /// Height of the item.
        /// </summary>
        public int Height
		{
			get { return _iHeight;}
			set
			{
				_iHeight = value;
				_bHeightValid = true;
			}
		}


		/// <summary>
		/// Is the height valid?
		/// </summary>
		private bool _bHeightValid;

		/// <summary>
		/// Is the height valid?
		/// </summary>
		public bool HeightValid
		{
			get { return _bHeightValid;}
			set { _bHeightValid = value;}
		}


		/// <summary>
		/// Message from user.
		/// </summary>
		private object _object;

		/// <summary>
		/// Constructor.
		/// </summary>
		public ItemInfo(object obj)
		{
            _Top = 0;
            _iHeight = 0;
            _bHeightValid = false;
            _object = obj;
		}


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="Height"></param>
		/// <param name="?"></param>
		public ItemInfo(int Top, int Height, bool HeightValid, object obj)
		{
            _Top = Top;
            _iHeight = Height;
			_bHeightValid = HeightValid;
            _object = obj;
		}
	}
}
