//------------------------------------------------------------------------------
// <copyright file="SelectionList.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Web.UI.MobileControls
{
    /*
     * Mobile SelectionList class.
     *
     * Copyright (c) 2000 Microsoft Corporation
     */
    [
        ControlBuilderAttribute(typeof(ListControlBuilder)),
        DefaultEvent("SelectedIndexChanged"),
        DefaultProperty("DataSource"),
        Designer(typeof(System.Web.UI.Design.MobileControls.SelectionListDesigner)),
        DesignerAdapter(typeof(System.Web.UI.Design.MobileControls.Adapters.DesignerSelectionListAdapter)),
        Editor(typeof(System.Web.UI.Design.MobileControls.SelectionListComponentEditor), typeof(ComponentEditor)),
        ToolboxData("<{0}:SelectionList runat=\"server\"></{0}:SelectionList>"),
        ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, " + AssemblyRef.SystemDesign),
        ValidationProperty("Selection")
    ]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class SelectionList : MobileControl, IPostBackDataHandler, IListControl
    {
        private static readonly Object EventItemDataBind = new Object();
        private static readonly Object EventSelectedIndexChanged = new Object();

        private ListDataHelper _dataHelper;
        private int _cachedSelectedIndex = -1;
        
        public SelectionList()
        {
            _dataHelper = new ListDataHelper(this, ViewState);
        }

        /////////////////////////////////////////////////////////////////////////
        //  IListControl
        /////////////////////////////////////////////////////////////////////////

        void IListControl.OnItemDataBind(ListDataBindEventArgs e) 
        {
            OnItemDataBind(e);
        }

        bool IListControl.TrackingViewState
        {
            get
            {
                return IsTrackingViewState;
            }
        }

        /// <summary>
        ///    <para>
        ///       Gets or sets the <see langword='DataSource'/> property of the control which is used to populate
        ///       the items within the control.
        ///    </para>
        /// </summary>
        [
            Bindable(true),
            DefaultValue(null),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            MobileCategory(SR.Category_Data),
            MobileSysDescription(SR.List_DataSource)
        ]
        public virtual Object DataSource 
        {
            get 
            {
                return _dataHelper.DataSource;
            }

            set 
            {
                _dataHelper.DataSource = value;
            }
        }

        private IEnumerable ResolvedDataSource
        {
            get
            {
                return _dataHelper.ResolvedDataSource;
            }
        }

        [
            Bindable(false),
            DefaultValue(""),
            MobileCategory(SR.Category_Data),
            MobileSysDescription(SR.List_DataMember),
            TypeConverter(typeof(System.Web.UI.Design.MobileControls.Converters.DataMemberConverter))
        ]
        public virtual String DataMember
        {
            get 
            {
                return _dataHelper.DataMember;
            }

            set 
            {
                _dataHelper.DataMember = value;
            }
        }

        [
            DefaultValue(""),
            MobileCategory(SR.Category_Data),
            MobileSysDescription(SR.List_DataTextField),
            TypeConverter(typeof(System.Web.UI.Design.MobileControls.Converters.DataFieldConverter))
        ]
        public String DataTextField 
        {
            get 
            {
                return _dataHelper.DataTextField;
            }
            set 
            {
                _dataHelper.DataTextField = value;
            }
        }

        [
            DefaultValue(""),
            MobileCategory(SR.Category_Data),
            MobileSysDescription(SR.List_DataValueField),
            TypeConverter(typeof(System.Web.UI.Design.MobileControls.Converters.DataFieldConverter))
        ]
        public String DataValueField 
        {
            get 
            {
                return _dataHelper.DataValueField;
            }
            set 
            {
                _dataHelper.DataValueField = value;
            }
        }
        
        [
            Bindable(false),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public bool IsMultiSelect
        {
            get
            {
                return (SelectType == ListSelectType.MultiSelectListBox  || 
                        SelectType == ListSelectType.CheckBox);
            }
        }

        [
            Bindable(true),
            Browsable(true),
            DefaultValue(4),
            MobileCategory(SR.Category_Appearance),
            MobileSysDescription(SR.SelectionList_Rows)
        ]
        public int Rows
        {
            get
            {
                Object o = ViewState["Rows"];
                return o != null ? (int)o : 4;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Rows");
                }
                ViewState["Rows"] = value;
            }
        }

        [
            Bindable(false),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public int SelectedIndex 
        {
            get 
            {
                for (int i = 0; i < Items.Count; i++) 
                {
                    if (Items[i].Selected)
                    {
                        return i;
                    }
                }
                return -1;
            }
            set 
            {
                // if we have no items, save the selectedindex
                // for later databinding
                if (Items.Count == 0) 
                {
                    _cachedSelectedIndex = value;
                }
                else 
                {
                    if (value < -1 || value >= Items.Count)
                    {
                        throw new ArgumentOutOfRangeException(
                            "SelectedIndex",
                            SR.GetString(SR.SelectionList_OutOfRange,value));
                    }
                    ClearSelection();
                    if (value >= 0)
                    {
                        Items[value].Selected = true;
                    }
                }
            }
        }

        [
            Bindable(false),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public MobileListItem Selection
        {
            get
            {
                int selectedIndex = SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < Items.Count)
                {
                    return Items[selectedIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        [
            Bindable(false),
            DefaultValue(null),
            Editor(typeof(System.Web.UI.Design.MobileControls.ItemCollectionEditor), typeof(UITypeEditor)),
            MergableProperty(false),
            MobileSysDescription(SR.List_Items),
            PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public MobileListItemCollection Items
        {
            get
            {
                return _dataHelper.Items;
            }
        }

        protected override void AddParsedSubObject(Object obj)
        {
            if (!(obj is LiteralControl))
            {
                if (obj is MobileListItem)
                {
                    _dataHelper.AddItem((MobileListItem)obj);
                    if(_cachedSelectedIndex != -1 && 
                       _dataHelper.Items.Count > _cachedSelectedIndex)
                    {
                        SelectedIndex = _cachedSelectedIndex;
                        _cachedSelectedIndex = -1;
                    }
                } 
                else
                {
                    base.AddParsedSubObject(obj);
                }
            }
        }

        protected override void OnPreRender(EventArgs e) 
        {
            base.OnPreRender(e);
            if (Page != null && IsMultiSelect) 
            {
                // ensure postback when no item is selected
                Page.RegisterRequiresPostBack(this);
            }
        }

        protected override void OnDataBinding(EventArgs e) 
        {
            base.OnDataBinding(e);

            if (ResolvedDataSource != null)
            {
                CreateItems(ResolvedDataSource);
            }

            if (_cachedSelectedIndex != -1) 
            {
                SelectedIndex = _cachedSelectedIndex;
                _cachedSelectedIndex = -1;
            }
        }

        protected virtual void CreateItems(IEnumerable dataSource) 
        {
            _dataHelper.CreateItems(dataSource);
        }

        [
            MobileCategory(SR.Category_Action),
            MobileSysDescription(SR.SelectionList_OnSelectedIndexChanged)
        ]
        public event EventHandler SelectedIndexChanged
        {
            add 
            {
                Events.AddHandler(EventSelectedIndexChanged, value);
            }
            remove 
            {
                Events.RemoveHandler(EventSelectedIndexChanged, value);
            }
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e) 
        {
            EventHandler onSelectedIndexChangedHandler = (EventHandler)Events[EventSelectedIndexChanged];
            if (onSelectedIndexChangedHandler != null)
            {
                onSelectedIndexChangedHandler(this, e);
            }
        }

        [
            MobileCategory(SR.Category_Action),
            MobileSysDescription(SR.List_OnItemDataBind)
        ]
        public event ListDataBindEventHandler ItemDataBind 
        {
            add 
            {
                Events.AddHandler(EventItemDataBind, value);
            }
            remove 
            {
                Events.RemoveHandler(EventItemDataBind, value);
            }
        }

        protected virtual void OnItemDataBind(ListDataBindEventArgs e) 
        {
            ListDataBindEventHandler onItemDataBindHandler = (ListDataBindEventHandler)Events[EventItemDataBind];
            if (onItemDataBindHandler != null)
            {
                onItemDataBindHandler(this, e);
            }
        }

        bool IPostBackDataHandler.LoadPostData(String postDataKey, NameValueCollection postCollection) 
        {
            bool dataChanged;
            bool handledByAdapter =
                Adapter.LoadPostData(postDataKey,
                                     postCollection,
                                     SelectedIndicesInternal.ToArray(typeof(int)),
                                     out dataChanged);

            if (!handledByAdapter)
            {
                throw new
                    Exception(SR.GetString(SR.SelectionList_AdapterNotHandlingLoadPostData));
            }

            return dataChanged;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent() 
        {
            OnSelectedIndexChanged(EventArgs.Empty);
        }

        [
            Bindable(true),
            DefaultValue(ListSelectType.DropDown),
            MobileCategory(SR.Category_Appearance),
            MobileSysDescription(SR.SelectionList_SelectType)
        ]
        public ListSelectType SelectType
        {
            get
            {
                Object o = ViewState["SelectType"];
                return (o != null) ? (ListSelectType)o : ListSelectType.DropDown;
            }
            set
            {
                ViewState["SelectType"] = value;
            }
        }

        [
            Bindable(true),
            DefaultValue(""),
            MobileCategory(SR.Category_Appearance),
            MobileSysDescription(SR.SelectionList_Title)
        ]
        public String Title
        {
            get
            {
                return ToString(ViewState["Title"]);
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        /////////////////////////////////////////////////////////////////////////
        //  STATE MANAGEMENT
        /////////////////////////////////////////////////////////////////////////

        protected override void TrackViewState() 
        {
            base.TrackViewState();
            if (_dataHelper.HasItems())
            {
                ((IStateManager)Items).TrackViewState();
            }
        }

        protected override Object SaveViewState() 
        {
            Object baseState = base.SaveViewState();
            Items.SaveSelection = true;
            Object items = ((IStateManager)Items).SaveViewState();

            if (items != null || baseState != null)
            {
                return new Object[] { baseState, items };
            }
            
            return null;
        }

        protected override void LoadViewState(Object savedState) 
        {
            if (savedState != null) 
            {
                Object[] state = (Object[])savedState;
                if (state[0] != null)
                {
                    base.LoadViewState(state[0]);
                }
                
                // restore state of items
                Items.SaveSelection = true;
                ((IStateManager)Items).LoadViewState(state[1]);
            }
        }

        private ArrayList SelectedIndicesInternal 
        {
            get 
            {
                int count = Items.Count;
                ArrayList selectedIndices = new ArrayList(count); 
                for (int i = 0; i < count; i++) 
                {
                    if (Items[i].Selected)  
                    {
                        selectedIndices.Add(i);
                    }
                }
                return selectedIndices;
            }
        }

        internal void ClearSelection() 
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Selected = false;
            }
        }

        private void SelectInternal(ArrayList selectedIndices) 
        {
            ClearSelection();
            for (int i = 0; i < selectedIndices.Count; i++) 
            {
                int n = (int) selectedIndices[i];
                if (n >= 0 && n < Items.Count)
                {
                    Items[n].Selected = true;
                }
            }
        }
    }
}





