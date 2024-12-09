
Public Class cOeprcfil_sql_Pack

#Region "################ Private Property ##################"

    Private mCus_No As String
    Private mCurr_Cd As String
    Private mItem_No As String
    Private mQuantity As Integer
#End Region

    Public Sub New()

        Call Init()

    End Sub


    Private Sub Init()
        mCus_No = String.Empty
        mCurr_Cd = String.Empty
        mItem_No = String.Empty
        mQuantity = 0
    End Sub

    Public Function displayPrice(ByVal m_Program As String) As Decimal

        displayPrice = 0.0
        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String

        'now with cus_no and item_no we can easier find price if he is EQP ....

        strSql = _
            " select *  from Oeprcfil_Sql  WITH (Nolock) " & _
            " where cd_tp_1_cust_no = '" & mCus_No & "' and curr_Cd = '" & mCurr_Cd & "'" & _
            "and end_dt >= GETDATE() and cd_tp_1_item_no = '" & Trim(mItem_No) & "' " & _
            " and cd_tp_3_cust_type = '' and extra_14 is null "

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            'it must analise if is null pass to another price(prc_or_disc_2(3,4,5,6..))
            displayPrice = dt.Rows(0).Item("prc_or_disc_1")

        Else
            'if is not EQP .... , we seek only with item_no and retrieve prc_or_disc_2 if min quantite is greater as 300 and as smoller 700 
            strSql = _
               " select *  from Oeprcfil_Sql  WITH (Nolock) " & _
               " where cd_tp = 6 and cd_tp_1_cust_no = '' and curr_Cd = '" & mCurr_Cd & "' " & _
               " and end_dt >= GETDATE() and  cd_tp_1_item_no = '" & Trim(mItem_No) & "' " & _
               " and cd_tp_3_cust_type = '' and extra_14 is null "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                ''it must seeks price by quantity
                '   If program_Type <> "Program" And eqp_level = False Then

                Select Case m_Program
                    Case "QuoteProgram"

                        Call PrcorDisclatestcolon(displayPrice, dt)

                        'If mQuantity < dt.Rows(0).Item("Minimum_Qty_2") Then

                        '    displayPrice = dt.Rows(0).Item("prc_or_disc_1")

                        'ElseIf (mQuantity >= dt.Rows(0).Item("Minimum_Qty_2") And mQuantity < dt.Rows(0).Item("Minimum_Qty_3")) _
                        '    Or dt.Rows(0).Item("Minimum_Qty_3") = 0.0 Then

                        '    displayPrice = dt.Rows(0).Item("prc_or_disc_2")

                        'ElseIf (mQuantity >= dt.Rows(0).Item("Minimum_Qty_3") And mQuantity < dt.Rows(0).Item("Minimum_Qty_4")) _
                        '    Or dt.Rows(0).Item("Minimum_Qty_4") = 0.0 Then

                        '    displayPrice = dt.Rows(0).Item("prc_or_disc_3")

                        'ElseIf (mQuantity >= dt.Rows(0).Item("Minimum_Qty_4") And mQuantity < dt.Rows(0).Item("Minimum_Qty_5")) _
                        '    Or dt.Rows(0).Item("Minimum_Qty_5") = 0.0 Then

                        '    displayPrice = dt.Rows(0).Item("prc_or_disc_4")

                        'ElseIf (mQuantity >= dt.Rows(0).Item("Minimum_Qty_5") And mQuantity < dt.Rows(0).Item("Minimum_Qty_6")) _
                        '    Or dt.Rows(0).Item("Minimum_Qty_6") = 0.0 Then

                        '    displayPrice = dt.Rows(0).Item("prc_or_disc_5")

                        'ElseIf mQuantity >= dt.Rows(0).Item("Minimum_Qty_6") Then

                        '    displayPrice = dt.Rows(0).Item("prc_or_disc_6")

                        'End If
                    Case "CustomerHeader"
                        Call PrcorDisclatestcolon(displayPrice, dt)
                End Select

            End If

            '  Call PrcorDisclatestcolon(displayPrice, dt)

            'ElseIf program_Type = "Program" Or (program_Type = "Special Pricing" And eqp_level = True) Then

            '    'it must create an (if or select) for identifie the price smaller
            '    'If  prc_or_disc_6 is not exist pass prc_or_disc_5 until find the price with value
            '    'also it must think about if EQP is checked this is also an critere

            '    If dt.Rows(0).Item("prc_or_disc_6") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_6")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_5") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_5")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_4") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_4")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_3") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_3")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_2") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_2")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_1") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_1")
            '    End If

            '  End If

            '  End If

        End If

    End Function

    Public Sub PrcorDisclatestcolon(ByRef displayPrice As Decimal, ByRef dt As DataTable)
        Try

            If dt.Rows(0).Item("prc_or_disc_6") <> 0.0 Then
                displayPrice = dt.Rows(0).Item("prc_or_disc_6")
            Else
                If dt.Rows(0).Item("prc_or_disc_5") <> 0.0 Then
                    displayPrice = dt.Rows(0).Item("prc_or_disc_5")
                Else
                    If dt.Rows(0).Item("prc_or_disc_4") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_4")
                    Else
                        If dt.Rows(0).Item("prc_or_disc_3") <> 0.0 Then
                            displayPrice = dt.Rows(0).Item("prc_or_disc_3")
                        Else
                            If dt.Rows(0).Item("prc_or_disc_2") <> 0.0 Then
                                displayPrice = dt.Rows(0).Item("prc_or_disc_2")
                            Else
                                If dt.Rows(0).Item("prc_or_disc_1") <> 0.0 Then
                                    displayPrice = dt.Rows(0).Item("prc_or_disc_1")
                                Else
                                    displayPrice = 0.0
                                End If
                            End If
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MsgBox("Error in  cOeprcfil_sql_Pack() ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "############# Public Property ####################"
    Public Property Cus_No As String
        Get
            Cus_No = mCus_No
        End Get
        Set(ByVal value As String)
            mCus_No = value
        End Set
    End Property
    Public Property Curr_Cd As String
        Get
            Curr_Cd = mCurr_Cd
        End Get
        Set(ByVal value As String)
            mCurr_Cd = value
        End Set
    End Property
    Public Property Item_No As String
        Get
            Item_No = mItem_No
        End Get
        Set(ByVal value As String)
            mItem_No = value
        End Set
    End Property
    Public Property Quantity As Integer
        Get
            Quantity = mQuantity
        End Get
        Set(ByVal value As Integer)
            mQuantity = value
        End Set
    End Property
#End Region

End Class
