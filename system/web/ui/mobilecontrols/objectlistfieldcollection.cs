//------------------------------------------------------------------------------
// <copyright file="ObjectListFieldCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Permissions;

namespace System.Web.UI.MobileControls
{
    /*
     * Object List Field Collection class.
     *
     * Copyright (c) 2000 Microsoft Corporation
     */

    [AspNetHostingPermission(SecurityAction.LinkDemand, Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class ObjectListFieldCollection : ArrayListCollectionBase, IObjectListFieldCollection, IStateManager
    {
        private ObjectList _owner;
        private bool _marked = false;
        private bool _fieldsSetDirty = false;
        // Used for primary field collection (the one modified by the user).

        internal ObjectListFieldCollection(ObjectList owner) : base(new ArrayList())
        {
            _owner = owner;
        }

        // Used for autogenerated field collections.

        internal ObjectListFieldCollection(ObjectList owner, ArrayList fields) : base(fields)
        {
            _owner = owner;
            foreach (ObjectListField field in fields)
            {
                field.Owner = owner;
            }
        }

        public ObjectListField[] GetAll()
        {
            int n = Count;
            ObjectListField[] allFields = new ObjectListField[n];
            if (n > 0) 
            {
                Items.CopyTo(0, allFields, 0, n);
            }
            return allFields;
        }

        public void SetAll(ObjectListField[] value)
        {
            Items = new ArrayList(value);
            foreach(ObjectListField field in Items)
            {
                field.Owner = _owner;
            }
            if(_marked)
            {
                SetFieldsDirty();
            }
        }

        public ObjectListField this[int index] 
        {
            get 
            {
                return (ObjectListField)Items[index];
            }
        }

        public void Add(ObjectListField field)
        {
            AddAt(-1, field);
        }

        public void AddAt(int index, ObjectListField field)
        {
            if (index == -1)
            {
                Items.Add(field);
            }
            else
            {
                Items.Insert(index, field);
            }
            if (_marked)
            {
                if (!_fieldsSetDirty && index > -1)
                {
                    SetFieldsDirty();
                }
                else
                {
                    ((IStateManager)field).TrackViewState();
                    field.SetDirty();
                }
            }
            field.Owner = _owner;
            NotifyOwnerChange();
        }

        private void SetFieldsDirty()
        {
            foreach (ObjectListField fld in Items)
            {
                ((IStateManager)fld).TrackViewState();
                fld.SetDirty();
            }
            _fieldsSetDirty = true;
        }

        public void Clear()
        {
            Items.Clear();
            if (_marked)
            {
                // Each field will be marked dirty as it is added.
                _fieldsSetDirty = true;
            }
            NotifyOwnerChange();
        }

        public void RemoveAt(int index) 
        {
            if ((index >= 0) && (index < Count)) 
            {
                Items.RemoveAt(index);
            }
            if(_marked && !_fieldsSetDirty)
            {
                SetFieldsDirty();
            }
            NotifyOwnerChange();
        }

        public void Remove(ObjectListField field)
        {
            int index = IndexOf(field);
            if (index >= 0) 
            {
                RemoveAt(index);
            }
        }

        public int IndexOf(ObjectListField field)
        {
            if (field != null) 
            {
                return Items.IndexOf(field, 0, Count);
            }
            return -1;
        }

        public int IndexOf(String fieldIDOrName)
        {
            ArrayList fields = Items;
            int i = 0;
            foreach (ObjectListField field in fields)
            {
                String id = field.UniqueID;
                if (id != null && String.Compare(id, fieldIDOrName, true, CultureInfo.InvariantCulture) == 0)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        private void NotifyOwnerChange()
        {
            if (_owner != null)
            {
                _owner.OnFieldChanged(true);    // fieldAddedOrRemoved = true
            }
        }

        /////////////////////////////////////////////////////////////////////////
        //  STATE MANAGEMENT
        /////////////////////////////////////////////////////////////////////////

        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return _marked;
            }
        }

        void IStateManager.TrackViewState()
        {
            _marked = true;
            foreach (IStateManager field in Items)
            {
                field.TrackViewState();
            }
        }

        void IStateManager.LoadViewState(Object savedState)
        {
            if (savedState != null)
            {
                Object[] stateArray = (Object[]) savedState;
                bool allFieldsSaved = (bool) stateArray[0];
                if (allFieldsSaved) 
                {
                    // All fields are in view state.  Any fields loaded until now are invalid.
                    ClearFieldsViewState();
                }
                Object[] fieldStates = (Object[])stateArray[1];
                EnsureCount(fieldStates.Length);
                for (int i = 0; i < fieldStates.Length; i++)
                {
                    ((IStateManager)Items[i]).LoadViewState(fieldStates[i]);
                }
                if (allFieldsSaved)
                {
                    SetFieldsDirty();
                }
            }
        }

        Object IStateManager.SaveViewState()
        {
            int fieldsCount = Count;
            if (fieldsCount > 0)
            {
                Object[] fieldStates = new Object[fieldsCount];
                bool haveState = _fieldsSetDirty;
                for (int i = 0; i < fieldsCount; i++)
                {
                    fieldStates[i] = ((IStateManager)Items[i]).SaveViewState();
                    if (fieldStates[i] != null)
                    {
                        haveState = true;
                    }
                }
                if (haveState)
                {
                    return new Object[]{_fieldsSetDirty, fieldStates};
                }
            }
            return null;
        }

        private void EnsureCount(int count)
        {

            int diff = Count - count;
            if (diff > 0)
            {
                Items.RemoveRange(count, diff);
                NotifyOwnerChange();
            }
            else
            {
                // Set owner = null, to avoid multiple change notifications. 
                // We'll call it just once later.

                ObjectList prevOwner = _owner;
                _owner = null;
                for (int i = diff; i < 0; i++)
                {
                    ObjectListField field = new ObjectListField();
                    Add(field);
                    field.Owner = prevOwner;
                }
                _owner = prevOwner;
                NotifyOwnerChange();
            }
        }

        private void ClearFieldsViewState()
        {
            foreach (ObjectListField field in Items)
            {
                field.ClearViewState();
            }
        }
    }
}
