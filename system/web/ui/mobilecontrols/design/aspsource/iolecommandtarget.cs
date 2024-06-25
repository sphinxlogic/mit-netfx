//------------------------------------------------------------------------------
// <copyright file="IOleCommandTarget.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

//---------------------------------------------------------------------------
// IOleCommandTarget.cs
//---------------------------------------------------------------------------
// WARNING: this file autogenerated
//---------------------------------------------------------------------------
// Copyright (c) 1999, Microsoft Corporation   All Rights Reserved
// Information Contained Herein Is Proprietary and Confidential.
//---------------------------------------------------------------------------

namespace Microsoft.VSDesigner.Interop {
    using System;
    using System.Runtime.InteropServices;

    [System.Runtime.InteropServices.ComVisible(true), 
    ComImport,
    Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"),
    System.Runtime.InteropServices.InterfaceTypeAttribute(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown),
    CLSCompliantAttribute(false)
    ]
    internal interface IOleCommandTarget {

        //C#r: UNDONE (Field in interface) public static readonly    Guid iid;
        [return: MarshalAs(UnmanagedType.I4)]
        [System.Runtime.InteropServices.PreserveSig]
        int QueryStatus(
                       ref Guid pguidCmdGroup,
                       int cCmds,
                       [In, Out] 
                       Microsoft.VSDesigner.Interop._tagOLECMD prgCmds,
                       [In, Out] 
                       int pCmdText);

        [return: MarshalAs(UnmanagedType.I4)]
        [System.Runtime.InteropServices.PreserveSig]
        int Exec(
                ref Guid pguidCmdGroup,
                int nCmdID,
                int nCmdexecopt,
                // we need to have this an array because callers need to be able to specify NULL or VT_NULL
                [In, MarshalAs(UnmanagedType.LPArray)]
                Object[] pvaIn,
                int pvaOut);
    }
}

