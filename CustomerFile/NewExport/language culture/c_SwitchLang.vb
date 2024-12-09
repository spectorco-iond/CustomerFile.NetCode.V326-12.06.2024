Public Class c_SwitchLang

    Public o_English As c_English
    Public o_Francais As c_Francais

    Dim objLang As Object

    Public Sub New(ByVal lang As String)
        If Trim(RTrim(lang.ToUpper)) = "EN" Then
            o_English = New c_English
            Lang_Return(o_English)
        ElseIf Trim(RTrim(lang.ToUpper)) = "FR" Then
            o_Francais = New c_Francais
            Lang_Return(o_Francais)
        End If
    End Sub
    Private Sub Lang_Return(ByRef o_Eng As c_English)
        Try
            With o_Eng
                strProg_Quote = .PROG_QUOTE
                strProg_Program = .PROG_PROGRAM
                strProg_SP = .PROG_SP
                strHeader_Mess_Prog = .HEADER_MESS_PROG
                strHeader_Mess_SP = .HEADER_MESS_SP
                strHeader_Mess_Quote = .HEADER_MESS_QUOTE

                strCustomer = .CUSTOMER
                strProgram = .PROGRAM
                strQuote = .QUOTE
                strAddress = .ADDRESS
                strProgDate = .PROGRAM_DATE
                strQuoteDate = .QUOTE_DATE
                strImprint = .IMPRINT
                strProg_StartDate = .PROG_START_DATE
                strQuote_StartDate = .QUOTE_START_DATE
                strProgEndDate = .PROG_END_DATE
                strQuoteEndDate = .QUOTE_END_DATE
                strContact = .CONTACT
                strPhone = .PHONE
                strSpect_Contact = .SPECTOR_CONTACT
                strEmail = .EMAIL
                strSpec_Email = .SPECTOR_EMAIL

                '-----Content Property------
                strCode = .CODE
                strColor = .COLOR
                strDecoration = .DECORATION
                strPack = .PACKAGING
                strShip = .SHIPPING
                strType = .TYPE
                strSetup = .SETUP
                strComment = .COMMENT
                strFooderMessQuote = .FOODER_MESS_QUOTE
                strFooderMessProg = .FOODER_MESS_PROG
                strPricing = .PRICING
                strEqp = .EQP
                strQty = .QUANTITY
                strPrice = .PRICE
                strSubTotal = .SUBTOTAL
                strRunCharge = .RUN_CHARGE
                strSetup_Price = .SETUP_PRICE
            End With


        Catch ex As Exception
            MsgBox("Error in c_SwitchLang.New(lang)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Lang_Return(ByRef o_Fr As c_Francais)
        Try
            With o_Fr
                strProg_Quote = .PROG_QUOTE
                strProg_Program = .PROG_PROGRAM
                strProg_SP = .PROG_SP
                strHeader_Mess_Prog = .HEADER_MESS_PROG
                strHeader_Mess_SP = .HEADER_MESS_SP
                strHeader_Mess_Quote = .HEADER_MESS_QUOTE

                strCustomer = .CUSTOMER
                strProgram = .PROGRAM
                strQuote = .QUOTE
                strAddress = .ADDRESS
                strProgDate = .PROGRAM_DATE
                strQuoteDate = .QUOTE_DATE
                strImprint = .IMPRINT
                strProg_StartDate = .PROG_START_DATE
                strQuote_StartDate = .QUOTE_START_DATE
                strProgEndDate = .PROG_END_DATE
                strQuoteEndDate = .QUOTE_END_DATE
                strContact = .CONTACT
                strPhone = .PHONE
                strSpect_Contact = .SPECTOR_CONTACT
                strEmail = .EMAIL
                strSpec_Email = .SPECTOR_EMAIL

                '-----Content Property------
                strCode = .CODE
                strColor = .COLOR
                strDecoration = .DECORATION
                strPack = .PACKAGING
                strShip = .SHIPPING
                strType = .TYPE
                strSetup = .SETUP
                strComment = .COMMENT
                strFooderMessQuote = .FOODER_MESS_QUOTE
                strFooderMessProg = .FOODER_MESS_PROG
                strPricing = .PRICING
                strEqp = .EQP
                strQty = .QUANTITY
                strPrice = .PRICE
                strSubTotal = .SUBTOTAL
                strRunCharge = .RUN_CHARGE
                strSetup_Price = .SETUP_PRICE
            End With

        Catch ex As Exception
            MsgBox("Error in c_SwitchLang.New(lang)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#Region "#############Private properties#################"
    Dim strProg_Quote As String
    Dim strProg_Program As String
    Dim strProg_SP As String
    Dim strHeader_Mess_Prog As String
    Dim strHeader_Mess_SP As String
    Dim strHeader_Mess_Quote As String
    Dim strCustomer As String
    Dim strProgram As String
    Dim strQuote As String
    Dim strAddress As String
    Dim strProgDate As String
    Dim strQuoteDate As String
    Dim strImprint As String
    Dim strProg_StartDate As String
    Dim strQuote_StartDate As String
    Dim strProgEndDate As String
    Dim strQuoteEndDate As String
    Dim strContact As String
    Dim strPhone As String
    Dim strSpect_Contact As String
    Dim strEmail As String
    Dim strSpec_Email As String

    '--------Content-----------
    Dim strCode As String
    Dim strColor As String
    Dim strDecoration As String
    Dim strPack As String
    Dim strShip As String
    Dim strType As String
    Dim strSetup As String
    Dim strComment As String
    Dim strFooderMessQuote As String
    Dim strFooderMessProg As String
    Dim strPricing As String
    Dim strEqp As String
    Dim strQty As String
    Dim strPrice As String
    Dim strSubTotal As String
    Dim strRunCharge As String
    Dim strSetup_Price As String

#End Region
#Region "##########-Public Properties-######################"

    Public ReadOnly Property PROG_QUOTE As String
        Get
            PROG_QUOTE = strProg_Quote
        End Get
    End Property
    Public ReadOnly Property PROG_PROGRAM As String
        Get
            PROG_PROGRAM = strProg_Program
        End Get
    End Property
    Public ReadOnly Property PROG_SP As String
        Get
            PROG_SP = strProg_SP
        End Get
    End Property
    Public ReadOnly Property HEADER_MESS_PROG As String
        Get
            HEADER_MESS_PROG = strHeader_Mess_Prog
        End Get
    End Property
    Public ReadOnly Property HEADER_MESS_SP As String
        Get
            HEADER_MESS_SP = strHeader_Mess_SP
        End Get
    End Property
    Public ReadOnly Property HEADER_MESS_QUOTE As String
        Get
            HEADER_MESS_QUOTE = strHeader_Mess_Quote
        End Get
    End Property
    Public ReadOnly Property CUSTOMER As String
        Get
            CUSTOMER = strCustomer
        End Get
    End Property
    Public ReadOnly Property PROGRAM As String
        Get
            PROGRAM = strProgram
        End Get
    End Property
    Public ReadOnly Property QUOTE As String
        Get
            QUOTE = strQuote
        End Get
    End Property
    Public ReadOnly Property ADDRESS As String
        Get
            ADDRESS = strAddress
        End Get
    End Property
    Public ReadOnly Property PROGRAM_DATE As String
        Get
            PROGRAM_DATE = strProgDate
        End Get
    End Property
    Public ReadOnly Property QUOTE_DATE As String
        Get
            QUOTE_DATE = strQuoteDate
        End Get
    End Property
    Public ReadOnly Property IMPRINT As String
        Get
            IMPRINT = strImprint
        End Get
    End Property
    Public ReadOnly Property PROG_START_DATE As String
        Get
            PROG_START_DATE = strProg_StartDate
        End Get
    End Property
    Public ReadOnly Property QUOTE_START_DATE As String
        Get
            QUOTE_START_DATE = strQuote_StartDate
        End Get
    End Property
    Public ReadOnly Property PROG_END_DATE As String
        Get
            PROG_END_DATE = strProgEndDate
        End Get
    End Property
    Public ReadOnly Property QUOTE_END_DATE As String
        Get
            QUOTE_END_DATE = strQuoteEndDate
        End Get
    End Property
    Public ReadOnly Property CONTACT As String
        Get
            CONTACT = strContact
        End Get
    End Property
    Public ReadOnly Property PHONE As String
        Get
            PHONE = strPhone
        End Get
    End Property
    Public ReadOnly Property SPECTOR_CONTACT As String
        Get
            SPECTOR_CONTACT = strSpect_Contact
        End Get
    End Property
    Public ReadOnly Property EMAIL As String
        Get
            EMAIL = strEmail
        End Get
    End Property
    Public ReadOnly Property SPECTOR_EMAIL As String
        Get
            SPECTOR_EMAIL = strSpec_Email
        End Get
    End Property
    '---------------Content Property-------------------
    Public ReadOnly Property CODE As String
        Get
            CODE = strCode
        End Get
    End Property
    Public ReadOnly Property COLOR As String
        Get
            COLOR = strColor
        End Get
    End Property
    Public ReadOnly Property DECORATION As String
        Get
            DECORATION = strDecoration
        End Get
    End Property
    Public ReadOnly Property PACKAGING As String
        Get
            PACKAGING = strPack
        End Get
    End Property
    Public ReadOnly Property SHIPPING As String
        Get
            SHIPPING = strShip
        End Get
    End Property
    Public ReadOnly Property TYPE As String
        Get
            TYPE = strType
        End Get
    End Property
    Public ReadOnly Property SETUP As String
        Get
            SETUP = strSetup
        End Get
    End Property
    Public ReadOnly Property COMMENT As String
        Get
            COMMENT = strComment
        End Get
    End Property
    Public ReadOnly Property FOODER_MESS_QUOTE As String
        Get
            FOODER_MESS_QUOTE = strFooderMessQuote
        End Get
    End Property
    Public ReadOnly Property FOODER_MESS_PROG As String
        Get
            FOODER_MESS_PROG = strFooderMessProg
        End Get
    End Property

    '-------PRICING IN THE CONTENT--------- 
    Public ReadOnly Property PRICING As String
        Get
            PRICING = strPricing
        End Get
    End Property
    Public ReadOnly Property EQP As String
        Get
            EQP = strEqp
        End Get
    End Property
    Public ReadOnly Property QUANTITY As String
        Get
            QUANTITY = strQty
        End Get
    End Property
    Public ReadOnly Property PRICE As String
        Get
            PRICE = strPrice
        End Get
    End Property
    Public ReadOnly Property SUBTOTAL As String
        Get
            SUBTOTAL = strSubTotal
        End Get
    End Property
    Public ReadOnly Property RUN_CHARGE As String
        Get
            RUN_CHARGE = strRunCharge
        End Get
    End Property
    Public ReadOnly Property SETUP_PRICE As String
        Get
            SETUP_PRICE = strSetup_Price
        End Get
    End Property


#End Region
End Class
