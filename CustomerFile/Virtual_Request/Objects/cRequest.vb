Imports System.Data.Odbc

Public Class cRequest

#Region "Private variable#########################################"

    Private m_intrequest_id As Int32
    Private m_intitem_master_id As Int32
    'Private m_stritem_cd As String ' result from item_master_id only display
    ' 'Private m_intitem_classification_id As Int32 ' result from item_master_id
    'Private m_strprod_category As String is result from item_clasification_id only display
    'Private m_blis_kit As Boolean  ' result from item_master_id only display
    Private m_intcolor_id As Int32 'result from item_master 
    'Private m_strcolor_cd As String 'is result from color_id only display
    'Private m_strcolor_name As String 'is result from color_id only display
    'Private m_strcolor_name_fr As String 'is result from color_id only display
    ' ' Private m_intitem_variant_id As Int32 'is result from color_id
    'Private m_stritem_no As String 'is result from color_id & item_master_id only display 
    Private m_intitem_imp_loc_id As Int32 'result from item_master_id
    'Private m_intcomp_item_cd As Int32 'result from item_imp_loc_id 
    'Private m_strcomponent_cd As String  'result from item_imp_loc_id
    '    Private m_intdec_met_id As Int32 'result from item_imp_loc_id & item_master_id
    'Private m_strdec_met_desc As String  'result from dec_met_id
    '' Private m_intimp_loc_id As Int32 'result from item_imp_loc_id 
    'Private m_strloc_desc As String 'result from imp_loc_id
    'Private m_strarea_size As String 'result from item_imp_loc_id
    'Private m_bldefault_loc As Boolean 'result from item_imp_loc_id
    Private m_inttDocId As Int32
    Private m_struser_login As String
    Private m_dtcreate_ts As Date
    Private m_dtupdate_ts As Date

#End Region

#Region "Public Property########################################"
    Public Property Request_ID As Int32
        Get
            Request_ID = m_intrequest_id
        End Get
        Set(value As Int32)
            m_intrequest_id = value
        End Set
    End Property
    Public Property Item_Master_ID As Int32
        Get
            Item_Master_ID = m_intitem_master_id
        End Get
        Set(value As Int32)
            m_intitem_master_id = value
        End Set
    End Property
    Public Property Color_ID As Int32
        Get
            Color_ID = m_intcolor_id
        End Get
        Set(value As Int32)
            m_intcolor_id = value
        End Set
    End Property
    Public Property Item_Imp_Loc_ID As Int32
        Get
            Item_Imp_Loc_ID = m_intitem_imp_loc_id
        End Get
        Set(value As Int32)
            m_intitem_imp_loc_id = value
        End Set
    End Property
    Public Property DocId As Int32
        Get
            DocId = m_inttDocId
        End Get
        Set(value As Int32)
            m_inttDocId = value
        End Set
    End Property

    Public Property USER_LOGIN As String
        Get
            USER_LOGIN = m_struser_login
        End Get
        Set(value As String)
            m_struser_login = value
        End Set
    End Property
    Public Property CREATE_TS As Date
        Get
            CREATE_TS = m_dtcreate_ts
        End Get
        Set(value As Date)
            m_dtcreate_ts = value
        End Set
    End Property
    Public Property UPDATE_TS As Date
        Get
            UPDATE_TS = m_dtupdate_ts
        End Get
        Set(value As Date)
            m_dtupdate_ts = value
        End Set
    End Property

#End Region



End Class
