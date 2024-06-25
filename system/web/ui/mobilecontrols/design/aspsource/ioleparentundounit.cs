//------------------------------------------------------------------------------
// <copyright file="IOleParentUndoUnit.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

//---------------------------------------------------------------------------
// IOleParentUndoUnit.cs
//---------------------------------------------------------------------------
// WARNING: this file autogenerated
//---------------------------------------------------------------------------
// Copyright (c) 1999, Microsoft Corporation   All Rights Reserved
// Information Contained Herein Is Proprietary and Confidential.
//---------------------------------------------------------------------------

namespace Microsoft.VSDesigner.Interop {
    using System.Runtime.InteropServices;

    using System.Diagnostics;
    using System;
    
    using UnmanagedType = System.Runtime.InteropServices.UnmanagedType;

    [ComImport, System.Runtime.InteropServices.ComVisible(true),System.Runtime.InteropServices.Guid("A1FAF330-EF97-11CE-9BC9-00AA00608E01"), System.Runtime.InteropServices.InterfaceTypeAttribute(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOleParentUndoUnit {

        [return: System.Runtime.InteropServices.MarshalAs(UnmanagedType.I4)]
         [PreserveSig]
         int Do(
            [System.Runtime.InteropServices.In,System.Runtime.InteropServices.MarshalAs(UnmanagedType.Interface)] 
              Microsoft.VSDesigner.Interop.IOleUndoManager pUndoManager);

        [return: System.Runtime.InteropServices.MarshalAs(UnmanagedType.BStr)]
          string GetDescription();

        [return: System.Runtime.InteropServices.MarshalAs(UnmanagedType.I4)]
         [PreserveSig]
         int GetUnitType(
              ref Guid pClsid,
            [System.Runtime.InteropServices.Out,System.Runtime.InteropServices.MarshalAs(UnmanagedType.LPArray)] 
              int[] plID);

        
         void OnNextAdd();

        
         void Open(
            [System.Runtime.InteropServices.In,System.Runtime.InteropServices.MarshalAs(UnmanagedType.Interface)] 
              Microsoft.VSDesigner.Interop.IOleParentUndoUnit pPUU);

        [return: System.Runtime.InteropServices.MarshalAs(UnmanagedType.I4)]
         [PreserveSig]
         int Close(
            [System.Runtime.InteropServices.In,System.Runtime.InteropServices.MarshalAs(UnmanagedType.Interface)] 
              Microsoft.VSDesigner.Interop.IOleParentUndoUnit pPUU,
            [System.Runtime.InteropServices.In,System.Runtime.InteropServices.MarshalAs(UnmanagedType.Bool)] 
             bool fCommit);

        
         void Add(
            [System.Runtime.InteropServices.In,System.Runtime.InteropServices.MarshalAs(UnmanagedType.Interface)] 
              Microsoft.VSDesigner.Interop.IOleUndoUnit pUU);

        [return: System.Runtime.InteropServices.MarshalAs(UnmanagedType.I4)]
         [PreserveSig]
         int FindUnit(
            [System.Runtime.InteropServices.In,System.Runtime.InteropServices.MarshalAs(UnmanagedType.Interface)] 
              Microsoft.VSDesigner.Interop.IOleUndoUnit pUU);

        
         void GetParentState(
            [System.Runtime.InteropServices.Out,System.Runtime.InteropServices.MarshalAs(UnmanagedType.LPArray)] 
              int[] pdwState);

    }
}
